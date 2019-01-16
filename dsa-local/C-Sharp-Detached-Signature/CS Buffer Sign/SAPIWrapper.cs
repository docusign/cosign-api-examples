using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

using SAPILib;

namespace CS_Buffer_Sign
{
    public static class SAPIWrapper
    {
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


        public static void SignStream(
            string Username,   
            string Domain,     
            string Password,
            Stream DataToSign,     //The stream to read the data to be signed from
            Stream SignatureData   //The stream to write the signature data to
            )
        {
            if (string.IsNullOrEmpty(Username)) throw new ArgumentNullException("Username");
            if (string.IsNullOrEmpty(Password)) throw new ArgumentNullException("Password");
            if (DataToSign == null) throw new ArgumentNullException("DataToSign");
            if (SignatureData == null) throw new ArgumentNullException("SignatureData");

            //Make sure the SAPI library is loaded into the current process
            SAPIInit();

            //Instantiate SAPI object
            SAPICrypt SAPI = new SAPICrypt();

            SESHandle hSes = null;
            int rc = 0;

            if ((rc = SAPI.HandleAcquire (out hSes)) != 0)
            {
                throw new Exception(string.Format(
                    "Memory allocation error (#{0})", rc.ToString("X")));
            }


            if ((rc = SAPI.Logon(hSes, Username, Domain, Password)) != 0)
            {
                SAPI.HandleRelease(hSes); 
                throw new Exception(string.Format(
                    "Failed to authenticate the user(#{0})", rc.ToString("X")));
            }

            //Allocate new signing context
            SAPIContext ctxBuffSign = new SAPIContext();

            if ((rc = SAPI.BufferSignInit (hSes, ctxBuffSign, 0)) != 0)
            {
                SAPI.Logoff(hSes);
                SAPI.HandleRelease(hSes);
                throw new Exception(string.Format(
                    "Failed to initialize buffer signing process(#{0})", rc.ToString("X")));
            }

            int remaining = (int)DataToSign.Length;
            
            //Check that the stream is not empty
            if ((int)DataToSign.Length < 1)
            {
                SAPI.Logoff(hSes);
                SAPI.HandleRelease(hSes);
                throw new Exception("Cannot sign empty stream!");
            }

            int chunkMaxSize = 1 << 20; //1MB

            //Calculate first chunk size
            int chunkSize = remaining < chunkMaxSize ?
                remaining : chunkMaxSize;

            while (remaining > 0)
            {
                Array chunk = new byte[chunkSize]; //Read in chunks of 1MB
                int read = DataToSign.Read((byte[])chunk, 0, chunkSize);
                if (read <= 0) throw new EndOfStreamException (String.Format("End of stream reached with {0} bytes left to read", remaining));

                //Build SAPI-Compatible bytes array
                SAPIByteArray tmpBuff = new SAPIByteArray();
                tmpBuff.FromArray(ref chunk);

                //Add read buffer to the signature calculation
                if ((rc = SAPI.BufferSignCont(hSes, ctxBuffSign, tmpBuff))!= 0)
                {
                    SAPI.ContextRelease (ctxBuffSign);
                    SAPI.Logoff (hSes);
                    SAPI.HandleRelease (hSes);

                    throw new Exception(string.Format(
                        "An error occured while calculating the digital signature (#{0})", rc.ToString("X")));
                }

                remaining -= read;
                chunkSize = Math.Min(remaining, chunkSize);
            }

            SAPIByteArray signature = new SAPIByteArray();           
            //Get the final signature
            if ((rc = SAPI.BufferSignEnd (hSes, ctxBuffSign, signature)) != 0)
            {
                SAPI.ContextRelease (ctxBuffSign);
                SAPI.Logoff (hSes);
                SAPI.HandleRelease (hSes);

                throw new Exception(string.Format(
                    "Failed to sign the data (#{0})", rc.ToString("X")));
            }

            //Write signature data to the stream
            byte[] tmpSig = (byte[])signature.ToArray();
            SignatureData.Write (tmpSig, 0, tmpSig.Length);

            //Cleanup memory
            SAPI.ContextRelease (ctxBuffSign);
            SAPI.Logoff (hSes);
            SAPI.HandleRelease (hSes);
        }


        public class SignatureDetails
        {
            public bool isValid { get; set; }
            public X509Certificate2 SignerCertificate {get; set;}

            public string SignerName {get; set;} 
            public string SignerEmail {get; set; }

            public long SignatureTimeTicks {get; set;}
        }


