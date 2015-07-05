import java.net.URL;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

import oasis.names.tc.dss._1_0.core.schema.ClaimedIdentity;
import oasis.names.tc.dss._1_0.core.schema.DocumentType;
import oasis.names.tc.dss._1_0.core.schema.DssSignResult;
import oasis.names.tc.dss._1_0.core.schema.RequestBaseType;
import oasis.names.tc.dss._1_0.core.schema.SignRequest;
import oasis.names.tc.dss._1_0.core.schema.DocumentType.Base64Data;
import oasis.names.tc.saml._1_0.assertion.NameIdentifierType;

import com.arx.sapiws.dss._1.CoSignAuthDataType;
import com.arx.sapiws.dss._1.DSS;
import com.arx.sapiws.dss._1.ExtendedTimeFormatEnum;
import com.arx.sapiws.dss._1.SAPISigFieldSettingsType;
import com.arx.sapiws.dss._1.TimeDateFormatType;

public class field_locators {
	
	static final String serviceUrl = "https://prime.cosigntrial.com:8080/sapiws/dss.asmx";	// The service URL
	
	public static void main(String[] args) throws Exception {
    	
    	// Custom Values
    	String filePath 	 = "c:/temp/PDF_Field_Locators.pdf";	// File to sign
    	String fileMimeType	 = "application/pdf";					// File MIME type
    	String username 	 = "{CoSign_username}"; 				// CoSign account username
    	String password 	 = "{CoSign_password}";					// CoSign account password
    	String domain   	 = "";               					// CoSign account domain
    	
    	try
    	{
	    	// Read file contents
	    	byte[] fileBuffer = Files.readAllBytes(Paths.get(filePath));
	    	
	    	List<SAPISigFieldSettingsType> sigFieldSettingsList = getSigFieldsByLocators(fileBuffer);
	        
	    	for (SAPISigFieldSettingsType sigFieldSettings : sigFieldSettingsList)
	    	{
	    		fileBuffer = signDoc(fileBuffer, fileMimeType, username, domain, password, sigFieldSettings);
	    		
	    		String fieldName = sigFieldSettings.getName() == "" ? "Undefined" : sigFieldSettings.getName();
	    		System.out.println("The document was signed! (field name: " + fieldName + ")");
	    	}
	    	
	    	Files.write(Paths.get(filePath), fileBuffer);
        }
        catch (Exception e)
        {
            System.out.println("Error: " + e.getMessage());
            e.printStackTrace();
        }
    }
	
	// Get a list of SAPISigFieldSettings objects that correspond to the field locators that are embedded in the PDF document.
	// The following values of the SAPISigFieldSettings will be automatically set by SAPI:
	// X/Y coordinates and page number - Always.
	// Width, Height, FieldName and AppearanceMask - If provided in the field locator string.
	private static List<SAPISigFieldSettingsType> getSigFieldsByLocators(byte[] fileBuffer) throws Exception {
		
		List<SAPISigFieldSettingsType> sigFields = null;
		
		String signatureType = "http://arx.com/SAPIWS/DSS/1.0/enum-field-locators";
		String openingPattern = "<<<";
		String closingPattern = ">>>";
		
		// Set file contents + MIME type (the SOAP library automatically base64 encodes the data)
    	DocumentType document = new DocumentType();
    	Base64Data base64Data = new Base64Data();
    	base64Data.setValue(fileBuffer);
    	base64Data.setMimeType("application/pdf"); // field locators are currently supported with PDF files only
        document.setBase64Data(base64Data);
		
        // Build request object
        SignRequest signRequest = new SignRequest();
        RequestBaseType.InputDocuments inputDocuments = new RequestBaseType.InputDocuments();
        inputDocuments.getOtherOrDocumentHashOrTransformedData().add(document);
        RequestBaseType.OptionalInputs optionalInputs = new RequestBaseType.OptionalInputs();
        optionalInputs.setSignatureType(signatureType);
        optionalInputs.setFieldLocatorOpeningPattern(openingPattern);
        optionalInputs.setFieldLocatorClosingPattern(closingPattern);
        signRequest.setOptionalInputs(optionalInputs);
        signRequest.setInputDocuments(inputDocuments);
        
        // Initiate service client
        DSS client = new DSS(new URL(serviceUrl));
        
        // Send the request
        DssSignResult response = client.getDSSSoap().dssSign(signRequest);
        
        // Check response output
        if ("urn:oasis:names:tc:dss:1.0:resultmajor:Success".equals(response.getResult().getResultMajor())) {
        	sigFields = response.getOptionalOutputs().getSAPISeveralSigFieldSettings();
        }
        else
        {
        	throw new Exception(response.getResult().getResultMessage().getValue());
        }
        
		return sigFields;
	}
	
