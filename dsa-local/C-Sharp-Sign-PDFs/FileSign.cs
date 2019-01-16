using System;
using SAPILib;

namespace CSPdfSign
{
	/// <summary>
	/// Summary description for FileSign.
	/// </summary>
	public class FileSign
	{
        public const int SAPI_ENUM_DRAWING_ELEMENT_GRAPHICAL_IMAGE = 0x00000001;
        public const int SAPI_ENUM_DRAWING_ELEMENT_SIGNED_BY = 0x00000002;
        public const int SAPI_ENUM_DRAWING_ELEMENT_REASON = 0x00000004;
        public const int SAPI_ENUM_DRAWING_ELEMENT_TIME = 0x00000008;

        public const int AR_PDF_FLAG_FIELD_NAME_SET = 0x00000080;

        public const int AR_GR_SIG_DATA_FORMAT_ALL = 0xFFFFFFF;
        public const uint SAPI_ERROR_NO_MORE_ITEMS = 0x90030103;

		public FileSign() {}

        //SAPIInit() should be called in the static constructor in order to make sure
        //that it's called only once, when the class is being initialized.
        static FileSign()
        {
            SAPICrypt SAPI = new SAPICrypt();
            int rc = SAPI.Init(); //SAPIInit() should be called once per process
            if (rc != 0) throw new Exception("Failed to initialize SAPI! (" + rc.ToString("X") + ")");
        }

        //Sign existing field in the file
        public static void SAPI_sign_file(string FileName, string FieldName, string User, string Password, string SignPassword, string Reason, string GraphImgName)
        {
            SAPI_sign_file(FileName, FieldName, User, Password, SignPassword, 0, 0, 0, 0, 0, default(bool), Reason, 0, string.Empty, GraphImgName); 
        }

