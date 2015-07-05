<?php

// CFS API -- Sends data to be web merged and the result is PDF signed
//
// wp-json/cfs/v1/request/<request_id>
//   POST - Insert new request. Requires request ID
//
// wp-json/cfs/v1/request/<request_id>
//   GET  - Gets status of request
//
// Example from a form
// JotForm sends the form's data as POST form parameters:
//
//	FORM/POST PARAMETERS
//	newsalary: 55,000
//	currentsalary: 50,000
//	employeename: George Jetson
//	formID: 43114998637466
//	employeeid: 12-345
//	ip: 87.68.15.72
//	submission_id: 291287018275470912
//	effectivedate[]: 2014
//	effectivedate[]: 11
//	effectivedate[]: 08
//	_date_format: ymd|F j, Y
//	_date_fields: effectivedate
//  _webmerge_id: 20442   // see https://www.webmerge.me/developers?page=documents
//  _webmerge_key: q7kb9u
// test url:
http://forms.widgetsign.com/cfs-jotform/?newsalary=55,000&currentsalary=50,000&employeename=George+Jetson&formID=43114998637466&employeeid=12-345&ip=87.68.15.72&submission_id=291287018275470912&effectivedate[]=2014&effectivedate[]=11&effectivedate[]=08&_date_format=ymd|F%20j,%20Y&_date_fields=effectivedate&_webmerge_id=20442&_webmerge_key=q7kb9u


// Date format information: http://php.net/manual/en/function.date.php

require_once ('lib/unirest-php/lib/Unirest.php');
define( 'CFS_API_ERROR', '613' );
define( 'WEBMERGE_API', 'https://www.webmerge.me/merge/' );

class CFS_API {
	private $log_cb = null; // logger
	
	public /*.void.*/ function __construct($log_cb) {
		$this->log_cb = $log_cb;
	}
	private function log ($text, $severity) {
		call_user_func_array($this->log_cb, array($text, $severity));
	}
	
	public function register_routes( $routes ) {
		// The route uses regex to match the incoming url path
		// (?P<id> ... ) names the subpattern. See http://goo.gl/ZD7Zxl
		// \d+ matches 1 or more digits
		// \w+ matches 1 or more letter or digit or the underscore character. See http://goo.gl/PAKpS
		$routes['/cfs/v1/request/(?P<id>\w+)'] = array(
			array(array( $this, 'insert'), WP_JSON_Server::CREATABLE),
			array(array( $this, 'get_status'), WP_JSON_Server::READABLE)
		);
		$routes['/cfs/v1/process_signed/(?P<id>\w+)'] = array(
			array(array( $this, 'process_signed'), WP_JSON_Server::CREATABLE),
		);
		return $routes;
	}
    
	private function err ($msg) {
		return new WP_Error( CFS_API_ERROR, $msg, array( 'status' => 400 ) );
	}
	
