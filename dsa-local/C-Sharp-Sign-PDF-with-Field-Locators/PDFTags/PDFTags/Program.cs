/*
 The following code sample demonstrates how to create and sign signature fields according to predefined field locators embedded in a PDF file.
*/

using System;
using System.IO;
using SAPILib;

namespace PDFTags
{
    class Program
    {
        public const int AR_PDF_FLAG_FIELD_NAME_SET = 0x00000080;

        static void Main(string[] args)
        {
            string InFileName = "C:\\temp\\tag-sample.pdf";
            string OutFileName = "C:\\temp\\tag-sample-signed.pdf";
            string startDelim = "<<";
            string endDelim = ">>";
            int rc;
            SESHandle SesHandle;
            SigFieldSettings SFS = new SigFieldSettings();
            TimeFormat TF = new TimeFormat();
            int Flags = AR_PDF_FLAG_FIELD_NAME_SET;
            int LocNumber;

            SAPICrypt SAPI = new SAPICrypt();

            // SAPIInit() should be called once per process
            if ((rc = SAPI.Init()) != 0) throw new Exception("Failed to initialize SAPI! (" + rc.ToString("X") + ")");

            // Open a new SAPI context
            if ((rc = SAPI.HandleAcquire(out SesHandle)) != 0) throw new Exception("Failed in SAPIHandleAcquire() with rc = " + rc.ToString("X"));

            if ((rc = SAPI.Logon(SesHandle, "{DSA User}", null, "{DSA User password}")) != 0)
            {
                SAPI.HandleRelease(SesHandle);
                throw new Exception("Failed in SAPILogon() with rc = " + rc.ToString("X"));
            }

            //
            // Locate all field tags in the PDF
            // The PDF filename to be used is defined above. 
            // The format of each field locator in the PDF should be:
            //   << w={width}; h={height}; n={field name}; a={appearance mask} >>
            //  
            // For example: 
            //  << w=120; h=80; n=Signer1; a=15; >>
            //
            SAPIContext SigLocatorCtx = new SAPIContext();

            Array fileBytes = File.ReadAllBytes(InFileName);
            SAPIByteArray doc = new SAPIByteArray();
            doc.FromArray(ref fileBytes);
            FileHandle fh;
            if ((rc = SAPI.CreateFileHandleByMem(out fh, SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_ADOBE, 0, doc)) != 0)
            {
                SAPI.HandleRelease(SesHandle);
                throw new Exception("Failed to create file handle with rc = " + rc.ToString("X"));
            }

            //  Initiate a new Field Locator enumerator.
            //  The argument LocNumber will contain the number of signature tags found in the PDF document.
            //
            if ((rc = SAPI.SignatureFieldLocatorEnumInit(SesHandle, SigLocatorCtx, fh, startDelim, endDelim, 0, out LocNumber)) != 0)
            {
                SAPI.HandleRelease(fh);
                SAPI.HandleRelease(SesHandle);
                throw new Exception("LocatorEnumInit failed with rc = " + rc.ToString("X"));
            }
            
            // Do for all tags in the document
            string strEncMsg;
            for (int i = 0; i < LocNumber; i++)
            {
                // Get settings for the next field locator.
                // (Use strEncMsg string to parse the field locator content if a custom string format has been used)
                if ((rc = SAPI.SignatureFieldLocatorEnumCont(SesHandle, SigLocatorCtx, SFS, out strEncMsg)) != 0)
                {
                    SAPI.ContextRelease(SigLocatorCtx);
                    SAPI.HandleRelease(fh);
                    SAPI.HandleRelease(SesHandle);
                    throw new Exception("LocatorEnumCont failed with rc = " + rc.ToString("X"));
                }

                // The following values of the SignatureFieldSettings will be automatically set by SAPI:
                //   X/Y Location (including page number)
                //   Width
                //   Height
                //   Field Name
                //   Appearance Mask
                //
                SFS.LabelsMask = 0;
                SFS.DependencyMode = SAPI_ENUM_DEPENDENCY_MODE.SAPI_ENUM_DEPENDENCY_MODE_INDEPENDENT;
                SFS.SignatureType = SAPI_ENUM_SIGNATURE_TYPE.SAPI_ENUM_SIGNATURE_DIGITAL;
                SFS.Flags = 0;

                // time:
                TF.DateFormat = "dd MMM yyyy";
                TF.TimeFormat = "hh:mm:ss";
                TF.ExtTimeFormat = SAPI_ENUM_EXTENDED_TIME_FORMAT.SAPI_ENUM_EXTENDED_TIME_FORMAT_NONE;
                SFS.TimeFormat = TF;

                //  Now create the signature field on the PDF
                //  We make use of SignatureFieldCreateEx function in order to pass the FileHandle for the in-memory
                //  file rather than a UNC file path.
                if ((rc = SAPI.SignatureFieldCreateSignEx2(SesHandle, SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_ADOBE,
                    "", fh, SFS, Flags, null)) != 0)
                {
                    SAPI.ContextRelease(SigLocatorCtx);
                    SAPI.HandleRelease(fh);
                    SAPI.HandleRelease(SesHandle);
                    throw new Exception("Failed to create new signature field with rc = " + rc.ToString("X"));
                }
            }

            //  Write the PDF to an output file
            if ((rc = SAPI.GetFileMemData(fh, 0, doc)) != 0)
            {
                SAPI.ContextRelease(SigLocatorCtx);
                SAPI.HandleRelease(fh);
                SAPI.HandleRelease(SesHandle);
                throw new Exception("Failed to GetFileMem with rc = " + rc.ToString("X"));
            }

            File.WriteAllBytes(OutFileName, (byte[])doc.ToArray());

            //  Finalize work with SAPI
            SAPI.ContextRelease(SigLocatorCtx);
            SAPI.HandleRelease(fh);
            SAPI.HandleRelease(SesHandle);
        }
    }
}
