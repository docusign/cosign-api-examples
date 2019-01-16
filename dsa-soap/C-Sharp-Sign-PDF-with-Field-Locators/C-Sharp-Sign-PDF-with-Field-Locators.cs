public SAPISigFieldSettingsType[] getSigFieldLocatorsInPDF(
        string FileName,
        string UserName,
        string Password)
    {
 
        //Create Request object contains signature parameters
        RequestBaseType Req = new RequestBaseType();
        Req.OptionalInputs = new RequestBaseTypeOptionalInputs();
 
        //Here Operation Type is set: enum-field-locators
        Req.OptionalInputs.SignatureType = SignatureTypeFieldLocators;
 
        // Configure Create and Sign operation parameters:
        Req.OptionalInputs.ClaimedIdentity = new ClaimedIdentity();
        Req.OptionalInputs.ClaimedIdentity.Name = new NameIdentifierType();
        // User Name:
		Req.OptionalInputs.ClaimedIdentity.Name.Value = UserName;
		// Domain (only relevant for Active Directory environments)		
		Req.OptionalInputs.ClaimedIdentity.Name.NameQualifier = " "; 
        Req.OptionalInputs.ClaimedIdentity.SupportingInfo = new CoSignAuthDataType();
		// User Password:
        Req.OptionalInputs.ClaimedIdentity.SupportingInfo.LogonPassword = Password;
        Req.OptionalInputs.FieldLocatorOpeningPattern = "<<";
        Req.OptionalInputs.FieldLocatorClosingPattern = ">>";
 
        //Set Session ID
        Req.RequestID = Guid.NewGuid().ToString();
 
        //Prepare the Data to be signed
        DocumentType doc1 = new DocumentType();
        DocumentTypeBase64Data b64data = new DocumentTypeBase64Data();
        Req.InputDocuments = new RequestBaseTypeInputDocuments();
        Req.InputDocuments.Items = new object[1];
 
        // Can also be: application/msword, image/tiff, application/octet-string
		b64data.MimeType = "application/pdf";  
        Req.OptionalInputs.ReturnPDFTailOnlySpecified = true;
        Req.OptionalInputs.ReturnPDFTailOnly = false;
        b64data.Value = ReadFile(FileName, true); // Read the file to the Bytes Array
 
        doc1.Item = b64data;
        Req.InputDocuments.Items[0] = doc1;
 
        //Call sign service
        ResponseBaseType Resp = null;
 
        try
        {
            // Create the Web Service client object
            DSS service = new DSS();
			// The following service point url is for the DevCenter CoSign Central appliance
			// For production, use your CoSign appliance's url
            service.Url = "https://prime-dsa-devctr.docusign.net:8080/sapiws/dss.asmx";  
 
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
                return null;
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
            return null;
        }
 
 
        //Handle Reply
        DssSignResult sResp = (DssSignResult) Resp;
 
        return Resp.OptionalOutputs.SAPISeveralSigFieldSettings;
	}