require 'savon'
require 'base64'  

# Custom Values
file_path       = 'c:/temp/demo.pdf';   # File to sign
file_mime_type  = 'application/pdf';    # File MIME type
username        = '{signer_username}';  # CoSign account username
password        = '{signer_password}';  # CoSign account password
domain          = '';                   # CoSign account domain
sig_page_num    = 1;                    # Create signature on the first page
sig_x           = 145;                  # Signature field X location
sig_y           = 125;                  # Signature field Y location
sig_width       = 160;                  # Signature field width
sig_height      = 45;                   # Signature field height
time_format     = 'hh:mm:ss';           # The display format of the time
date_format     = 'dd/MM/yyyy';         # The display format of the date
appearance_mask = 11;                   # Elements to display on the signature field (11 = Graphical image + Signer name + Time)
signature_type  = 'http://arx.com/SAPIWS/DSS/1.0/signature-field-create-sign';  # The actual operation of the Sign Request function
wsdl_url        = 'https://prime.cosigntrial.com:8080/sapiws/dss.asmx?WSDL';    # URL to the WSDL file

begin

    # Read file contents and convert to base64 string
    base64_data = Base64.encode64(File.binread(file_path))

    # Set file contents + MIME type
    document = {
        Base64Data: base64_data,
        :attributes! => { Base64Data: { MimeType: file_mime_type } }
    }

    # Set user credentials. In case of Active Directory, the domain name should be defined in the NameQualifier attribute
    claimed_identidy = {
        Name: username,
        SupportingInfo: {
            LogonPassword: password,
            :attributes! => { LogonPassword: { xmlns: 'http://arx.com/SAPIWS/DSS/1.0' } }
        },
        :attributes! => { Name: { NameQualifier: domain } }
    }

    # Define signature field settings (inner elements)
    sapi_sig_field_setings = {
        TimeFormat: '',
        :attributes! => {  
            TimeFormat: {
                ExtTimeFormat: 'GMT',
                DateFormat: date_format,
                TimeFormat: time_format
            }
        }
    }

    # Define signature field settings (attributes)
    sapi_sig_field_setings_attributes = {
        Invisible: false,
        X: sig_x,
        Y: sig_y,
        Width: sig_width,
        Height: sig_height,
        Page: sig_page_num,
        AppearanceMask: appearance_mask,
        xmlns: 'http://arx.com/SAPIWS/DSS/1.0'
    }

    # Build complete request object
    sign_request = {
        SignRequest: {
            OptionalInputs: {
                ClaimedIdentity: claimed_identidy,
                SignatureType: signature_type,
                SAPISigFieldSettings: sapi_sig_field_setings,
                ReturnPDFTailOnly: true,    # Enable PDFTailOnly feature (Signature object is returned instead of the whole file)
                :attributes! => {
                    SAPISigFieldSettings: sapi_sig_field_setings_attributes,
                    ReturnPDFTailOnly: { xmlns: 'http://arx.com/SAPIWS/DSS/1.0' }
                }
            },
            InputDocuments: {
                Document: document
            }
        },
        :attributes! => { SignRequest: { xmlns: 'urn:oasis:names:tc:dss:1.0:core:schema' } }
    }

    # Initiate SOAP client (Savon)
    client = Savon.client(
        wsdl: wsdl_url,
        convert_request_keys_to: :camelcase,
        element_form_default: :unqualified,
        ssl_ca_cert_file: 'cacert.pem',
        ssl_version: :TLSv1
    )

    # Send the request
    response = client.call(:dss_sign, message: sign_request)

    # Check response output
    response = response.body
    if response[:dss_sign_response][:dss_sign_result][:result][:result_major] == 'urn:oasis:names:tc:dss:1.0:resultmajor:Success'
        # On success- append signature object to the source PDF document
        value = response[:dss_sign_response][:dss_sign_result][:signature_object][:base64_signature]
        File.binwrite(file_path, Base64.decode64(value), File.size(file_path), mode: 'a')
    else
        # On failure- raise exception with the result error message
        raise response[:dss_sign_response][:dss_sign_result][:result][:result_message]
    end

    puts 'The document has been successfully signed!'

rescue Exception => e
    puts 'Error: ' + e.message  
    puts e.backtrace.inspect  
end  