using System;
using System.Security.Cryptography.X509Certificates;
using SAPILib;

namespace XMLSign
{
    public static class SAPIWrapper
    {
        private const int AR_XML_XML_SIG_TYPE_ENVELOPED = 0x00000001;
        private const int AR_XML_XML_SIG_TYPE_ENVELOPING = 0x00000002;
        private const int AR_XML_SIG_TYPE_XADES_BES = 0x00000010;

        private static object _SyncRoot = new object();

        //Checks if SAPI is initialized or not.
        private static bool isSAPIInitialized(SAPICrypt SAPI)
        {
            SESHandle hSes;
            int rc;
            if ((rc = SAPI.HandleAcquire(out hSes)) != 0)
                return false;

            SAPI.HandleRelease(hSes);
            return true;
        }

        //Thread-Safe SAPIInit()
        private static void SAPIInit()
        {
            SAPICrypt SAPI = new SAPICrypt();

            lock (_SyncRoot)
            {
                //Do nothing if SAPI is initialized already
                if (isSAPIInitialized(SAPI)) return;

                //Initialize SAPI
                int rc = SAPI.Init();
                if (rc != 0)
                {
                    throw new Exception(string.Format(
                        "Failed to load SAPI library (#{0})", rc.ToString("X")));
                }
            }
        }


        public static void SignXML(
            string Username,
            string Domain,
            string Password,
            string XMLDataToSign     //The stream to read the data to be signed from
            )
        {
            if (string.IsNullOrEmpty(Username)) throw new ArgumentNullException("Username");
            if (string.IsNullOrEmpty(Password)) throw new ArgumentNullException("Password");
            if (XMLDataToSign == null) throw new ArgumentNullException("XMLDataToSign");

            //Make sure the SAPI library is loaded into the current process
            SAPIInit();

            //Instantiate SAPI object
            SAPICrypt SAPI = new SAPICrypt();
            SigFieldSettings SFS = new SigFieldSettings();

            SESHandle hSes = null;
            int rc = 0;

            if ((rc = SAPI.HandleAcquire(out hSes)) != 0)
            {
                throw new Exception(string.Format(
                    "Memory allocation error (#{0})", rc.ToString("X")));
            }

            if (Domain.Trim() == "")
                rc = SAPI.Logon(hSes, Username, null, Password);
            else
                rc = SAPI.Logon(hSes, Username, Domain, Password);

            if (rc != 0)
            {
                SAPI.HandleRelease(hSes);
                throw new Exception(string.Format(
                    "Failed to authenticate the user(#{0})", rc.ToString("X")));
            }

            if ((rc = SAPI.SignatureFieldCreateSignEx2(hSes, SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_XML,
                XMLDataToSign, null, new SigFieldSettings(), AR_XML_XML_SIG_TYPE_ENVELOPED | AR_XML_SIG_TYPE_XADES_BES, null)) != 0)
            {
                SAPI.Logoff(hSes);
                SAPI.HandleRelease(hSes);
                throw new Exception(string.Format(
                    "Failed to initialize XML signing process(#{0})", rc.ToString("X")));
            }


            //Cleanup memory
            SAPI.Logoff(hSes);
            SAPI.HandleRelease(hSes);
        }


        public class SignatureDetails
        {
            public bool isValid { get; set; }
            public X509Certificate2 SignerCertificate { get; set; }

            public string SignerName { get; set; }
            public string SignerEmail { get; set; }

            public long SignatureTimeTicks { get; set; }
        }


        public static SignatureDetails ValidateXMLSignature(string SignedXML)
        {
            if (SignedXML == null) throw new ArgumentNullException("SignedXML");

            //Make sure the SAPI Library is loaded
            SAPIInit();
            SignatureDetails SigDetails = new SignatureDetails();
            SigFieldSettings SigFieldSettings = new SigFieldSettings();
            SigFieldInfo SignatureFieldInfo = new SigFieldInfo();
            SAPICrypt SAPI = new SAPICrypt();
            SigFieldHandle hField = null;
            int rc;

            SESHandle hSession = new SESHandle();
            if ((rc = SAPI.HandleAcquire(out hSession)) != 0)
            {
                throw new Exception(string.Format(
                    "Memory allocation error (#{0})", rc.ToString("X")));
            }

            SAPIContext ctxValidateSignature = new SAPIContext();
            int num = 0;
            if ((rc = SAPI.SignatureFieldEnumInit(hSession, ctxValidateSignature, SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_XML, SignedXML, 0, ref num)) != 0)
            {
                SAPI.HandleRelease(hSession);
                throw new Exception(string.Format(
                    "An error occured while initializing the signature validation process (#{0})", rc.ToString("X")));
            }

            if (num < 1) throw new Exception("The XML file is not signed!");
            if (num > 1) throw new Exception("SAPI only supports a single signature per XML file!");

            if ((rc = SAPI.SignatureFieldEnumCont(hSession, ctxValidateSignature, out hField)) != 0)
            {
                SAPI.ContextRelease(ctxValidateSignature);
                SAPI.HandleRelease(hSession);
                throw new Exception(string.Format(
                    "Failed to retrieve signature (#{0})", rc.ToString("X")));
            }

            if ((rc = SAPI.SignatureFieldInfoGet(hSession, hField, SigFieldSettings, SignatureFieldInfo)) != 0)
            {
                SAPI.ContextRelease(ctxValidateSignature);
                SAPI.HandleRelease(hSession);
                throw new Exception(string.Format(
                    "Failed to parse signature details (#{0})", rc.ToString("X")));
            }

            CertStatus not_used = new CertStatus();
            SigDetails.isValid = SAPI.SignatureFieldVerify(hSession, hField, not_used, 0) == 0;

            SigDetails.SignerCertificate = new X509Certificate2(
                (byte[])(((SAPIByteArray)SignatureFieldInfo.Certificate).ToArray()));
            SigDetails.SignerName = SignatureFieldInfo.SignerName;

            //Convert FILE_TIME to ticks
            ulong filetime = SignatureFieldInfo.SignatureTime.HighDateTime;
            filetime <<= 32;
            filetime += SignatureFieldInfo.SignatureTime.LowDateTime;
            SigDetails.SignatureTimeTicks = DateTime.FromFileTimeUtc((long)filetime).Ticks;

            //Cleanup memory
            SAPI.ContextRelease(ctxValidateSignature);
            SAPI.HandleRelease(hSession);

            return SigDetails;
        }
    }
}
