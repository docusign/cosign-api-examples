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

// Data from JotForm
//
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
//  _webmerge_id: 34dfw   // see https://www.webmerge.me/developers?page=documents
//  _webmerge_key: 34dfw


// Date format information: http://php.net/manual/en/function.date.php
// If you want non-English Day/Month names, then use 


class CFS_URL_Jotform {
	public $endpoint = "cfs-jotform";
	private $cfs = null;

	public /*.void.*/ function __construct($cfs) {
		// See http://wordpress.stackexchange.com/a/154813/11202
		$this->cfs = $cfs; // save parent
		add_action( 'init', array($this, 'add_endpoint') );
		add_action( 'parse_request', array($this, 'parse') );		
	}
    
	public function add_endpoint(){
		add_rewrite_endpoint( $this->endpoint, EP_ROOT );
	}

	public function parse( $req ){
		if( array_key_exists( $this->endpoint, $req->query_vars ) ){
			$this->request( $req );
			die;
		}
	}

	public function request ($req) {
		// Handle a Jotform incoming form
		// * Create a __UID (unique ID) for the request
		// * Process the form submission

		// * Store it in temp storage
		// * Output "busy page" that includes the UID. The page will then start an AJAX request
		
		// Warm up
		$args = array();
		$args = array_merge( $args, $_GET );
		if (!empty($_POST)) {
			$args = array_merge( $args, $_POST );
		}
		
		// JotForm provider 
		$args['__provider'] = CFS_JOTFORM;
		// Create JotForm UID 
		$args['__UID'] = empty($args['submission_id']) ? 0 : 'JF' . $args['submission_id'];
		
		$this->cfs->form_submission($args);
		
		// echo "\n\n\$req = <h3><pre><code>"; var_dump ($req); echo "</pre></code></h3>\n\n";
		// echo "\n\n\$_GET = <h3><pre><code>"; var_dump ($_GET); echo "</pre></code></h3>\n\n";
	}
}