        // This function is thread-safe and could be called by a few threads simoltaneously.
        // If FieldName parameter is NULL, a new field will be created, otherwise existing field will be signed
        // and all field-related parameters will be ignored
		public static void SAPI_sign_file(string FileName, string FieldName, string User, string Password, string SignPassword,
									int page, int x, int y, int height, int width,
                                    bool Invisible, string Reason, int AppearanceMask, string NewFieldName, string GraphImgName) 
        {
            int rc;
			SESHandle SesHandle;
            SigFieldHandle sf = null;

            SAPICrypt SAPI = new SAPICrypt();
			
            if ((rc = SAPI.HandleAcquire(out SesHandle)) != 0) throw new Exception("Failed in SAPIHandleAcquire() with rc = " + rc.ToString("X"));

            //Logon
            if ((rc = SAPI.Logon(SesHandle, User, null, Password)) != 0)
            {
                SAPI.HandleRelease(SesHandle);
                throw new Exception("Failed to authenticate user with rc = " + rc.ToString("X"));
            }

            //Set Graphical Image if required
            if (GraphImgName != null && GraphImgName.Length > 1)
            {
                SAPIContext ctxGraphImg = new SAPIContext();

                //Start Graphical Images Enumeration
                if ((rc = SAPI.GraphicSigImageEnumInit(SesHandle, ctxGraphImg, AR_GR_SIG_DATA_FORMAT_ALL, 0)) != 0)
                {
                    SAPI.Logoff(SesHandle);
                    SAPI.HandleRelease(SesHandle);
                    throw new Exception("Failed to enumerate graphical signatures with rc = " + rc.ToString());
                }

                GraphicImageHandle hGrImg = null;
                bool isFound = false;
                while (((uint)(rc = SAPI.GraphicSigImageEnumCont(SesHandle, ctxGraphImg, out hGrImg))) != SAPI_ERROR_NO_MORE_ITEMS)
                {
                    if (rc != 0)
                    {
                        SAPI.ContextRelease(ctxGraphImg);
                        SAPI.Logoff(SesHandle);
                        SAPI.HandleRelease(SesHandle);
                        throw new Exception("Failed to retrieve next graphical signature with rc = " + rc.ToString());
                    }

                    //Get Graphical Signature Info
                    GraphicImageInfo giInfo = null;
                    if ((rc = SAPI.GraphicSigImageInfoGet(SesHandle, hGrImg, out giInfo,
                        SAPI_ENUM_GRAPHIC_IMAGE_FORMAT.SAPI_ENUM_GRAPHIC_IMAGE_NONE, 0)) != 0)
                    {
                        SAPI.ContextRelease(ctxGraphImg);
                        SAPI.HandleRelease(hGrImg);
                        SAPI.Logoff(SesHandle);
                        SAPI.HandleRelease(SesHandle);
                        throw new Exception("Failed to retrieve graphical signature info with rc = " + rc.ToString());
                    }

                    //Check if required Graphical image has been found
                    if (giInfo.Name.Trim().ToLower() == GraphImgName.Trim().ToLower())
                    {
                        //If found - set is as default Graph. Image
                        if ((rc = SAPI.GraphicSigImageSetDefault(SesHandle, hGrImg)) != 0)
                        {
                            SAPI.ContextRelease(ctxGraphImg);
                            SAPI.HandleRelease(hGrImg);
                            SAPI.Logoff(SesHandle);
                            SAPI.HandleRelease(SesHandle);
                            throw new Exception("Failed to define default graphical signature with rc = " + rc.ToString());
                        }

                        isFound = true;
                        SAPI.ContextRelease(ctxGraphImg);
                        SAPI.HandleRelease(hGrImg);
                        break;
                    }

                    SAPI.HandleRelease(hGrImg);
                }

                SAPI.ContextRelease(ctxGraphImg);
                
                //If required Graph Image wasn't found...
                if (!isFound)
                {
                    SAPI.Logoff(SesHandle);
                    SAPI.HandleRelease(SesHandle);
                    throw new Exception("Failed to find Graphical Image with name: " + GraphImgName);
                }
            }

            //Create new signature field
            if (FieldName == null)
            {
                SigFieldSettings SFS = new SigFieldSettings();
                TimeFormat TF = new TimeFormat();
                int Flags = 0;

                //Define name of the new signature field
                if (NewFieldName.Length > 0)
                {
                    SFS.Name = NewFieldName;
                    Flags |= AR_PDF_FLAG_FIELD_NAME_SET;
                }

                if (Invisible)
                {
                    SFS.Invisible = 1;
                    SFS.Page = -1;
                }
                else
                {
                    // VISIBLE:
                    SFS.Invisible = 0;
                    // location:
                    SFS.Page = page;
                    SFS.X = x;
                    SFS.Y = y;
                    SFS.Height = height;
                    SFS.Width = width;
                    // appearance:
                    SFS.AppearanceMask = AppearanceMask;
                    SFS.LabelsMask = AppearanceMask;  
                    SFS.DependencyMode = SAPI_ENUM_DEPENDENCY_MODE.SAPI_ENUM_DEPENDENCY_MODE_INDEPENDENT;
                    SFS.SignatureType = SAPI_ENUM_SIGNATURE_TYPE.SAPI_ENUM_SIGNATURE_DIGITAL;
                    SFS.Flags = 0;
                    // time:
                    TF.DateFormat = "dd MMM yyyy";
                    TF.TimeFormat = "hh:mm:ss";
                    TF.ExtTimeFormat = SAPI_ENUM_EXTENDED_TIME_FORMAT.SAPI_ENUM_EXTENDED_TIME_FORMAT_NONE;
                    SFS.TimeFormat = TF;
                }

                //Create the Field
                if ((rc = SAPI.SignatureFieldCreate(SesHandle, SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_ADOBE,
                    FileName, SFS, Flags, out sf)) != 0)
                {
                    SAPI.Logoff(SesHandle);
                    SAPI.HandleRelease(SesHandle);
                    throw new Exception("Failed to create new signature field with rc = " + rc.ToString("X"));
                }

            }

            //Find an existing signature field by name
            else
            {
                SAPIContext ctxField = new SAPIContext();
                int NumOfFields = 0;

                //Initiate the Signature Fields enumeration process
                if ((rc = SAPI.SignatureFieldEnumInit(SesHandle, ctxField, SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_ADOBE,
                    FileName, 0, ref NumOfFields)) != 0)
                {
                    SAPI.Logoff(SesHandle);
                    SAPI.HandleRelease(SesHandle);
                    throw new Exception("Failed to start signature field enumeration with rc = " + rc.ToString("X"));
                }

                bool isFound = false;
                for (int i = 0; i < NumOfFields; i++)
                {
                    //Get Next field's handle
                    if ((rc = SAPI.SignatureFieldEnumCont(SesHandle, ctxField, out sf)) != 0)
                    {
                        SAPI.ContextRelease(ctxField);
                        SAPI.Logoff(SesHandle);
                        SAPI.HandleRelease(SesHandle);
                        throw new Exception("Failed in signature fields enumeration with rc = " + rc.ToString("X"));
                    }

                    //Retrieve Signature Field's info
                    SigFieldSettings sfs = new SigFieldSettings();
                    SigFieldInfo sfi = new SigFieldInfo();
                    if ((rc = SAPI.SignatureFieldInfoGet(SesHandle, sf, sfs, sfi)) != 0)
                    {
                        SAPI.HandleRelease(sf); 
                        SAPI.ContextRelease(ctxField);
                        SAPI.Logoff(SesHandle);
                        SAPI.HandleRelease(SesHandle);
                        throw new Exception("Failed to retrieve signature field details with rc = " + rc.ToString("X"));
                    }

                    //Check that the field we've found is not signed. If Signed - just skip it.
                    if (sfi.IsSigned != 0) continue;

                    if (sfs.Name == FieldName)
                    {
                        SAPI.ContextRelease(ctxField);
                        isFound = true;
                        break;
                    }

                    //Release handle of irrelevant signature field
                    SAPI.HandleRelease(sf);
                }

                if (!isFound)
                {
                    SAPI.ContextRelease(ctxField);
                    SAPI.Logoff(SesHandle);
                    SAPI.HandleRelease(SesHandle);
                    throw new Exception("The file doesn't contain any signature field named: " + FieldName);
                }
            }

            //Define the Reason
            if ((rc = SAPI.ConfigurationValueSet(SesHandle, SAPI_ENUM_CONF_ID.SAPI_ENUM_CONF_ID_REASON,
                SAPI_ENUM_DATA_TYPE.SAPI_ENUM_DATA_TYPE_STR, Reason, 1)) != 0)
            {
                SAPI.HandleRelease(sf);
                SAPI.Logoff(SesHandle);
                SAPI.HandleRelease(SesHandle);
                throw new Exception("Failed in SAPIConfigurationValueSet with rc = " + rc.ToString("X"));
            }

            if (string.IsNullOrEmpty(SignPassword))
            {
                //Prompt-for-sign mode is disabled
                rc = SAPI.SignatureFieldSign(SesHandle, sf, 0);
            }
            else
            {
                //Prompt-for-sign mode is enabled
                rc = SAPI.SignatureFieldSignEx(SesHandle, sf, 0, SignPassword);
            }
                
            if (rc != 0) 
            {
                SAPI.Logoff(SesHandle);
				SAPI.HandleRelease(sf);
				SAPI.HandleRelease(SesHandle);
                throw new Exception("Failed to Sign signature field with rc = " + rc.ToString("X"));
			}
			
            SAPI.Logoff(SesHandle);
			SAPI.HandleRelease(sf);
			SAPI.HandleRelease(SesHandle);
            return;
		}
	}
}
