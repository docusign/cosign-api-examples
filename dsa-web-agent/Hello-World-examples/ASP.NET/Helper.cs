using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace CSWA_Integration
{
    public class Helper
    {
        public const string SUCCESS = "0";
        public const string INPUT_XML_KEY = "inputXML";
        public const string PLACEHOLDER_CONTENT_TYPE = "#uploadedFileContentType#";
        public const string PLACEHOLDER_CONTENT = "#uploadedFileContent#";
        public const string PLACEHOLDER_DOCID = "#uploadedFileID#";

        // reading the sample hard-coded request XML from the file 'sampleRequestXML.xml'
        public static string SampleXML {get; private set;}
        public static string CSWAPath { get; private set; }

        static Helper()
        {
            SampleXML = readSampleXML(HttpContext.Current.Server.MapPath("~/sampleRequestXML.xml"));
            CSWAPath = ConfigurationManager.AppSettings["CSWAPath"];
        }

        private static string readSampleXML(string xmlPath)
        {
            string sampleXML;

            try
            {
                using (var sr = new StreamReader(xmlPath))
                {
                    sampleXML = sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
                sampleXML = null;
            }

            HttpRequest CREQ = HttpContext.Current.Request;
            string baseUrl = CREQ.Url.Scheme + "://" + CREQ.Url.Authority + CREQ.ApplicationPath.TrimEnd('/') + "/";
            string returnUrl = baseUrl + "retrieveSignedFile.aspx";
            XDocument doc = XDocument.Parse(sampleXML);
            foreach (XElement element in doc.Descendants().Where(
                    e => e.Name.ToString().ToLower().Contains("finishurl")))
            {
                element.Value = returnUrl;
            }

            sampleXML = doc.ToString();
            return sampleXML;
        }

        public static string getFileExtension(string i_MIMEType)
        {
            switch (i_MIMEType.ToLower())
            {
                case "application/msword":
                    return "doc";
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    return "docx";
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    return "xlsx";
                case "application/pdf":
                    return "pdf";
                default:
                    return null;
            }
        }

        public static string PostXML(string i_Url, string i_Content)
        {
            return SendRequest(i_Url, Encoding.UTF8.GetBytes(i_Content), "application/x-www-form-urlencoded", "POST");
        }

        public static string SendRequest(string i_Url, byte[] i_Content, string i_ContentType, string i_Method)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(i_Url);
            WebReq.Method = i_Method;
            if (i_Content != null)
            {
                WebReq.ContentType = i_ContentType;
                WebReq.ContentLength = i_Content.Length;
                Stream PostData = WebReq.GetRequestStream();
                PostData.Write(i_Content, 0, i_Content.Length);
                PostData.Close();
            }

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            string data = _Answer.ReadToEnd();
            _Answer.Close();
            WebResp.Close();
            return data;
        }

        // This function sends an http request to CSWA with the proper session ID.
        // On success - the file being saved on the server and the function returns the document path (URL).
        public static string pullDoc(string i_DocId, string i_SessionId)
        {
            string docPath = null;

            // Sending a GET request to pullSignedDoc.aspx page with the proper session ID
            string response = SendRequest(CSWAPath + "Sign/DownloadSignedFileG" + "?sessionId=" + i_SessionId, null, null, "GET");

            // If the request was handled successfully the response XML should include a success return code (0), the last signature details and the signed document.
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);
            string returnCode = xml.DocumentElement.GetElementsByTagName("returnCode")[0].InnerText;

            if (returnCode != SUCCESS)
            {
                throw new Exception("Pull doc error: " + xml.DocumentElement.GetElementsByTagName("errorMessage")[0].InnerText);
            }

            if (xml.DocumentElement.GetElementsByTagName("Document").Count > 0)
            {
                string base64EncodedFile = xml.DocumentElement.GetElementsByTagName("content")[0].InnerText;
                string contentType = xml.DocumentElement.GetElementsByTagName("contentType")[0].InnerText;
                docPath = i_DocId + "." + contentType;
                // Save the file on the server
                File.WriteAllBytes(HttpContext.Current.Server.MapPath("~/" + docPath), Convert.FromBase64String(base64EncodedFile));
            }

            return docPath;
        }
    }
}