	public function insert ($id) {
		// A form has been submitted. Run it through WebMerge and then get
		// it signed via Web Agent.
		//
		// Arguments
		//   $id -- used to look up the form from transient storage

		// response format: 
		//	['redirect_url' => The url for the iFrame, 'sessionId' => sessionId from CoSign Web Agent]
		
		$args = get_transient( $id );
		if ($args === false) {
			$this->log ("Request {$id}: Form data not found", CFS_FATALERROR);
			return $this->err("Could not find form data");
		}
		$this->update_status($id, "<p>Step 1: WebMerge...</p>");
		
		$err = array();
		// Check that we have everything we need
		if (! $args['_date_format'])  { $err[] = '_date_format'; }
		if (! $args['_date_fields'])  { $err[] = '_date_fields'; }
		if (! $args['_webmerge_id'])  { $err[] = '_webmerge_id'; }
		if (! $args['_webmerge_key']) { $err[] = '_webmerge_key'; }
		if (count($err) > 0) {
			$this->log ("Request {$id}: Missing fields " . implode(", ", $err), CFS_FATALERROR);
			return $this->err("Missing fields " . implode(", ", $err));
		}
		
		// Optional
		// _signer_name,
		// _signer_pw,
		// We don't want to send the CoSign Signer name and pw to WebMerge, so remove them from args
		$_signer_name = $args['_signer_name'] ? $args['_signer_name'] : false;
		unset($args['_signer_name']);
		$_signer_pw = $args['_signer_pw'] ? $args['_signer_pw'] : false;
		unset($args['_signer_pw']);
		
		// _signer_name_field
		// _signer_pw_field
		// These optional fields are used as another level of re-direction for the 
		// real signer_name and signer_pw fields.
		// They're needed when the field names can't be set and we need to 
		// use the label names instead (eg GravityForms)
		// Usage: put the signer name and pw field names as the values for these fields
		if (!empty($args['_signer_name_field'])) {
			$_signer_name = $args[$args['_signer_name_field']];
			unset($args[$args['_signer_name_field']]);
		}
		if (!empty($args['_signer_pw_field'])) {
			$_signer_pw = $args[$args['_signer_pw_field']];
			unset($args[$args['_signer_pw_field']]);
		}
		
		// Do the WebMerge!!
		try {
		  $time_start = microtime(true);
		  $wm_url = WEBMERGE_API . $args['_webmerge_id'] . '/' . $args['_webmerge_key'] . '?download=1';
		  if ($args['_webmerge_test']) {
			$wm_url .= "&test=" . $args['_webmerge_test'];
			}
		    // See https://www.webmerge.me/developers?page=documents
		  $wm_response_obj = Unirest::post($wm_url, array("Content-Type" => "application/json"), json_encode($args));
		  $time_end = microtime(true);
		  $time_sec = round($time_end - $time_start, 2);
		  $this->log ("Request {$id}: WebMerge time: $time_sec seconds" , CFS_NOTICE);
		  // Normally WebMerge returns 201, "Created" for successful merges
		  if ($wm_response_obj->code !== 201) {
			$this->log ("Request {$id}: WebMerge issue, they returned status code $wm_response_obj->code", CFS_FATALERROR);
			return $this->err("WebMerge issue, they returned status code $wm_response_obj->code");
		  }
		  if ($wm_response_obj->headers["Content-Type"] !== "application/pdf") {
			$this->log ("Request {$id}: WebMerge issue, they returned content type {$wm_response_obj->headers['Content-Type']}, pdf was expected", CFS_FATALERROR);
			return $this->err("WebMerge issue, they returned content type {$wm_response_obj->headers['Content-Type']}, pdf was expected");
		  }
		  
		  // eg string(58) "attachment; filename="Salary notice -- George Jetson.pdf";"
		  $matches = array();
		  preg_match("/attachment; filename=\"(?P<filename>[\- \.\w]+)\"\;/", 
			$wm_response_obj->headers["Content-Disposition"], $matches);
		  $pdf_name = $matches['filename'];
		  $args['__pdf_name'] = $pdf_name;
		  $pdf_file = $wm_response_obj->raw_body;
		  
		} catch (Exception $e) {
			$time_end = microtime(true);
			return $this->err("WebMerge issue: " . $e->getMessage());
		}
		$this->update_status($id, "<p>Step 1: WebMerge...done.</p><p>Step 2: CoSign Web Agent...</p>");
		
		// CoSign Web Agent!!
		global $cosign_web_agent;
		$time_start = microtime(true);
		$cwa_upload = $cosign_web_agent->prepare ($pdf_file, 'pdf', $pdf_name, array( 
			'username' => $_signer_name, 
			'userpw' => $_signer_pw,
			'file_id' => $id,
			'finishURL' => $args['__finishURL']
		));
		$time_end = microtime(true);
		$time_sec = round($time_end - $time_start, 2);
		$this->log ("Request {$id}: Web Agent upload time: $time_sec seconds" , CFS_NOTICE);
		if ( $cwa_upload['code'] !== 0 ) {
			// problem!
			$this->log ("Request {$id}: Web Agent issue: " . $cwa_upload['errmsg'], CFS_FATALERROR);
			return $this->err("Web Agent issue: " . $cwa_upload['errmsg']);
		}
		$this->update_status($id, "<p>Step 1: WebMerge...done.</p><p>Step 2: CoSign Web Agent...done.</p>");
		// All's good!
		$args['__sessionID'] = $cwa_upload['sessionID'];
		set_transient( $id, $args, HOUR_IN_SECONDS );
		$response = array('redirect_url' => $cwa_upload['redirect'], 'sessionId' => $cwa_upload['sessionID']);
		return $response;
	}
	
	public function process_signed($id) {
		// The document was signed. This function is called by the Thank You
		// page. We fetch the signed document from Web Agent and strore it locally.

		$args = get_transient( $id );
		if ($args === false) {
			$this->log ("Request {$id}: Fetch signed file: Could not find form data!", CFS_FATALERROR);
			return $this->err("Could not find form data");
		}

		global $cosign_web_agent;
		$time_start = microtime(true);
		$info = $cosign_web_agent->get_signed_file ($args['__sessionID'], $args['__signed_file_path']);
		$time_end = microtime(true);
		$time_sec = round($time_end - $time_start, 2);
		$this->log ("Request {$id}: Fetch signed file: $time_sec seconds" , CFS_NOTICE);
		
		if ($info['error']) {
			$this->log ("Request {$id}: Fetch signed file: " . $info['error'], CFS_FATALERROR);
			return $this->err($info['error']);
		}
		return array('msg' => "File stored: {$args['__signed_file_path']}");
	}
	
	private function update_status($id, $msg) { 
		set_transient( $this->status_id($id), $msg, HOUR_IN_SECONDS );
	}
	
	private function status_id ($id) {
		return $id . "_status";
	}
	
	public function get_status ($id) {
		$status = get_transient( $this->status_id($id) );
		if ($status === false) {
			$status = "<p>Working...</p>";
		}

		return ['msg' => $status];
	}
}
