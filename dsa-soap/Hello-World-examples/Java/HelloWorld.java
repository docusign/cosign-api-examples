import java.net.URL;
import com.arx.sapiws.dss._1.*;
import oasis.names.tc.dss._1_0.core.schema.*;
import oasis.names.tc.dss._1_0.core.schema.DocumentType.*;
import oasis.names.tc.saml._1_0.assertion.*;
import java.nio.file.*;

public class HelloWorld {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
    	
    	// Custom Values
    	String filePath 	 = "c:/temp/demo.pdf";	// File to sign
    	String fileMimeType	 = "application/pdf";	// File MIME type
    	String username 	 = "{signer_username}";		// CoSign account username
    	String password 	 = "{signer_password}";			// CoSign account password
    	String domain   	 = "";               	// CoSign account domain
    	int sigPageNum		 = 1;					// Create signature on the first page
    	int sigX			 = 145;					// Signature field X location
    	int sigY			 = 125;					// Signature field Y location
    	int sigWidth		 = 160;					// Signature field width
    	int sigHeight		 = 45;					// Signature field height
    	String timeFormat 	 = "hh:mm:ss";			// The display format of the time
    	String dateFormat	 = "dd/MM/yyyy";		// The display format of the date
    	long appearanceMask	 = 11;					// Elements to display on the signature field (11 = Graphical image + Signer name + Time)
    	String signatureType = "http://arx.com/SAPIWS/DSS/1.0/signature-field-create-sign";	// The actual operation of the Sign Request function
    	String wsdlUrl		 = "https://prime.cosigntrial.com:8080/sapiws/dss.asmx?WSDL";	// URL to the WSDL file
    	
    	try
    	{
	    	// Read file contents
	    	byte[] fileBuffer = Files.readAllBytes(Paths.get(filePath));
	    	
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
	        SAPISigFieldSettingsType sigFieldSettings = new SAPISigFieldSettingsType();
	        sigFieldSettings.setInvisible(false);
	        sigFieldSettings.setX(sigX);
	        sigFieldSettings.setY(sigY);
	        sigFieldSettings.setWidth(sigWidth);
	        sigFieldSettings.setHeight(sigHeight);
	        sigFieldSettings.setPage(sigPageNum);
	        sigFieldSettings.setAppearanceMask(appearanceMask);
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
	        signRequest.setOptionalInputs(optionalInputs);
	        signRequest.setInputDocuments(inputDocuments);
	        
	        // Initiate service client
	        DSS client = new DSS(new URL(wsdlUrl));
	        
	        // Send the request
	        DssSignResult response = client.getDSSSoap().dssSign(signRequest);
	        
	        // Check response output
	        if ("urn:oasis:names:tc:dss:1.0:resultmajor:Success".equals(response.getResult().getResultMajor())) {
	        	// On success- append signature object to the source PDF document (the SOAP library automatically decodes the base64 encoded output)
	        	byte[] signatureObjectBuffer = response.getSignatureObject().getBase64Signature().getValue();
	        	Files.write(Paths.get(filePath), signatureObjectBuffer, StandardOpenOption.APPEND);
	        }
	        else
	        {
	        	// On failure- raise exception with the result error message
	        	throw new Exception(response.getResult().getResultMessage().getValue());
	        }
	        
	        System.out.println("The document has been successfully signed!");
        }
        catch (Exception e)
        {
            System.out.println("Error: " + e.getMessage());
            e.printStackTrace();
        }
    }
}
    