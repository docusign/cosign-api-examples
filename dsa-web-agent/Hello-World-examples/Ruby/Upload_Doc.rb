require 'base64'
require 'Builder'
require 'net/http'
require 'HTTParty'

file_path = 'c:/temp/demo.pdf';
file_id = '123456'
redirect_url = 'http://www.example.com/finishURL'
cswa_upload_url = 'https://webagentdev.arx.com/Sign/UploadFileToSign'
is_allow_adhoc = true
is_enforce_reason = false

begin

	# Get document type (file extension)
	content_type = File.extname(file_path).sub('.', '')

	# Read file contents and convert to base64 string
	base64_data = Base64.encode64(File.binread(file_path))

	# Build Request XML
	xml = Builder::XmlMarkup.new( :indent => 2 ) 
	xml.instruct!
	xml.request do
		xml.Document do
			xml.fileID file_id
			xml.contentType content_type
			xml.content base64_data
		end
		xml.Logic do
			xml.allowAdHoc is_allow_adhoc
			xml.enforceReason is_enforce_reason
		end
		xml.Url do
			xml.finishURL redirect_url
		end
	end

	# For debugging only - The XML request that is being posted
	puts xml.target!

	# Post Request XML
	response = HTTParty.post(cswa_upload_url, { :body => { :inputXML => xml.target! }, ssl_ca_file: 'cacert.pem' })

	# For debugging only - The full response as received from the server
	puts response

	# Check response output
	if response['response']
		if response['response']['Error']['returnCode'] == '0'
			sessionId = response['response']['Session']['sessionId']
			puts 'The docuemnt has been successfully uploded'
			puts 'SessionId: ' + sessionId
		else
			raise response['response']['Error']['errorMessage']
		end
	else
		raise 'Wrong response format'
	end

rescue Exception => e
    puts 'Error: ' + e.message  
    puts e.backtrace.inspect  
end  