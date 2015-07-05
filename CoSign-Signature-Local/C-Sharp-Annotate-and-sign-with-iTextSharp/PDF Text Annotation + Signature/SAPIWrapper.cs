using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPILib;

namespace PDF_Annotation_Signature
{
    public class SAPIWrapper
    {
        public static void SignPDF(
            string filePath,
            string username,
            string domain,
            string password,
            int sigPageNum,
            int sigX,
            int sigY,
            int sigWidth,
            int sigHeight,
            string title)
        {
            const int SAPI_OK = 0;
            const int AR_PDF_FLAG_FILESIGN_VERTICAL = 0x00000020;

            int rc;
            SAPICrypt SAPI = new SAPICryptClass();
            SESHandle sesHandle = null;
            GraphicImageHandle grpImgHandle = null;

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

                // If the user has more than one graphical signatures, this function opens a new dialog window enabling the user to view and select an image with which to sign.
                if ((rc = SAPI.GraphicSigImageGUISelect(sesHandle, (int)0xFF, 0, SAPI_ENUM_GR_IMG_SELECT_MODE.SAPI_ENUM_GR_IMG_SEL_MODE_SELECT, out grpImgHandle)) != SAPI_OK)
                {
                    throw new Exception(string.Format("Failed in SAPIGraphicSigImageGUISelect() ({0})", rc.ToString("X")));
                }

                // Set the graphical image associated with the graphic image handle as the default graphic signature image
                if ((rc = SAPI.GraphicSigImageSetDefaultEx(sesHandle, grpImgHandle, 0)) != SAPI_OK)
                {
                    throw new Exception(string.Format("Failed in SAPIGraphicSigImageSetDefaultEx() ({0})", rc.ToString("X")));
                }

                SigFieldSettingsClass SFS = new SigFieldSettingsClass();
                TimeFormatClass TF = new TimeFormatClass();

                // Define signature field settings
                SFS.Page = sigPageNum;
                SFS.X = sigX;
                SFS.Y = sigY;
                SFS.Width = sigWidth;
                SFS.Height = sigHeight;
                SFS.AppearanceMask = (int)SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_GRAPHICAL_IMAGE |
                                     (int)SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_SIGNED_BY |
                                     (int)SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_TIME;
                SFS.SignatureType = SAPI_ENUM_SIGNATURE_TYPE.SAPI_ENUM_SIGNATURE_DIGITAL;
                SFS.DependencyMode = SAPI_ENUM_DEPENDENCY_MODE.SAPI_ENUM_DEPENDENCY_MODE_INDEPENDENT;
                TF.DateFormat = "dd/MM/yyyy";
                TF.TimeFormat = "hh:mm:ss";
                TF.ExtTimeFormat = SAPI_ENUM_EXTENDED_TIME_FORMAT.SAPI_ENUM_EXTENDED_TIME_FORMAT_GMT; // Display GMT offset
                SFS.TimeFormat = TF;

                if (!string.IsNullOrEmpty(title))
                {
                    // Set signer's title
                    if ((rc = SAPI.ConfigurationValueSet(sesHandle, SAPI_ENUM_CONF_ID.SAPI_ENUM_CONF_ID_TITLE, SAPI_ENUM_DATA_TYPE.SAPI_ENUM_DATA_TYPE_WSTR, title, 1)) != SAPI_OK)
                    {
                        throw new Exception(string.Format("Failed in SAPIConfigurationValueSet() ({0})", rc.ToString("X")));
                    }

                    SFS.AppearanceMask |= (int)SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_TITLE;
                }

                // Create and sign a new signature field in the document
                if (SAPI_OK != (rc = SAPI.SignatureFieldCreateSign(sesHandle, SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_ADOBE, filePath, SFS, AR_PDF_FLAG_FILESIGN_VERTICAL, null)))
                {
                    throw new Exception(string.Format("Failed in SAPISignatureFieldCreateSign() ({0})", rc.ToString("X")));
                }
            }
            catch (Exception ex)
            {
                if (sesHandle != null)
                {
                    SAPI.Logoff(sesHandle);         // Release user context
                    SAPI.HandleRelease(sesHandle);  // Release session handle
                }

                if (grpImgHandle != null)
                {
                    SAPI.HandleRelease(grpImgHandle);
                }

                throw ex;
            }
        }
    }
}
