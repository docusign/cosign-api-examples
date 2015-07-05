<?php

// Data from GravityForms
//
// GravityForms can send the form's data as GET query parameters, but
// that isn't reliable if the form holds a lot of data. So instead, we'll
// just send the form_id and entry_id in the GET parameters as _form_id and _entry_id.
// Then look up the form's data using their local PHP API.
//


// Date format information: http://php.net/manual/en/function.date.php
// If you want non-English Day/Month names, then use 

class CFS_URL_Gravityforms {
	public $endpoint = "cfs-gravityforms";
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
		// Handle a Gravityforms incoming form
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
		
		// GravityForms provider 
		$args['__provider'] = CFS_GRAVITYFORMS;
		// Create UID 
		$args['__UID'] = empty($args['_entry_id']) ? 0 : 'GF' . $args['_entry_id'];
		
		$form = GFAPI::get_form($args['_form_id']);
		$entry = GFAPI::get_entry($args['_entry_id']);
		
		$fields = $form["fields"];
		foreach ($fields as $field) {
			$field_label = $field["label"];
			$field_name = $this->cfs->label_to_field($field_label);
			$field_id = $field["id"];
			$args[$field_name] = $entry[$field_id];
		}
		
		//$this->cfs->log("Form object: " . $this->cfs->var_dump($form), 1);
		//$this->cfs->log("Entry object: " . $this->cfs->var_dump($entry), 1);
		
		$this->cfs->form_submission($args);
		
		// echo "\n\n\$req = <h3><pre><code>"; var_dump ($req); echo "</pre></code></h3>\n\n";
		// echo "\n\n\$_GET = <h3><pre><code>"; var_dump ($_GET); echo "</pre></code></h3>\n\n";
	}
}
