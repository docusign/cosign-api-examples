using System;
using SAPILib;

namespace DOCXsample
{
    //DOCX Sigature Field class
    public class DOCXField
    {
        public SigFieldHandle hSigField;
        public SigFieldSettings sSettings;
        public SigFieldInfo sInfo;

        public override string ToString()
        {
            if (sSettings == null || sInfo == null) 
                return base.ToString();

            if (sInfo.IsSigned != 0)
                return sSettings.Name + " - SIGNED";
            else
                return sSettings.Name + " - NOT SIGNED";
        }

        //Constructor
        public DOCXField()
        {
            sSettings = new SigFieldSettingsClass();
            sInfo = new SigFieldInfoClass();
        }

        //Destructor
        ~DOCXField()
        {
            SAPIWrapper.SAPI.HandleRelease(hSigField);
        }
    }


    //SAPI Functions
    public static class SAPIWrapper
    {
        public static SAPICrypt SAPI;
        public static SESHandle hSession;

        //Static Constructor
        static SAPIWrapper()
        {
            try
            {
                SAPI = new SAPICrypt();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("SAPI is not installed");
                System.Windows.Forms.Application.Exit();
            }

            int rc = SAPI.Init();
            if (rc != 0)
            {
                System.Windows.Forms.MessageBox.Show("Failed to initialize SAPI (" + rc.ToString("X") + ")");
                System.Windows.Forms.Application.Exit();
            }

            rc = SAPI.HandleAcquire(out hSession);
            if (rc != 0)
            {
                System.Windows.Forms.MessageBox.Show("Failed in SAPIHandleAcquire (" + rc.ToString("X") + ")");
                System.Windows.Forms.Application.Exit();
            }
        }

        //SAPILogon
        public static void Logon (string Username, string Domain, string Password)
        {
            int rc;
            rc = SAPI.Logon(hSession, Username, Domain, Password);
            if (rc != 0) throw new Exception("Failed in Login (" + rc.ToString("X") + ")");
        }

        //SAPILogoff
        public static void Logoff()
        {
            int rc;
            rc = SAPI.Logoff(hSession);
            if (rc != 0) throw new Exception("Failed in Logoff (" + rc.ToString("X") + ")");
        }


        public static DOCXField[] GetSignatureFields(string DocxFile)
        {
            int rc;
            int NumOfFields = 0;

            SAPIContext ctxSigField = new SAPIContext();

            rc = SAPI.SignatureFieldEnumInit(
                hSession,
                ctxSigField,
                SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_OFFICE_XML_PACKAGE,
                DocxFile,
                0,
                ref NumOfFields);

            if (rc != 0) throw new Exception("Failed in SAPISignatureFieldEnumInit (" + rc.ToString("X") + ")");

            //There are no signature fields
            if (NumOfFields == 0) return null;

            DOCXField[] Fields = new DOCXField[NumOfFields];

            for (int i = 0; i < NumOfFields; i++)
            {
                Fields[i] = new DOCXField();

                //Get Signature Field Handle
                rc = SAPI.SignatureFieldEnumCont(hSession, ctxSigField, out Fields[i].hSigField);
                if (rc != 0) throw new Exception("Failed in SignatureFieldEnumCont (" + rc.ToString("X") + ")");

                //Get Signature Field Details
                rc = SAPI.SignatureFieldInfoGet(
                    hSession,
                    Fields[i].hSigField,
                    Fields[i].sSettings,
                    Fields[i].sInfo);

                if (rc != 0) throw new Exception("Failed in SignatureFieldInfoGet (" + rc.ToString("X") + ")");
            }

            SAPI.ContextRelease(ctxSigField);

            return Fields;
        }

        public static void SignField(DOCXField Field)
        {
            int rc = SAPI.SignatureFieldSign(hSession, Field.hSigField, 0);
            if (rc != 0) throw new Exception("Failed in SignatureFieldSign (" + rc.ToString("X") + ")");
        }
    }
}
