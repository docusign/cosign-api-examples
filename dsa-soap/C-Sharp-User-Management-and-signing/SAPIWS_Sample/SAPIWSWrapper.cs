using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using SAPIWS_Sample.com.arx.cosigndemo;

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
                FileStream f = File.OpenRead(FileToRead);
                Buf = new byte[f.Length];
                f.Read(Buf, 0, (int)f.Length);
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

        //PDFReWrite: Write the Signed PDF back to file 
        public bool PDFReWrite(string PDFFile, byte[] SignedPDFBytes, bool isDisplayErrorsGUI)
        {
            if (SignedPDFBytes == null) return false;
            try
            {
                FileStream f = File.OpenWrite(PDFFile);
                f.Write(SignedPDFBytes, 0, SignedPDFBytes.Length); //write the PDF contents
                f.Close();
            }
            catch (Exception ex)
            {
                if (isDisplayErrorsGUI)
                    MessageBox.Show("Error writing signed PDF back to file \n\nException:\n" + ex.Message, "Error");
                return false;
            }
            return true;
        }



        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //List of SignatureType operation codes for DssSign service:

        //Sign Binary Buffer and get detached PKCS7 signature blob
        const string SignatureTypePKCS7Detached = "urn:ietf:rfc:3369";

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

        //List of SignatureType opcodes for SPML service (user management):
        const string AddUserService = "http://arx.com/SAPIWS/SPML/1.0/add";


        //Return Code for success operation
        const string Success = "urn:oasis:names:tc:dss:1.0:resultmajor:Success";

        //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        //Sign PDF file
        public bool SignPDFFile(
            string CoSignDNS,
            string FileToSign,
            string UserName,
            string Password,
            string PdfPassword,
            string grSigName,
            int X,
            int Y,
            int Width,
            int Height,
            int Page,
            bool isVisible,
            int GMTOffset,
            int AppearanceMask)
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

            //display only graphical signature in signature field
            Req.OptionalInputs.SAPISigFieldSettings.AppearanceMask = (uint)AppearanceMask;
            Req.OptionalInputs.SAPISigFieldSettings.AppearanceMaskSpecified = true;

            int numConfigurationParams = 0;
            if (!string.IsNullOrEmpty(PdfPassword))
                numConfigurationParams += 2;
            if (!string.IsNullOrEmpty(grSigName))
                numConfigurationParams += 1;
            if ((GMTOffset != 0) && ((GMTOffset % 60) == 0))
                numConfigurationParams += 1;
            
            if (numConfigurationParams > 0)
            {
                Req.OptionalInputs.ConfigurationValues = new ConfValueType[numConfigurationParams];
                for (int i = 0; i < numConfigurationParams; i++)
                {
                    Req.OptionalInputs.ConfigurationValues[i] = new ConfValueType();
                }
            }

            int confArrayCurrentLoc = -1;
            if (!string.IsNullOrEmpty(PdfPassword))
            {
                // Add DECRYPT PDF password
                confArrayCurrentLoc += 1;
                Req.OptionalInputs.ConfigurationValues[confArrayCurrentLoc].ConfValueID = ConfIDEnum.PDFOwnerPwd;
                Req.OptionalInputs.ConfigurationValues[confArrayCurrentLoc].Item = PdfPassword;

                confArrayCurrentLoc += 1;
                Req.OptionalInputs.ConfigurationValues[confArrayCurrentLoc].ConfValueID = ConfIDEnum.PDFUserPwd;
                Req.OptionalInputs.ConfigurationValues[confArrayCurrentLoc].Item = PdfPassword;
            }

            //choose the 'grSigName' graphical signature from signer account
            if (!string.IsNullOrEmpty(grSigName))
            {
                //specify graphical signature name
                confArrayCurrentLoc += 1;
                Req.OptionalInputs.ConfigurationValues[confArrayCurrentLoc].ConfValueID = ConfIDEnum.GRSigPrefName;
                Req.OptionalInputs.ConfigurationValues[confArrayCurrentLoc].Item = grSigName;
            }

            if ((GMTOffset != 0) && ((GMTOffset % 60) == 0))
            {
                //GMTOffset
                confArrayCurrentLoc += 1;
                Req.OptionalInputs.ConfigurationValues[confArrayCurrentLoc].ConfValueID = ConfIDEnum.GMTOffset;
                Req.OptionalInputs.ConfigurationValues[confArrayCurrentLoc].Item = GMTOffset;
            }

            // Add reason
            //Req.OptionalInputs.ConfigurationValues[0].ConfValueID = ConfIDEnum.Reason;
            //Req.OptionalInputs.ConfigurationValues[0].Item = "I am the author of this document";

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
            //Req.OptionalInputs.ReturnPDFTailOnlySpecified = true;
            Req.OptionalInputs.ReturnPDFTailOnlySpecified = false;
            Req.OptionalInputs.ReturnPDFTailOnly = false;
            b64data.Value = ReadFile(FileToSign, true); //Read the file to the Bytes Array

            doc1.Item = b64data;
            Req.InputDocuments.Items[0] = doc1;

            //Call sign service
            ResponseBaseType Resp = null;

            try
            {
                // Create the Web Service client object
                DSS service = new DSS();
                service.Url = "https://" + CoSignDNS + ":8080/sapiws/dss.asmx";

                SignRequest sreq = new SignRequest();
                sreq.InputDocuments = Req.InputDocuments;
                sreq.OptionalInputs = Req.OptionalInputs;

                //Perform Signature operation
                Resp = service.DssSign(sreq);

                if (Resp.Result.ResultMajor != Success)
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
            DssSignResult sResp = (DssSignResult)Resp;

            //return Tail only code
            //DssSignResultSignatureObjectBase64Signature sig = (DssSignResultSignatureObjectBase64Signature)sResp.SignatureObject.Item;
            //byte[] signature = sig.Value;
            //return PDFAttachSignature(FileToSign, signature, true); //Attach Signature to the PDF file 

            DocumentTypeBase64Data signedDoc = (DocumentTypeBase64Data)sResp.OptionalOutputs.DocumentWithSignature.Document.Item;
            byte[] docData = signedDoc.Value;
            //return PDFAttachSignature(FileToSign + ".signed.pdf", docData, true);
            return PDFReWrite(FileToSign, docData, true);
        }

        public SPMLSoapClient.PSOType[] ListUsers(string adminUsername, string adminPswd)
        {
            var client = new SPMLSoapClient.SPML();

            var data = new SPMLSoapClient.CoSignLogonData();
            data.User = adminUsername;
            data.Password = adminPswd;
            //data.Domain = "";

            // Get a list of users
            var searchRequest = new SPMLSoapClient.SearchRequestType();
            searchRequest.CoSignLogonData = data;
            searchRequest.returnData = SPMLSoapClient.ReturnDataType.data;
            searchRequest.maxSelect = 20; // number of records to extract
            searchRequest.maxSelectSpecified = true;

            SPMLSoapClient.SearchResponseType response;

            try
            {
                response = client.search(searchRequest);
                if (response.status != SPMLSoapClient.StatusCodeType.success)
                {
                    MessageBox.Show("Error on search: " + response.status + ", " + response.error + ", " + response.errorMessage[0], "Error");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }
            if (response.pso == null)
            {
                MessageBox.Show("No users!", "OK");
                return null;
            }

            return response.pso;
        }


        public bool AddUser(string adminUsername, string adminPswd, string username, string password, string commonName, string email)
        {
            var client = new SPMLSoapClient.SPML();
            
            // Set request type
            var addRequest = new SPMLSoapClient.AddRequestType();

            // add admin logon data 
            var logonData = new SPMLSoapClient.CoSignLogonData();
            logonData.User = adminUsername;
            logonData.Password = adminPswd;
            addRequest.CoSignLogonData = logonData; // admin logon info
            addRequest.returnData = SPMLSoapClient.ReturnDataType.data;

            // add user data
            addRequest.UserRecord = new SPMLSoapClient.UserRecord();
            addRequest.UserRecord.UserLoginName = username;
            addRequest.UserRecord.Password = password;
            addRequest.UserRecord.UserCN = commonName;
            addRequest.UserRecord.EmailAddress = email;
            addRequest.UserRecord.RightsMask = 1; //1=User, 2=Appliance mngmnt, 4=User mngmnt
            addRequest.UserRecord.UserKind = SPMLSoapClient.UserKindEnum.User;

            addRequest.psoID = new SPMLSoapClient.PSOIdentifierType();
            addRequest.psoID.ID = username;
            
            SPMLSoapClient.AddResponseType response;

            try
            {
                response = client.add(addRequest);

                if (response.status != SPMLSoapClient.StatusCodeType.success)
                {
                    MessageBox.Show("Error on Add: " + response.status + ", " + response.error + ", " + response.errorMessage[0], "Error");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
            if (response.pso == null)
            {
                //.....
                return false;
            }
            
            return true;
        }
    }
}
