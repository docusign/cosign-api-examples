using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPILib;
using System.IO;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SAPI_OK = 0;

            int rc;
            SAPICrypt SAPI = new SAPICryptClass();
            SESHandle sesHandle = null;

            // Custom Values
            string  filePath            = @"c:\temp\demo.pdf";  // PDF file to sign
            string  username            = "{signer_username}";  // CoSign account username
            string  password            = "{signer_password}";  // CoSign account password
            string  domain              = null;                 // CoSign account domain
            int     sigPageNum		    = 1;				    // Create signature on the first page
	        int     sigX				= 145;					// Signature field X location
	        int     sigY				= 125;					// Signature field Y location
	        int     sigWidth			= 160;					// Signature field width
	        int     sigHeight			= 45;					// Signature field height
	        string  timeFormat			= "hh:mm:ss";			// Time appearance format mask
	        string  dateFormat			= "dd/MM/yyyy";			// Date appearance format mask
	        int     appearanceMask		= (int) SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_GRAPHICAL_IMAGE |	// Elements to display on the signature field
                                          (int) SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_SIGNED_BY |
                                          (int) SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_TIME;

            try
            {
                // Initialize SAPI library
                if ((rc = SAPI.Init()) != SAPI_OK)
                {
                    throw new Exception(string.Format("Failed to initialize SAPI ({0})", rc.ToString("X")));
                }

                // Acquire SAPI session handle
                if ((rc = SAPI.HandleAcquire(out sesHandle)) != SAPI_OK)
                {
                    throw new Exception(string.Format("Failed in SAPIHandleAcquire() ({0})", rc.ToString("X")));
                }

                // Personalize SAPI Session
                if ((rc = SAPI.Logon(sesHandle, username, domain, password)) != SAPI_OK)
                {
                    throw new Exception(string.Format("Failed to authenticate user ({0})", rc.ToString("X")));
                }

                SigFieldSettingsClass SFS = new SigFieldSettingsClass();
                TimeFormatClass TF = new TimeFormatClass();

                // Define signature field settings
                SFS.Page            = sigPageNum;
                SFS.X               = sigX;
                SFS.Y               = sigY;
                SFS.Width           = sigWidth;
                SFS.Height          = sigHeight;
                SFS.AppearanceMask  = appearanceMask;
                SFS.SignatureType   = SAPI_ENUM_SIGNATURE_TYPE.SAPI_ENUM_SIGNATURE_DIGITAL;
                SFS.DependencyMode  = SAPI_ENUM_DEPENDENCY_MODE.SAPI_ENUM_DEPENDENCY_MODE_INDEPENDENT;
                TF.DateFormat       = dateFormat;
                TF.TimeFormat       = timeFormat;
                TF.ExtTimeFormat    = SAPI_ENUM_EXTENDED_TIME_FORMAT.SAPI_ENUM_EXTENDED_TIME_FORMAT_GMT; // Display GMT offset
                SFS.TimeFormat      = TF;

                // Create and sign a new signature field in the document
                if (SAPI_OK != (rc = SAPI.SignatureFieldCreateSign(
                    sesHandle,                                  // Session Handle
                    SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_ADOBE,   // Type of the file to sign - PDF
                    filePath,                                   // Path to PDF file to sign
                    SFS,                                        // Signature Field details
                    0,                                          // Flags
                    null)))                                     // Credentials (only if prompt-for-sign feature is enabled)
                {
                    throw new Exception(string.Format("Failed in SAPISignatureFieldCreateSign() ({0})", rc.ToString("X")));
                }

                Console.WriteLine("The document has been successfully signed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sesHandle != null)
                {
                    SAPI.Logoff(sesHandle);         // Release user context
                    SAPI.HandleRelease(sesHandle);  // Release session handle
                }
            }
        }
    }
}
