from suds.client import Client
from suds import WebFault
from suds.plugin import MessagePlugin
from suds.sax.attribute import Attribute
import sys
import requests

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

try:
    # Read file contents and convert to base64 string
    base64_data = open(file_path, "rb").read().encode('base64')

    # Set file contents (See "Fix SOAP Request" section below for how to define the file MIME type)
    document = {
        'Base64Data' : base64_data
    }

    # Set user credentials. In case of Active Directory, the domain name should be defined in the NameQualifier attribute (See "Fix SOAP Request" section below)
    claimed_identidy = {
        'Name' : username,
        'SupportingInfo' : {
            'LogonPassword' : password,
        }
    }

    # Define signature field settings
    sapi_sig_field_setings = {
        '_Invisible' : 'false',
        '_X' : sig_x,
        '_Y' : sig_y,
        '_Width' : sig_width,
        '_Height' : sig_height,
        '_Page' : sig_page_num,
        '_AppearanceMask' : appearance_mask,
        'TimeFormat' : {
            '_ExtTimeFormat' : 'GMT',
            '_DateFormat' : date_format,
            '_TimeFormat' : time_format
        }
    }

    # Build complete request object
    sign_request = {
        'OptionalInputs' : {
            'ClaimedIdentity' : claimed_identidy,
            'SignatureType' : signature_type,
            'SAPISigFieldSettings' : sapi_sig_field_setings,
            'ReturnPDFTailOnly' : 'true'    # Enable PDFTailOnly feature (Signature object is returned instead of the whole file)
        },
        'InputDocuments' : {
            'Document' : document
        }
    }

    # Manually fix tags that have missing attributes or wrong namespace
    class FixSOAPRequest(MessagePlugin):
        def marshalled(self, context):
            # Fix wrong prefixes
            context.envelope.getChild('Body').setPrefix(context.envelope.prefix)    # Fix 'Body' node prefix
            sign_request_ns = context.envelope.findPrefix('urn:oasis:names:tc:dss:1.0:core:schema')
            sapiws_ns = context.envelope.findPrefix('http://arx.com/SAPIWS/DSS/1.0')
            context.envelope.getChild('Body').getChild('DssSign').getChild('SignRequest').setPrefix(sign_request_ns)    # Fix 'SignRequest' node prefix
            context.envelope.getChild('Body').getChild('DssSign').getChild('SignRequest').getChild('OptionalInputs').getChild('SAPISigFieldSettings').setPrefix(sapiws_ns)  # Fix 'SAPISigFieldSettings' node prefix
            context.envelope.getChild('Body').getChild('DssSign').getChild('SignRequest').getChild('OptionalInputs').getChild('ReturnPDFTailOnly').setPrefix(sapiws_ns)     # Fix 'ReturnPDFTailOnly' node prefix
            # Add 'NameQualifier' attribute to the 'Name' node (e.g. <Name NameQualifier={domain}>...</Name>)
            name_node = context.envelope.getChild('Body').getChild('DssSign').getChild('SignRequest').getChild('OptionalInputs').getChild('ClaimedIdentity').getChild('Name')
            name_node.attributes.append(Attribute('NameQualifier', domain))
            # Add 'MimeType' attribute to the 'Base64Data' node (e.g. <Base64Data MimeType="application/pdf">...</Base64Data>)
            base64_data_node = context.envelope.getChild('Body').getChild('DssSign').getChild('SignRequest').getChild('InputDocuments').getChild('Document').getChild('Base64Data')
            base64_data_node.attributes.append(Attribute('MimeType', file_mime_type))

    # SSL Certificate Verification (using 'Requests' library)
    requests.get(wsdl_url, verify=True)

    # Initiate SOAP client (SUDS)
    client = Client(wsdl_url, plugins=[FixSOAPRequest()])

    # Send the request
    response = client.service.DssSign(sign_request)

    # Check response output
    if response['Result']['ResultMajor'] == 'urn:oasis:names:tc:dss:1.0:resultmajor:Success':
        # On success- append signature object to the source PDF document
        value = response['SignatureObject']['Base64Signature']['value']
        open(file_path, "ab").write(value.decode('base64'))
    else:
        # On failure- raise exception with the result error message
        raise Exception(response['Result']['ResultMajor'])

    print 'The document has been successfully signed!'

except Exception, e:
    print "Error: %s" % e