        public static SignatureDetails ValidateSignature (Stream SignedData, Stream Signature)
        {
            if (SignedData == null) throw new ArgumentNullException("SignedData");
            if (Signature == null) throw new ArgumentNullException ("Signature");

            //Make sure the SAPI Library is loaded
            SAPIInit();

            SignatureDetails SigDetails = new SignatureDetails();
            int rc;

            SAPICrypt SAPI = new SAPICrypt();

            SESHandle hSession = new SESHandle();
            if ((rc = SAPI.HandleAcquire(out hSession)) != 0)
            {
                throw new Exception(string.Format(
                    "Memory allocation error (#{0})", rc.ToString("X")));
            }

            //Extract Signer Data from the Signature stream
            //Read Signature content from stream to the SAPI bytes array
            Array baSignature = new byte[(int)Signature.Length];
            Signature.Read((byte[])baSignature, 0, (int)Signature.Length);
            SAPIByteArray sSignature = new SAPIByteArray();
            sSignature.FromArray(ref baSignature);

            //SAPIByteArray sSignedData = new SAPIByteArray();
            //Array t1 = (Array)SignedData; sSignedData.FromArray(ref t1);

            object Certificate;
            // Extract the signer's certificate from signature
            SAPI_ENUM_DATA_TYPE SAPIType = SAPI_ENUM_DATA_TYPE.SAPI_ENUM_DATA_TYPE_NONE;
            if ((rc = SAPI.PKCS7BlobGetValue(hSession, sSignature, SAPI_ENUM_PKCS7_FIELD.SAPI_ENUM_PKCS7_FIELD_CERT, out Certificate, ref SAPIType)) != 0)
            {
                SAPI.HandleRelease(hSession);
                throw new Exception(string.Format(
                    "An error occured while extracting the signer's certificate from the signature stream (#{0})", rc.ToString("X")));
            }
            
            SigDetails.SignerCertificate = new X509Certificate2((byte[])(((SAPIByteArray)Certificate).ToArray()));
            SigDetails.SignerName = SigDetails.SignerCertificate.GetNameInfo (X509NameType.SimpleName, false);
            SigDetails.SignerEmail = SigDetails.SignerCertificate.GetNameInfo (X509NameType.EmailName, false);

            //Run the signature validation process
            SAPIContext ctxValidateSignature = new SAPIContext();

            if ((rc = SAPI.BufferVerifySignatureInit (hSession,
                ctxValidateSignature, sSignature, 0)) != 0)
            {
                SAPI.HandleRelease(hSession);
                throw new Exception(string.Format(
                    "An error occured while initializing the signature validation process (#{0})", rc.ToString("X")));
            }

            int remaining = (int) SignedData.Length;
            int chunkMaxSize = 1 << 20; //1MB

            //Calculate first chunk size
            int chunkSize = remaining < chunkMaxSize ?
                remaining : chunkMaxSize;

            while (remaining > 0)
            {
                Array chunk = new byte[chunkSize]; //Read in chunks of 1MB
                int read = SignedData.Read((byte[])chunk, 0, chunkSize);
                if (read <= 0) throw new EndOfStreamException (String.Format("End of stream reached with {0} bytes left to read", remaining));

                //Build SAPI-Compatible byte array
                SAPIByteArray tmpBuff = new SAPIByteArray();
                tmpBuff.FromArray(ref chunk);

                //Add read buffer to the validation calculation
                if ((rc = SAPI.BufferVerifySignatureCont(hSession, ctxValidateSignature, tmpBuff)) != 0)
                {
                    SAPI.ContextRelease(ctxValidateSignature);
                    SAPI.HandleRelease(hSession);

                    throw new Exception(string.Format(
                        "An error occured while validating the digital signature (#{0})", rc.ToString("X")));
                }

                remaining -= read;
                chunkSize = Math.Min(remaining, chunkSize);
            }

            //Get the final validation result 
            SAPIFileTime signingTime = new SAPIFileTime();

            rc = SAPI.BufferVerifySignatureEnd(hSession, ctxValidateSignature, signingTime, new CertStatus());
            if ((uint)rc == 0x90030360)  //SAPI_SIGNATURE_NOT_VALID
            {
                SigDetails.isValid = false;
                SigDetails.SignatureTimeTicks = 0;
            }
            else if (rc == 0)
            {
                SigDetails.isValid  = true;

                //Convert FILE_TIME to ticks
                ulong filetime = signingTime.HighDateTime;
                filetime <<= 32;
                filetime += signingTime.LowDateTime;
                SigDetails.SignatureTimeTicks = DateTime.FromFileTimeUtc((long)filetime).Ticks;
            }
            else
            {
                SAPI.ContextRelease(ctxValidateSignature);
                SAPI.HandleRelease(hSession);

                throw new Exception(string.Format(
                    "Failed to validate Digital Signature (#{0})", rc.ToString("X")));
            }

            //Cleanup memory
            SAPI.ContextRelease(ctxValidateSignature);
            SAPI.HandleRelease(hSession);

            return SigDetails;
        }
    }
}
