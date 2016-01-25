using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace CSWA_Integration
{
    public partial class retrieveSignedFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // When retrieveSignedFile.aspx is called by CSWA, it can be of the following reasons:
            // 1. An error was returned - in this case only, returnCode param will not be null
            // 3. A file was signed and is waiting to be 'pulled'

            string docId = Request.QueryString["docId"];
            string sessionId = Request.QueryString["sessionId"];
            string retVal = "-1";

            try
            {
                if (!string.IsNullOrEmpty(docId))
                {
                    retVal = Request.QueryString["returnCode"];
                    if (retVal != null && retVal != "0")
                    {
                        // An error was recieved
                        handleError(retVal, Request.QueryString["errorMessage"]);
                    }
                    else if (!string.IsNullOrEmpty(sessionId))
                    {
                        // A document was signed and needs to be handled
                        string fileName = Helper.pullDoc(docId, sessionId);

                        linkToDoc.InnerText = fileName;
                        linkToDoc.HRef = fileName;
                        LabelResultMessage.Text = "The document has been successfully signed";
                    }
                    else
                    {
                        // Empty Request (no sessionId parameter)
                        handleError(retVal, "Missing parameters");
                    }
                }
                else
                {
                    // Empty Request (no docId parameter)
                    handleError(retVal, "Missing parameters");
                }
            }
            catch (Exception ex)
            {
                handleError(retVal, ex.Message);
            }
        }

        private void handleError(string errorCode, string errorMsg)
        {
            if ("-2".Equals(errorCode))
            {
                LabelResultMessage.Text = "Signing was canceled";
                LabelResultMessage.Style["color"] = "black";
            }
            else if ("-3".Equals(errorCode))
            {
                LabelResultMessage.Text = "Signing was rejected";
                LabelResultMessage.Style["color"] = "black";
            }
            else
            {
                LabelResultMessage.Text = "Error: " + errorMsg;
                LabelResultMessage.Style["color"] = "red";
            }

            signedDocLine.Visible = false;
        }
    }
}
