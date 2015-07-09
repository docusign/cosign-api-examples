<?php
/*
The MIT License (MIT)

Copyright (c) 2014 Larry Kluger

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

// CoSign Web Agent -- Manages io with the Web Agent
//

// Constants for CoSign Signature Web Agent
// layoutMask values
define ('CWA_SETTINGS_CHNG_PW', 8);         // Settings and change password
define ('CWA_SETTINGS_GRAPHICAL_SIGS', 16); // Graphical Signatures
define ('CWA_SUCCESS', 0);

define ('CWA_UPLOAD_DOC', 'Sign/UploadFileToSign');
define ('CWA_DOWNLOAD_SIGNED_FILE', 'Sign/DownloadSignedFileG');
define ('CWA_SIGNING_CEREMONY', 'Sign/SignCeremony');

class CoSign_Web_Agent {
	private $cosign_webagent_url;
	private $options;
	private $options_default = array(
		'username' => false,
		'userpw' => false,
		'file_id' => false,
		'finishURL' => false,
		'redirectIFrame' => false,
		'layoutMask' => 24, // CWA_SETTINGS_CHNG_PW + CWA_SETTINGS_GRAPHICAL_SIGS
		);

	public /*.void.*/ function __construct($webagent_url) {
		$this->cosign_webagent_url = $webagent_url;
	}

	public function prepare ($file_contents, $file_type, $filename, $opt = false) {
		// $opt -- associative array with items:
		//   finishURL -- REQUIRED
		//   
		// RETURNS an associative array with items:
		//   code -- 0  -- success; redirect the user's browser to the web agent
		//           anything else is an error
		//   errmsg -- only present if there is a problem
		//   redirect -- the url that the browser should be redirected to
		//   sessionID 
		//
		$this->process_opt($opt);
		$xml = $this->prepare_xml ($file_contents, $file_type, $filename, $opt);
		try {
		  $url = $this->cosign_webagent_url . CWA_UPLOAD_DOC;
		  $response = Unirest::post($url, array("Content-Type" => "application/x-www-form-urlencoded"),
			"inputXML=" . urlencode($xml));
		  return $this->decode_upload_xml_response($response);
		} catch (Exception $e) {
			return ['code' => -1, 'errmsg' => $e->getMessage()];
		}
	}
	
	private function prepare_xml ($file_contents, $file_type, $filename, $opt) {
		@date_default_timezone_set("GMT"); 

		$x = new XMLWriter;
		$x->openMemory();
		$x->startDocument('1.0', 'UTF-8');
		$x->startElement('request');
			$x->startElement('Logic');
				$x->writeElement('allowAdHoc', 'true');
			$x->endElement();
			$x->startElement('Url');
				$x->writeElement('finishURL', $this->options['finishURL']);
				$x->writeElement('redirectIFrame', $this->options['redirectIFrame'] === false ? 'false' : 'true');
			$x->endElement();
			$x->startElement('Layout');
				$x->writeElement('layoutMask', $this->options['layoutMask']);
			$x->endElement();
			$x->startElement('SignReasons');
				$x->writeElement('signReason', 'Approved');
				$x->writeElement('signReason', 'Certified');
				$x->writeElement('signReason', 'Confirmed');
			$x->endElement();
			$x->startElement('Document');
				if ($this->options['file_id'] !== false) {
					$x->writeElement('fileID', $this->options['file_id']);
				}
				$x->writeElement('contentType', $file_type);
				$x->writeElement('filename', $filename); 
				$x->writeElement('content', base64_encode ($file_contents));
			$x->endElement();
			if ($opt['username']) {
				$x->startElement('Auth');
					$x->writeElement('username', $opt['username']);
					if ($opt['userpw']) { $x->writeElement('password', $opt['userpw']); }
				$x->endElement();
			}
		$x->endElement();
		$x->endDocument();
		return $x->outputMemory(TRUE);	
	}
	
	private function decode_upload_xml_response($response) {
		if ($response->code != 200) {
			return ['code' => $response->code, 'errmsg' => "Bad HTTP code $response->code from Web Agent server"];
		}

		// http://www.php.net/manual/en/simplexml.examples-basic.php
		$payload = $response->raw_body;
		
		$xml = new SimpleXMLElement($payload);
		$return_code = (string)$xml->Error->returnCode;
		$sessionID = (string)$xml->Session->sessionId;
		if($return_code != CWA_SUCCESS) {
			return ['code' => $return_code, 'errmsg' => "Web Agent problem: " . (string)$xml->Error->errorMessage . " ($return_code)"];
		}
		return ['code' => 0, 'sessionID' => $sessionID,
			'redirect' => $this->cosign_webagent_url . CWA_SIGNING_CEREMONY . "?sessionId=" . $sessionID];
	}
	
	private function process_opt($opt) {
		if ($opt === false) { 
			$opt = array();
		}
		foreach ($this->options_default as $key => $value) {		
			$this->options[$key] = $opt[$key] ? $opt[$key] : $this->options_default[$key];
		}
	}
	
	public function get_signed_file ($sessionID,  $signed_file_path) {
		// fetch the signed file plus details and store it locally
		// ARGS
		//   $sessionID, $signed_file_path
		// RETURNS
		//   $info associative array with keys:
		//      error -- either null or an error while fetching from the server
		//      sessionID -- sessionID for the file
		//      docId
		//      fieldName -- field that was signed
		//      x  -- where the document was signed
		//      y
		//      width
		//      height
		//      pageNumber -- page where the doc was signed
		//      dateFormat
		//      timeformat
		//      graphicalImage
		//      signer
		//      date
		//      showTitle
		//      showReason
		//      title
		//      reason
	
		// Fetch the signed file and signing information
		try {
		  $response = Unirest::get( $this->cosign_webagent_url . CWA_DOWNLOAD_SIGNED_FILE . '?sessionId=' . $sessionID);
		} catch (Exception $e) {
			return array('error' => $e->getMessage());
		}
		
		// everything ok at the http level?
		$http_code = $response->code;
		if ($http_code <> '200') {
			return array('error' => 'HTTP Error when contacting server. Code: ' . $http_code);
		}
		
		// return the info object to the caller after processing the xml body
		return $this->signed_file_xml($response->raw_body, $signed_file_path);
	}


	// signed_file_xml -- decodes the xml and stores the file
	// args -- the raw incoming xml and where to store the file
	// returns -- an info associative array as shown above
	// side effect -- stores the signed file on the disk
	private function signed_file_xml($raw, $signed_file_path) {
		// parse the xml
		$xml = new SimpleXMLElement($raw);
		
		// check the returnCode
		$return_code = (string)$xml->Error->returnCode;
		if ($return_code != CWA_SUCCESS) {
			return array('error' => (string)$xml->Error->errorMessage . ' Code: ' . $return_code);
		}
		
		// All's good! Populate the info associative array
		$info = array();
		$info['error'] = null;
		$info['sessionID'] = (string)$xml->Session->sessionId;
		$info['docId'] = (string)$xml->Session->docId;
		$info['fieldName'] = (string)$xml->SigDetails->fieldName;
		$info['x'] = (integer)$xml->SigDetails->x;
		$info['y'] = (integer)$xml->SigDetails->y;
		$info['width'] = (integer)$xml->SigDetails->width;
		$info['height'] = (integer)$xml->SigDetails->height;
		$info['pageNumber'] = (integer)$xml->SigDetails->pageNumber;
		$info['dateFormat'] = (string)$xml->SigDetails->dateFormat;
		$info['timeformat'] = (string)$xml->SigDetails->timeformat;
		$info['graphicalImage'] = strtolower((string)$xml->SigDetails->graphicalImage) == 'true';
		$info['signer'] = strtolower((string)$xml->SigDetails->signer) == 'true';
		$info['date'] = strtolower((string)$xml->SigDetails->date) == 'true';
		$info['showTitle'] = strtolower((string)$xml->SigDetails->showTitle) == 'true';
		$info['showReason'] = strtolower((string)$xml->SigDetails->showReason) == 'true';
		$info['title'] = (string)$xml->SigDetails->title;
		$info['reason'] = (string)$xml->SigDetails->reason;
		
		// write the file
		$fh = fopen($signed_file_path, "wb");
		fwrite ($fh, base64_decode((string)$xml->Document->content));
		fclose($fh);

		return $info;   
	}
	

	
}


