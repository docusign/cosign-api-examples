using RestSharp;
using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DSARestCsharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            String baseURL = "https://prime-dsa-devctr.docusign.net:8081";
            String resourcePath = "sapiws/v1/digital_signature";
            String apiUrl = baseURL + "/" + resourcePath;
            var client = new RestClient(apiUrl);

            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Basic " + DSABasicAuthorizationString("{dsa-user-name}", "{dsa-user-password}"));
            // "digital_signature" request body as Json formated String (use JavaScriptSerializer or Newtonsoft.Json to build from object) 
            String DigSigRequestBody =  
                "{ \"CreateAndSignField\" : " + //structure name specifies the operation / function
                    "{   \"file\": " + "\"" + File2Base64String("c:\\tmp\\PurchaseOrder.pdf") + "\", " +
                        "\"fileType\": \"PDF\", " +
                        "\"x\": \"91\", " +
                        "\"y\": \"164\", " +
                        "\"width\": \"113\", " +
                        "\"height\": \"38\", " +
                        "\"page\": \"1\", " +
                        "\"timeFormat\": \"h:mm:ss\", " +
                        "\"dateFormat\": \"dd/MM/yyyy\", " +
                        "\"appearance\": [\"GRAPHICAL_IMAGE\", \"SIGNED_BY\", \"TIME\"]" +
                    "}" +
                "}";
            request.AddParameter("application/json", DigSigRequestBody, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            JObject joResponse = JObject.Parse(response.Content);

            Base64String2Path(joResponse["signedFile"].Value<string>(), "c:\\tmp\\PurchaseOrder.DSA-REST-SIGNED.pdf");
        }

        private static void Base64String2Path(string Base64String, string FilePath)
        {
            Byte[] bytes = Convert.FromBase64String(Base64String);
            File.WriteAllBytes(FilePath, bytes);
        }

        private static String File2Base64String(String FilePath)
        {
            Byte[] bytes = File.ReadAllBytes(FilePath);
            String fileB64Data = System.Convert.ToBase64String(bytes);
            return fileB64Data;
        }

        private static String DSABasicAuthorizationString(String username, string password)
        {
            var DSABasicAuthorizationBytes = System.Text.Encoding.UTF8.GetBytes(username+":"+password);
            return System.Convert.ToBase64String(DSABasicAuthorizationBytes);
        }
    }
}
