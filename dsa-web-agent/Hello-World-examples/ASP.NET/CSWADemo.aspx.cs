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
using System.Xml;
using System.IO;

namespace CSWA_Integration
{
    public partial class CSWADemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CSWAConnectButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "";

            // In this demo we use a sample PDF file located in the root project folder
            string fileExtension = "pdf";
            byte[] fileContent = File.ReadAllBytes(Server.MapPath("~/demo.pdf"));

            // Convert file bytes to Base64String
            string base64Doc = Convert.ToBase64String(fileContent);

            // Here we use a predefined sample XML. Usually will be built dynamically according to specific needs.
            string inputXML = Helper.SampleXML;

            if (string.IsNullOrEmpty(inputXML))
            {
                StatusLabel.Text = "Sample request XML error";
                return;
            }

            // We have placed placeholders in the sample XML for the file content, file extension and the doc ID
            // Now we replace those placeholders with the proper data considering the chosen file.
            inputXML = inputXML.Replace(Helper.PLACEHOLDER_CONTENT_TYPE, fileExtension);
            inputXML = inputXML.Replace(Helper.PLACEHOLDER_CONTENT, base64Doc);
            inputXML = inputXML.Replace(Helper.PLACEHOLDER_DOCID, (new Random()).Next(10000, 30000).ToString()); // Generating random number to be used as doc ID.

            // Sending a POST request to UploadDoc.aspx page with the XML (the parameter name is "inputXML")
            string response = Helper.PostXML(Helper.CSWAPath + "Sign/UploadFileToSign", Helper.INPUT_XML_KEY + "=" + Server.UrlEncode(inputXML));

            // The received response is in the form of XML as well.
            // If the request was handled successfully the response should include a success return code (0) and CSWA session ID
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            string returnCode = xml.DocumentElement.GetElementsByTagName("returnCode")[0].InnerText.Trim();
            string sessionID = null;
            if (xml.DocumentElement.GetElementsByTagName("sessionId").Count > 0)
            {
                sessionID = xml.DocumentElement.GetElementsByTagName("sessionId")[0].InnerText.Trim();
            }

            // If the return code is 0 and the session ID has returned in the response, we can now call the UploadDoc.aspx with the sessionID parameter as below
            // In this example we set the "src" attribute of the IFrame with that URL.
            if (returnCode == Helper.SUCCESS && !string.IsNullOrEmpty(sessionID))
            {
                CSWAIFrame.Attributes["src"] = Helper.CSWAPath + "Sign/Signceremony" + "?sessionId=" + sessionID;
            }
        }
    }
}