	private static byte[] signDoc(byte[] fileBuffer, String fileMimeType, String username, String domain, String password, SAPISigFieldSettingsType sigFieldSettings) throws Exception {
		
		byte[] signedDoc = null;
		
		int sigWidth		 = 200;					// Signature field width
    	int sigHeight		 = 70;					// Signature field height
    	String timeFormat 	 = "hh:mm:ss";			// The display format of the time
    	String dateFormat	 = "dd/MM/yyyy";		// The display format of the date
    	long appearanceMask	 = 11;					// Elements to display on the signature field (11 = Graphical image + Signer name + Time)
    	String signatureType = "http://arx.com/SAPIWS/DSS/1.0/signature-field-create-sign";	// The actual operation of the Sign Request function
    	
		// Set file contents + MIME type (the SOAP library automatically base64 encodes the data)
    	DocumentType document = new DocumentType();
    	Base64Data base64Data = new Base64Data();
    	base64Data.setValue(fileBuffer);
    	base64Data.setMimeType(fileMimeType);
        document.setBase64Data(base64Data);
        
        // Set user credentials. In case of Active Directory, the domain name should be defined in the NameQualifier attribute
        ClaimedIdentity claimedIdentity = new ClaimedIdentity();
        NameIdentifierType nameIdentifier = new NameIdentifierType();
        nameIdentifier.setValue(username);
        nameIdentifier.setNameQualifier(domain);
        CoSignAuthDataType coSignAuthData = new CoSignAuthDataType();
        coSignAuthData.setLogonPassword(password);
        claimedIdentity.setName(nameIdentifier);
        claimedIdentity.setSupportingInfo(coSignAuthData);
        
        // Define signature field settings
        if (sigFieldSettings.getWidth() == 0)
    	{
    		sigFieldSettings.setWidth(sigWidth);
    	}
        if (sigFieldSettings.getHeight() == 0)
    	{
        	sigFieldSettings.setHeight(sigHeight);
    	}
        if (sigFieldSettings.getAppearanceMask() == 0)
    	{
        	sigFieldSettings.setAppearanceMask(appearanceMask);
    	}
        TimeDateFormatType timeDateFormat = new TimeDateFormatType();
        timeDateFormat.setTimeFormat(timeFormat);
        timeDateFormat.setDateFormat(dateFormat);
        timeDateFormat.setExtTimeFormat(ExtendedTimeFormatEnum.GMT);
        sigFieldSettings.setTimeFormat(timeDateFormat);
        
        // Build complete request object
        SignRequest signRequest = new SignRequest();
        RequestBaseType.InputDocuments inputDocuments = new RequestBaseType.InputDocuments();
        inputDocuments.getOtherOrDocumentHashOrTransformedData().add(document);
        RequestBaseType.OptionalInputs optionalInputs = new RequestBaseType.OptionalInputs();
        optionalInputs.setSignatureType(signatureType);
        optionalInputs.setClaimedIdentity(claimedIdentity);
        optionalInputs.setSAPISigFieldSettings(sigFieldSettings);
        optionalInputs.setReturnPDFTailOnly(true);
        if (sigFieldSettings.getName() != "")
        {
        	optionalInputs.setSignatureFieldName(sigFieldSettings.getName());
            optionalInputs.setFlags(Long.valueOf(0x00000080));
        }
        
        signRequest.setOptionalInputs(optionalInputs);
        signRequest.setInputDocuments(inputDocuments);
        
        // Initiate service client
        DSS client = new DSS(new URL(serviceUrl));
        
        // Send the request
        DssSignResult response = client.getDSSSoap().dssSign(signRequest);
        
        // Check response output
        if ("urn:oasis:names:tc:dss:1.0:resultmajor:Success".equals(response.getResult().getResultMajor())) {
        	// On success- append signature object to the source PDF document (the SOAP library automatically decodes the base64 encoded output)
        	byte[] signatureObjectBuffer = response.getSignatureObject().getBase64Signature().getValue();
        	signedDoc = concatenateByteArrays(fileBuffer, signatureObjectBuffer);
        }
        else
        {
        	// On failure- raise exception with the result error message
        	throw new Exception(response.getResult().getResultMessage().getValue());
        }
        
        return signedDoc;
	}
	
	private static byte[] concatenateByteArrays(byte[] a, byte[] b) {
	    byte[] result = new byte[a.length + b.length]; 
	    System.arraycopy(a, 0, result, 0, a.length); 
	    System.arraycopy(b, 0, result, a.length, b.length); 
	    return result;
	} 
}
