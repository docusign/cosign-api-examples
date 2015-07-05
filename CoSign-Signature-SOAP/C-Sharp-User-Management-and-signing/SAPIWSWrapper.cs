using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using SAPIWS_Sample.com.cosigntrial.prime;

namespace SAPIWS_Sample
{
    class SAPIWSWrapper
    {
        //ReadFile: Read file to the Bytes Buffer
        public byte[] ReadFile(string FileToRead, bool isDisplayErrorsGUI)
        {
            byte[] Buf = null;
            
            try
            {
                FileStream f = File.OpenRead (FileToRead);
                Buf = new byte[f.Length];
                f.Read (Buf, 0, (int)f.Length);
                f.Close();
            }
            catch (Exception ex)
            {
                if (isDisplayErrorsGUI)
                    MessageBox.Show("Error reading the input file.\n\nException:\n" + ex.Message, "Error");
                return null;
            }

            return Buf;
        }


        //PDFAttachSignature: Append the signature block to the PDF file 
        public bool PDFAttachSignature(string PDFFile, byte[] Signature, bool isDisplayErrorsGUI)
        {
            if (Signature == null) return false;
            try
            {
                FileStream f = File.OpenWrite(PDFFile);
                f.Position = f.Length;  //seek to the end of file
                f.Write(Signature, 0, Signature.Length); //write the signature content
                f.Close();
            }
            catch (Exception ex)
            {
                if (isDisplayErrorsGUI)
                    MessageBox.Show("Error Attaching the signature\n\nException:\n" + ex.Message, "Error");
                return false;
            }
            
            return true;
        }



        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //List of SignatureType operation codes for DssSign service:

        //Sign Binary Buffer and get detached PKCS7 signature blob
        const string  SignatureTypePKCS7Detached = "urn:ietf:rfc:3369";

        //Sign an existing Signature Field
        const string SignatureTypeFieldSign = "http://arx.com/SAPIWS/DSS/1.0/signature-field-sign";

        //Create new signature field and sign it
        const string SignatureTypeFieldCreateSign = "http://arx.com/SAPIWS/DSS/1.0/signature-field-create-sign";

        //Create new unsigned signature field
        const string SignatureTypeFieldCreate = "http://arx.com/SAPIWS/DSS/1.0/signature-field-create";

        //Clear signature from an existing signed signature field
        const string SignatureTypeFieldClear = "http://arx.com/SAPIWS/DSS/1.0/signature-field-clear";

        //Delete an existing unsigned signature field
        const string SignatureTypeFieldRemove = "http://arx.com/SAPIWS/DSS/1.0/signature-field-remove";

        //Change Password
        const string SignatureTypeChangePassword = "http://arx.com/SAPIWS/DSS/1.0/change-password";

        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        //List of SignatureType opcodes for DssVerify service:
    
