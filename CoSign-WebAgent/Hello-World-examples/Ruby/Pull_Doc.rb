require 'base64'
require 'net/http'
require 'HTTParty'

cswa_pull_url = 'https://webagentdev.arx.com/Sign/DownloadSignedFileG'
signed_file_path = 'c:/temp/signedDoc.pdf';

session_id = '1187160054'

begin

	# Send GET request
	response = HTTParty.get(cswa_pull_url, { :query => { :sessionId => session_id }, ssl_ca_file: 'cacert.pem' })

	# For debugging only - The full response as received from the server
	puts response

	# Check response output
	if response['response']
		if response['response']['Error']['returnCode'] == '0'
			# On success- Save the signed PDF document
			base64_data = response['response']['Document']['content']
			File.binwrite(signed_file_path, Base64.decode64(base64_data))
		else
			# On failure- raise exception with the result error message
			raise response['response']['Error']['errorMessage']
		end
	else
		raise 'Wrong response format - verify server URL'
	end

rescue Exception => e
    puts 'Error: ' + e.message  
    puts e.backtrace.inspect  
end