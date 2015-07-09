using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HelloWorld.SAPIWS;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Custom Values
            string filePath      = "c:/temp/demo.pdf";	// File to sign
            string fileMimeType  = "application/pdf";	// File MIME type
            string username      = "{signer_username}";		// CoSign account username
            string password      = "{signer_password}";			// CoSign account password
            string domain        = "";               	// CoSign account domain
            int sigPageNum       = 1;					// Create signature on the first page
            int sigX             = 145;					// Signature field X location
            int sigY             = 125;					// Signature field Y location
            int sigWidth         = 160;					// Signature field width
            int sigHeight        = 45;					// Signature field height
            string timeFormat    = "hh:mm:ss";			// The display format of the time
            string dateFormat    = "dd/MM/yyyy";		// The display format of the date
            uint appearanceMask  = 11;					// Elements to display on the signature field (11 = Graphical image + Signer name + Time)
            string signatureType = "http://arx.com/SAPIWS/DSS/1.0/signature-field-create-sign";	// The actual operation of the Sign Request function
            string wsdlUrl       = "https://prime.cosigntrial.com:8080/sapiws/dss.asmx?WSDL";   // URL to the WSDL file

            try
            {
                // Read file contents
                byte[] fileBuffer = File.ReadAllBytes(filePath);

                // Set file contents + MIME type (the SOAP library automatically base64 encodes the data)
                DocumentType document = new DocumentType()
                {
                    Item = new DocumentTypeBase64Data()
                    {
                        Value = fileBuffer,
                        MimeType = fileMimeType
                    }
                };

                ClaimedIdentity claimedIdentity = new ClaimedIdentity()
                {
                    Name = new NameIdentifierType()
                    {
                        Value = username,
                        NameQualifier = domain
                    },
                    SupportingInfo = new CoSignAuthDataType()
                    {
                        LogonPassword = password
                    }
                };

                // Define signature field settings
                SAPISigFieldSettingsType sigFieldSettings = new SAPISigFieldSettingsType()
                {
                    Invisible = false,
                    InvisibleSpecified = true,
                    X = sigX,
                    XSpecified = true,
                    Y = sigY,
                    YSpecified = true,
                    Width = sigWidth,
                    WidthSpecified = true,
                    Height = sigHeight,
                    HeightSpecified = true,
                    Page = sigPageNum,
                    PageSpecified = true,
                    AppearanceMask = appearanceMask,
                    AppearanceMaskSpecified = true,
                    TimeFormat = new TimeDateFormatType()
                    {
                        TimeFormat = timeFormat,
                        DateFormat = dateFormat,
                        ExtTimeFormat = ExtendedTimeFormatEnum.GMT,
                        ExtTimeFormatSpecified = true
                    }
                };

                // Build complete request object
                SignRequest signRequest = new SignRequest()
                {
                    InputDocuments = new RequestBaseTypeInputDocuments()
                    {
                        Items = new DocumentType[] { document }
                    },
                    OptionalInputs = new RequestBaseTypeOptionalInputs()
                    {
                        SignatureType = signatureType,
                        ClaimedIdentity = claimedIdentity,
                        SAPISigFieldSettings = sigFieldSettings,
                        ReturnPDFTailOnly = true,
                        ReturnPDFTailOnlySpecified = true
                    }
                };

                // Initiate service client
                DSS client = new DSS() { Url = wsdlUrl };

                // Send the request
                DssSignResult response = client.DssSign(signRequest);

                // Check response output
                if ("urn:oasis:names:tc:dss:1.0:resultmajor:Success".Equals(response.Result.ResultMajor))
                {
                    // On success- append signature object to the source PDF document (the SOAP library automatically decodes the base64 encoded output)
                    byte[] signatureObjectBuffer = ((DssSignResultSignatureObjectBase64Signature)response.SignatureObject.Item).Value;
                    using (var fileStream = new FileStream(filePath, FileMode.Append))
                    {
                        fileStream.Write(signatureObjectBuffer, 0, signatureObjectBuffer.Length);
                    }
                }
                else
                {
                    // On failure- raise exception with the result error message
                    throw new Exception(response.Result.ResultMessage.Value);
                }

                Console.WriteLine("The document has been successfully signed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