        //Verify validity of the signed signature field - This operation can be also performed using Adobe Reader application
        const string SignatureTypeFieldVerify = "http://arx.com/SAPIWS/DSS/1.0/signature-field-verify";

        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        //Return Code for success operation
         const string Success = "urn:oasis:names:tc:dss:1.0:resultmajor:Success";

        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        //Sign PDF file
        public bool SignPDFFile(
            string FileToSign,
            string UserName,
            string Password,
            int X,
            int Y,
            int Width,
            int Height,
            int Page,
            bool isVisible)
        {

            //Create Request object contains signature parameters
            RequestBaseType Req = new RequestBaseType();
            Req.OptionalInputs = new RequestBaseTypeOptionalInputs();

            //Here Operation Type is set: Verify/Create Signature Field/Sign/etc
            Req.OptionalInputs.SignatureType = SignatureTypeFieldCreateSign;

            //Configure Create and Sign operation parameters:
            Req.OptionalInputs.ClaimedIdentity = new ClaimedIdentity();
            Req.OptionalInputs.ClaimedIdentity.Name = new NameIdentifierType();
            Req.OptionalInputs.ClaimedIdentity.Name.Value = UserName;                       //User Name
            Req.OptionalInputs.ClaimedIdentity.Name.NameQualifier = " ";                    //Domain (relevant for Active Directory environment only)
            Req.OptionalInputs.ClaimedIdentity.SupportingInfo = new CoSignAuthDataType();
            Req.OptionalInputs.ClaimedIdentity.SupportingInfo.LogonPassword = Password;     //User Password
            Req.OptionalInputs.SAPISigFieldSettings = new SAPISigFieldSettingsType();
            Req.OptionalInputs.SAPISigFieldSettings.X = X;                                  //Signature Field X coordinate
            Req.OptionalInputs.SAPISigFieldSettings.XSpecified = true;
            Req.OptionalInputs.SAPISigFieldSettings.Y = Y;                                 //Signature Field Y coordinate
            Req.OptionalInputs.SAPISigFieldSettings.YSpecified = true;
            Req.OptionalInputs.SAPISigFieldSettings.Page = Page;                            //Page number the signature field will appear on
            Req.OptionalInputs.SAPISigFieldSettings.PageSpecified = true; 
            Req.OptionalInputs.SAPISigFieldSettings.Width = Width;                          //Signature Field width
            Req.OptionalInputs.SAPISigFieldSettings.WidthSpecified = true;
            Req.OptionalInputs.SAPISigFieldSettings.Height = Height;                        //Signature Field Height
            Req.OptionalInputs.SAPISigFieldSettings.HeightSpecified = true;
            Req.OptionalInputs.SAPISigFieldSettings.Invisible = !isVisible;                 //Specifies whether the signature will be visible or not
            Req.OptionalInputs.SAPISigFieldSettings.InvisibleSpecified = true;


            // Set configuration parameters /////////////////////////////////////////////////////////
            int numConfigurationParams = 6;
            Req.OptionalInputs.ConfigurationValues = new ConfValueType[numConfigurationParams];
            for (int i = 0; i < numConfigurationParams; i++)
            {
                Req.OptionalInputs.ConfigurationValues[i] = new ConfValueType();
            }
            
            // Add reason
            Req.OptionalInputs.ConfigurationValues[0].ConfValueID = ConfIDEnum.Reason;
            Req.OptionalInputs.ConfigurationValues[0].Item = "I am the author of this document";

            // Add TSA:
            /*
            Req.OptionalInputs.ConfigurationValues[1].ConfValueID = ConfIDEnum.UseTimestamp;
            Req.OptionalInputs.ConfigurationValues[1].Item = 1;

            Req.OptionalInputs.ConfigurationValues[2].ConfValueID = ConfIDEnum.TimestampURL;
            Req.OptionalInputs.ConfigurationValues[2].Item = "http://www.ca-soft.com/request.aspx";

            Req.OptionalInputs.ConfigurationValues[3].ConfValueID = ConfIDEnum.TimestampAdditionalBytes;
            Req.OptionalInputs.ConfigurationValues[3].Item = 4000;
            
            Req.OptionalInputs.ConfigurationValues[4].ConfValueID = ConfIDEnum.TimestampUser;
            Req.OptionalInputs.ConfigurationValues[4].Item = "";

            Req.OptionalInputs.ConfigurationValues[5].ConfValueID = ConfIDEnum.TimestampPWD;
            Req.OptionalInputs.ConfigurationValues[5].Item = "";

            // OCSP (NOTE: Server must contain comodo CA in order to use the following OCSP URL)
             Req.OptionalInputs.ConfigurationValues[4].ConfValueID = ConfIDEnum.UseOCSP;
             Req.OptionalInputs.ConfigurationValues[4].Item = 1;

             Req.OptionalInputs.ConfigurationValues[5].ConfValueID = ConfIDEnum.OCSPURL;
             Req.OptionalInputs.ConfigurationValues[5].Item = "ocsp.comodoca.com";
            */
            // End setting configuration parameters ////////////////////////////////////////////////

            //Set Session ID
            Req.RequestID = Guid.NewGuid().ToString();

            //Prepare the Data to be signed
            DocumentType doc1 = new DocumentType();
            DocumentTypeBase64Data b64data = new DocumentTypeBase64Data();
            Req.InputDocuments = new RequestBaseTypeInputDocuments();
            Req.InputDocuments.Items = new object[1];

            b64data.MimeType = "application/pdf";     //Can also be: application/msword, image/tiff, pplication/octet-string (ocsp/tsa are supported in PDF only)
            Req.OptionalInputs.ReturnPDFTailOnlySpecified = true;
            Req.OptionalInputs.ReturnPDFTailOnly = true;
            b64data.Value = ReadFile(FileToSign, true); //Read the file to the Bytes Array

            doc1.Item = b64data;
            Req.InputDocuments.Items[0] = doc1;

            //Call sign service
            ResponseBaseType Resp = null;

            try
            {
                // Create the Web Service client object
                DSS service = new DSS();
                service.Url = "https://prime.cosigntrial.com:8080/SAPIWS/dss.asmx";  //This url is constant and shouldn't be changed

                SignRequest sreq = new SignRequest();
                sreq.InputDocuments = Req.InputDocuments;
                sreq.OptionalInputs = Req.OptionalInputs;

                //Perform Signature operation
                Resp = service.DssSign(sreq);

                if (Resp.Result.ResultMajor != Success ) 
                {
                    MessageBox.Show("Error: " + Resp.Result.ResultMajor + " " + 
                                                Resp.Result.ResultMinor + " " + 
                                                Resp.Result.ResultMessage.Value, "Error");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                if (ex is WebException)
                {
                    WebException we = ex as WebException;
                    WebResponse webResponse = we.Response;
                    if (webResponse != null)
                        MessageBox.Show(we.Response.ToString(), "Web Response");
                }
                return false;
            }


            //Handle Reply
            DssSignResult sResp = (DssSignResult) Resp;



            //object sig = sResp.SignatureObject.Item;
            //SignatureObjectTypeBase64Signature sig = (SignatureObjectTypeBase64Signature) sResp.SignatureObject.Item;
           DssSignResultSignatureObjectBase64Signature sig = (DssSignResultSignatureObjectBase64Signature)sResp.SignatureObject.Item;

           byte[] signature = sig.Value;
            
            return PDFAttachSignature(FileToSign, signature, true); //Attach Signature to the PDF file 
        }

    }
}
