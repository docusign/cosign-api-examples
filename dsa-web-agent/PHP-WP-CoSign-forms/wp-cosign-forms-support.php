<?php
/**
 * Author: Larry Kluger
 * Plugin Name: WP CoSign Forms Support
 * Author URI: http://developer.arx.com
 * Plugin URI: http://developer.arx.com
 * Description: Enables SaaS forms to be digitally signed with CoSign.
 * Version: 1.0.0
 * License: MIT
 */
 
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

/*
These two fields control the conversion of date fields.
Multiple date fields can be separated by a comma
_date_format=ymd|F%20j,%20Y
_date_fields=effectivedate
*/

define( 'WEBAGENT_URL', 'https://webagentdev.arx.com/' );
define( 'CFS_THANK_YOU', 'cfs_thankyou' );
define( 'CFS_DOWNLOAD', 'cfs_download' );
define( 'CFS_VERSION', '0.0.5' );
define( 'CFS_JOTFORM', 'JotForm' );
define( 'CFS_GRAVITYFORMS', 'GravityForms' );
define( 'CFS_SIGNED_FILES_DIR', 'signed_files' ); // in the plugin dir
define( 'CFS_OPTIONS', 'CoSign_Form_Service' ); // in the plugin dir

define( 'CFS_DEBUG', 1 ); // WLS_INFO = 1
define( 'CFS_NOTICE', 2 ); // WLS_NOTICE = 2
define( 'CFS_WARNING', 3 ); // WLS_WARNING = 3
define( 'CFS_ERROR', 4 ); // WLS_ERROR = 4
define( 'CFS_FATALERROR', 5 ); // WLS_FATALERROR = 5

define( 'CFS_LOGGER_UNKNOWN', 1 );
define( 'CFS_LOGGER_BAD', 2 );
define( 'CFS_LOGGER_GOOD', 3 );

if ( !class_exists( 'CoSign_Forms_Support' ) ) {
	class CoSign_Forms_Support {
		private $options = array();
		private $urls = array();
		private $cosign_web_agent = false;
		private $logger = CFS_LOGGER_UNKNOWN;

		public /*.void.*/ function __construct() {
			register_activation_hook( __FILE__, array( $this, 'cfs_activation' ) );
			register_deactivation_hook( __FILE__, array( 'CoSign_Forms_Support', 'cfs_uninstall' ) );
			register_uninstall_hook( __FILE__, array( 'CoSign_Forms_Support', 'cfs_uninstall' ) );
			
			// For internationalization
			// add_action( 'init', array( $this, 'cfs_i18n_init' ), 10, 1 );
					
			add_action( 'admin_menu', array($this, 'cfs_add_admin_menu') );
			add_action( 'admin_init', array($this, 'cfs_settings_init') );

			global $cosign_web_agent;
			$cosign_web_agent = new CoSign_Web_Agent($this->get_webagent_url());

			$this->cfs_url_init();
			$this->thank_you_download_init();
			add_action( 'wp_json_server_before_serve', array( $this, 'cfs_api_init') );
		}

		public /*.void.*/ function cfs_activation() {
			foreach ($this->urls as $url) {
				$url->add_endpoint();
			}
			$this->thank_you_download_add_endpoints();
			flush_rewrite_rules();
			$status = $this->make_signed_files_dir();
			if ($status !== false) {
				die ("<h3>$status</h3>");
			}
		}
		
		public /*.void.*/ function cfs_url_init() {
			$this->urls[CFS_JOTFORM] = new CFS_URL_Jotform($this);  
			$this->urls[CFS_GRAVITYFORMS] = new CFS_URL_gravityforms($this);  
		}

		private /*.void.*/ function thank_you_download_init() {
			// Setup for the thank_you and download urls
			add_action( 'init', array($this, 'thank_you_download_add_endpoints') );
			add_action( 'parse_request', array($this, 'thank_you_download_parse') );		
		}

		public /*.void.*/ function cfs_api_init() {
			$cfs_api = new CFS_API(array($this, 'log'));
			add_filter( 'json_endpoints', array( $cfs_api, 'register_routes' ) );
		}

		public static /*.void.*/ function cfs_uninstall() {
			flush_rewrite_rules();
		}
	
		public function get_webagent_url() {
			$url = $this->get_option( 'web_agent_url');
			// need trailing slash
			if (substr($url, -1, 1) !== '/') {
				$url .= '/';
			}
			return  $url;
		}
		
		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		//
		// Handle incoming Thank you and download page requests
		// After the user finishes signing, CoSign Web Agent redirects to us,
		// to the "thank you" page.
		// The Thank You page does two things:
		//   1. Shows the Thank you or next step or whatever to the user
		//   2. Initiates, via AJAX, the process file call so we fetch the file from Web Agent
		// The Download page returns the file, with the right name and mime type
		public function thank_you_url() {
			return cfs_url_server() . '/' . CFS_THANK_YOU;
		}
		public function download_url() {
			return cfs_url_server() . '/' . CFS_DOWNLOAD;
		}		
		public function download_for_uid_url($uid) {
			return cfs_url_server() . '/' . CFS_DOWNLOAD . "/" . $uid;
		}		
		public function thank_you_download_add_endpoints(){
			add_rewrite_endpoint( CFS_THANK_YOU, EP_ROOT );
			add_rewrite_endpoint( CFS_DOWNLOAD,  EP_ROOT );
		}
		public function thank_you_download_parse( $req ){
			if( array_key_exists( CFS_THANK_YOU, $req->query_vars ) ){
				$this->thank_you_request( $req );
				die;
			}
			if( array_key_exists( CFS_DOWNLOAD, $req->query_vars ) ){
				$this->download_request( $req );
				die;
			}			
		}
		private function thank_you_request ($req) {
			// The user has been redirected to us from the CoSign Web Agent
			// Eg:  https://webapp.org.com/finishURL.aspx?sessionId=12321_3213213&docId=12321&returnCode=0
			// See http://docs.arx.com/CoSign_APIs/doc_v7.1/Default.htm#doc_7.1/Redirecting a User Back to your Web Application.htm
			//
			// * Pull out the query variables
			$args = array();
			$sessionId = $_GET['sessionId'];
			$args['sessionId'] = $sessionId;
			$args['docId'] = $_GET['docId'];
			$args['returnCode'] = $_GET['returnCode'];
			$args['errorMessage'] = $_GET['errorMessage']; // optional

			// At this point, you could look up the original form's args (transient information) via the docId
			// and then use that information to show a specific Thank You page, do something different with the
			// file, etc.
			$this->thank_you_page($args);
		}
		private function download_request ($req) {
			$uid = $req->query_vars['cfs_download'];
			$args = get_transient( $uid );
			$file = $args['__signed_file_path'];
			if ($args === false) {
				echo "<h2>Problem! Could not find data for $uid</h2>";
				return;
			}
			$title = $args['__pdf_name'];
			header("Pragma: public");
			header('Content-Disposition: inline; filename="' . $title . '"'); // See http://tools.ietf.org/html/rfc6266
			header("Content-Type: " . mime_content_type($file));
			header("Content-Transfer-Encoding: binary");
			ob_clean();
			flush();

			$chunksize = 1 * (1024 * 1024); // how many bytes per chunk
			if (filesize($file) > $chunksize) {
				$handle = fopen($file, 'rb');
				$buffer = '';

				while (!feof($handle)) {
					$buffer = fread($handle, $chunksize);
					echo $buffer;
					ob_flush();
					flush();
				}
				fclose($handle);
			} else {
				readfile($file);
			}		
		}
		private function thank_you_page($args) {
			// Show thank you page after the doc was signed or rejected
			// If the document was signed (returnCode == 0) then the 
			// Javascript will POST to 
			$sessionId = $args['sessionId'];
			$docId = $args['docId'];
			$code = $args['returnCode'];
			$msg = $args['errorMessage'];
			$json_info = json_encode (array('sessionId' => $sessionId,
				'uid' => $docId, 'code' => $code, 'msg' => $msg,
				'download_url' => $this->download_for_uid_url($docId)));
			
			cfs_show_header(plugins_url( '', __FILE__ ), "Processing the file");
			?>
			<div class="container theme-showcase" role="main">
			  <!-- Main jumbotron for a primary marketing message or call to action -->
			  <div class="jumbotron">
				<div id="signedDiv" class="hide">
					<h2>Signed!</h2>
					<h3 id="msg1">We're processing the file... <span id="countDown"></span></h2>
					<p><a id='download_btn' class='btn btn-large btn-success hide' href='#'>Download the file!</a></p>
				</div>
				<div id="rejectedDiv" class="hide">
					<h2>Rejected!</h2>
					<p class='lead'>You rejected the signing request with reason: <?php echo $msg; ?></p> 
				</div>
				<div id="cancelledDiv" class="hide">
					<h2>Cancelled!</h2>
					<p class='lead'>You cancelled the signing request</p> 
				</div>
				<div id="noSignDiv" class="hide">
					<h2>Problem!</h2>
					<p class='lead'><?php echo $msg; ?></p> 
				</div>

				<div id="msg2"></div>
				<div id="msg3"></div>
				<div id="errmsg"></div>
			  </div>
			</div> <!-- / .container -->
			<?php
			cfs_show_js_libs();
			?>
			<script type='text/javascript'>
				var cfs_webagent_info = jQuery.parseJSON('<?php echo $json_info; ?>');
				// we choose what to show here. See the JS file for the rest of the story
				jQuery(function($, undefined) {
					var code = cfs_webagent_info.code;
					if (code === '0') {  // good_signing
						$("#signedDiv").removeClass('hide');
						$('#download_btn').on('click', function (e) {
							window.location = cfs_webagent_info.download_url;
						});
					} else if (code === '-2') {
						$("#cancelledDiv").removeClass('hide');
					} else if (code === '-3') {
						$("#rejectedDiv").removeClass('hide');
					} else {
						$("#noSignDiv").removeClass('hide');
					}
				});
			</script>
			<?php
			$js_path = plugins_url( '/js/thank_you_page.js', __FILE__ );
			echo "\n<script src='${js_path}'></script>\n";
			cfs_show_footer();
		}


		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		//
		// Process the form submission
		public function form_submission($args) {
			// Called when a form is submitted
			// * Add the __finishURL if not set
			// * Store it in temp storage
			// * Output "busy page" that includes the UID. The page will then do an AJAX request
			//   that will start the processing of the form data
		
			// Some housekeeping--garbage collect the old signed files
			$this->gc_files_dir();
			
			$UID = $args['__UID'];

			if ($this->debug_mode()) {
				$this->log ("Request {$UID}:Incoming form values: " . $this->var_dump($args), CFS_DEBUG);
			}
			
			// $args must have a __UID. 
			if ($UID === 0) {
				$this->error_page("Problem! The form id was not provided.", 
					"Please consult your developer.");
				$this->log ("Request missing UID! Incoming form values: " . $this->var_dump($args), CFS_FATALERROR);				
			} else {
				if (! $args['__finishURL']) {
					$args['__finishURL'] = $this->thank_you_url();
				}
				$args['__signed_file_path'] =  $this->signed_files_dir() . "/" . $UID . ".pdf";
				
				if ( $args['_date_format'] && $args['_date_fields']) {
					$args = $this->process_dates($args);
				}
				
				// store the args
				// See http://codex.wordpress.org/Transients_API
				set_transient( $UID, $args, HOUR_IN_SECONDS );
				
				// Send our please wait page
				// The page will then do an Ajax call back to us
				//     using api POST /cfs/v1/request
				$this->please_wait_page($UID);
			}
		}
		
		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		//
		// These two fields control the conversion of date fields.
		// Multiple date fields can be separated by a comma
		// _date_format=ymd|F%20j,%20Y   // before the | is three letters ymd in the order of the incoming values for year, month, day
		// _date_fields=effectivedate
		// Usually date fields are sent as an array. Ifg they are sent as text then prefix with "t" for text
		// and then the dividing character. eg t-ymd|F j, Y
		private function process_dates($args) {
			$date_format = explode ( '|' , $args['_date_format'] );
			$date_order = $date_format[0];
			$date_picture = $date_format[1];
			$date_fields = explode ( ',' , $args['_date_fields'] );
			$date = array();
			date_default_timezone_set('UTC');
			$text_date_field = substr ($date_order, 0, 1) === 't';
		
			foreach ( $date_fields as $date_field ) {
				if ($text_date_field) {
					// date sent as a string
					$date_divider = substr ($date_order, 1, 1);
					$date_split = explode ($date_divider, $args[$date_field]);
					for ($i = 0; $i < 3 ; $i++) {
						$date[substr ( $date_order, $i + 2, 1)] =  $date_split[$i];
					}
				} else {
					// date sent as an array
					for ($i = 0; $i < count($args[$date_field]) ; $i++) {
						$date[substr ( $date_order, $i, 1)] =  $args[$date_field][$i];
					}
				}
				$args[$date_field] = date ( $date_picture, mktime(0, 0, 0, $date["m"], $date["d"], $date["y"]));
					// See http://php.net/manual/en/function.date.php and
					// http://php.net/manual/en/function.mktime.php
			}
			return $args;
		}
		
		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		//
		// Convert labels into fields. This function is used if the form field
		// names can't be set. Eg GravityForms
		// Conversion: All characters other than 0-9a-zA-Z_ are changed to _
		public function label_to_field($label) {
			return preg_replace ( "/[^a-zA-Z0-9_]/" , "_" , $label);
		}
		
		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		//
		// Spinner html
		private function spinner_html() {
			// From See more at: http://cssload.net/#sthash.CYIDmZ69.dpuf
			?>
<div id="floatingBarsG" class="spinner-root">
	<div class="blockG" id="rotateG_01"></div>
	<div class="blockG" id="rotateG_02"></div>
	<div class="blockG" id="rotateG_03"></div>
	<div class="blockG" id="rotateG_04"></div>
	<div class="blockG" id="rotateG_05"></div>
	<div class="blockG" id="rotateG_06"></div>
	<div class="blockG" id="rotateG_07"></div>
	<div class="blockG" id="rotateG_08"></div>
</div>			
			<?php
		}


		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		//
		// Show please_wait_page
		private function please_wait_page($UID) {
			cfs_show_header(plugins_url( '', __FILE__ ), "Please wait");
			?>
			<div class="container theme-showcase" role="main">
			  <!-- Main jumbotron for a primary marketing message or call to action -->
			  <div class="jumbotron">
				<?php $this->spinner_html(); ?>
				<h2 id="msg1">Working... <span id="countDown"></span></h2>
				<div id="msg2"></div>
				<div id="msg3"></div>
				<div id="errmsg"></div>
			  </div>
			</div> <!-- / .container -->
			<?php
			cfs_show_js_libs();
			echo "\n<script type='text/javascript'>var cfs_uid='$UID';</script>";
			$js_path = plugins_url( '/js/wait_page.js', __FILE__ );
			echo "\n<script src='${js_path}'></script>\n";
			cfs_show_footer();
		}

		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		//
		// Show error page
		private function error_page($msg1, $msg2 = false) {
			cfs_show_header(plugins_url( '', __FILE__ ), "Problem!");
			?>
			<div class="container theme-showcase" role="main">
			  <!-- Main jumbotron for a primary marketing message or call to action -->
			  <div class="jumbotron">
				<h2><?php echo $msg1; ?></h2>
				<?php if ($msg2) {echo "<p>$msg2</p>";} ?>
			  </div>
			</div> <!-- / .container -->
			<?php 
			cfs_show_footer();
		}
		
		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		public $services = array (
					array('name' => "JotForm",
						'tag' => CFS_JOTFORM,
						'url' => "http://www.jotform.com/",
						'info' => "<p>First, set your JotForm form to use a <b>Custom URL</b> as the <b>Thank You Page</b><br />Then use <b>Preferences/Advanced Settings</b> and change <b>Send Post Data</b> to <b>Yes</b>.<br />Suggested _date_format value is \"ymd|F j, Y\""
						),
					array('name' => "GravityForms",
						'tag' => CFS_GRAVITYFORMS,
						'url' => "http://www.gravityforms.com/",
						'info' => "<p>GravityForms and this plugin need to be installed on the same WordPress installation.<br />Set the form's Confirmation setting (see Form Settings) to \"Redirect.\" Use the GravityForms service point as the \"Redirect URL.\"<br />Set the Redirect Query String to \"_form_id={form_id}&_entry_id={entry_id}\" with \"Pass Field Data via Query String\" checked.<br />Suggested _date_format value is \"t-ymd|F j, Y\""
						)
					);
										

		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		// 
		// Utilities for the signed_files directory

		// gc_files_dir -- garbage collect the old signed files
		public function gc_files_dir() {
			// clean_files_dir -- remove all files older than GC_TIME
			$dir_name = $this->signed_files_dir();
			// Create recursive dir iterator which skips dot folders
			$it = new RecursiveDirectoryIterator($dir_name, FilesystemIterator::SKIP_DOTS);

			// Maximum depth is 1 level deeper than the base folder
			$oldest = time() - GC_TIME;
			// Loop and reap
			while($it->valid()) {
				if ($it->isFile() && filemtime($it->key()) < $oldest) {unlink($it->key());}
				$it->next();
			}
		}

		public function make_signed_files_dir() {
			$dir_name = $this->signed_files_dir();		
			if(! is_dir($dir_name)) {
				$ok = mkdir ($dir_name, 0755);
				if (! $ok) {
					return ("Couldn't create directory for signed files, $dir_name");
				}
			}
			// Add .htaccess if it's not there
			$ht = $dir_name . "/.htaccess";
			if (!is_file($ht)) {
				file_put_contents ( $ht,  "Deny from all\n" );
			}
			return false; // no problem-o!
		}

		// signed_files_dir -- return full path of the dir for caching signed files
		// Does NOT include final /
		public function signed_files_dir() {
			return plugin_dir_path( __FILE__ ) . CFS_SIGNED_FILES_DIR;
		}
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//
		// Options...
		public function default_options( $option = '' )
		{
			$options = array(
				'web_agent_url' => WEBAGENT_URL,
				'debug' => false,
			);
			if ( !empty( $option ) ) {
				if ( array_key_exists( $option, $options ) ) {
					return $options[$option];
				}
				else {
					return FALSE;
				}
			}
			return $options;
		}
		public function update_options( $options ) {
			if ( empty( $options ) && empty( $this->options ) ) return FALSE;
			if ( !empty( $options ) ) {
				update_option( CFS_OPTIONS, $options );
				$this->options = $options;
			}
			else {
				update_option( CFS_OPTIONS, $this->options );
			}
			return TRUE;
		}
		private function load_options( $force_refresh = FALSE ) {
			if ( empty( $this->options ) || $force_refresh === TRUE ) {
				$this->options = get_option( CFS_OPTIONS );
			}
			if ( empty( $this->options ) ) {
				$this->update_options( $this->default_options() );
			}
		}
		public function get_option( $option ) {
			if ( empty( $option ) ) return NULL;
			$this->load_options( FALSE );
			if ( array_key_exists( $option, $this->options ) ) {
				return $this->options[$option];
			}
			return NULL;
		}
		public function set_option( $option, $value, $save_now = FALSE ) {
			if ( empty( $option ) ) return FALSE;
			$this->load_options( FALSE );
			$this->options[$option] = $value;
			if ( $save_now === TRUE ) {
				$this->update_options( NULL );
			}
			return TRUE;
		}
		public function unset_option( $option, $save_now = FALSE ) {
			if ( empty( $option ) ) return FALSE;
			$this->load_options( FALSE );
			unset( $this->options[$option] );
			if ( $save_now === TRUE ) {
				$this->update_options( NULL );
			}
			return TRUE;
		}
		public function debug_mode () {
			return $this->get_option( 'debug' ) === "1";
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////
		// 
		// Admin stuff was generated using http://wpsettingsapi.jeroensormani.com/
		public function cfs_add_admin_menu(  ) { 
			add_options_page( 'WP CoSign Forms Support', 'WP CoSign Forms Support', 'manage_options', 'cosign_forms_support', array($this,'cfs_options_page') );
		}
		public function cfs_settings_init(  ) { 
			register_setting( 'pluginPage', CFS_OPTIONS );

			add_settings_section(
				'cfs_pluginPage_intro_section', 'Usage', 
				array($this, 'cfs_pluginPage_intro_section_callback'), 
				'pluginPage'
			);

			add_settings_section(
				'cfs_pluginPage_section', 'Settings', 
				array($this, 'cfs_settings_section_callback'), 
				'pluginPage'
			);

			add_settings_field(
				'web_agent_url', 'CoSign Web Agent URL', 
				array($this, 'web_agent_url_render'), 
				'pluginPage',
				'cfs_pluginPage_section'
			);

			add_settings_field( 
				'debug', 'Debug Mode', 
				array($this, 'debug_render'), 
				'pluginPage',
				'cfs_pluginPage_section' 
			);
		}
		public function web_agent_url_render(  ) { 
			$name = CFS_OPTIONS . "[web_agent_url]";
			?>
			<input type='text' name='<?php echo $name; ?>' style='width: 275px;'
			value='<?php echo $this->get_option('web_agent_url'); ?>'>
			<?php
		}
		public function debug_render() {
			$name = CFS_OPTIONS . "[debug]";
			echo "<input name='$name' type='checkbox' value='1' class='code' " . checked( 1, $this->get_option( 'debug' ), false) . " /> Debug mode";
			echo "<p>Debug mode requires the plugin <a href='https://wordpress.org/plugins/wordpress-logging-service/'>WordPress Logging Service</a></p>";
		}
		public function cfs_settings_section_callback(  ) { 
			echo '';
		}
		public function cfs_pluginPage_intro_section_callback () { 
			?>
<p>This plugin provides a gateway service that connects SaaS Form systems such as JotForm with WebMerge.me and uses the CoSign Web Agent to
sign the resulting pdf.</p>
<p><b>How it works</b> The SaaS form's contents are sent to this plugin. It then sends the data to WebMerge.me to be merged with a template. The result is a pdf
file which is then sent to the CoSign Web Agent to be signed by the user. The signed pdf can then be downloaded by the signer. The connection between signing the
original form and signing the resulting pdf is in the foreground. The signer does not have to wait, check email, etc.</p>
<p>Currently, only GravityForms and JotForm are supported. Support for other SaaS Form suppliers such as Wufoo, FormStack, etc, can easily be added.</p>
<h3>Form variables</h3>
<p>The form must include several hidden variables (or fields) to control how the form data is used by WebMerge.me and this gateway:</p>
<ul>
<li><b>_date_fields</b> This field lists the date fields in the form, if any. If you have two or more, then separate their names with commas, but not spaces.</li>
<li><b>_date_format</b> This field describes how to process the date forms including the order of the year, month and day fields, and how you'd like the date displayed.
Use y for year, m for month, and d for day to describe the order of the fields. Often they are in ymd order. Then a vertical bar symbol, |, then describe how you'd like
the date displayed for WebMerge to merge. Eg, F j, Y will print the month as a full name (February, not Feb or 2), then the day of the month, followed by the 4-digit year.  Eg. "ymd|F j, Y" If the form's date fields are sent as simple text, then start the field with tx where x is the separator character used. Eg, for GravityForms, use "t-ymd|F j, Y" for your _date_format.
See the <a href="http://php.net/manual/en/function.date.php">documentation</a> for full information. See form service comments below for suggested values.</li>
<li><b>_webmerge_id</b> This is the webmerge ID for your template file. See the <a href="https://www.webmerge.me/developers?page=documents">WebMerge.me documentation</a> for more information.</li>
<li><b>_webmerge_key</b> This is the webmerge key for your template file.</li>
<li><b>_webmerge_test</b> Optional. If present and set to 1 then the webmerge will be done in test mode.</li>
<li><b>_signer_name</b> Optional. It supplies the signer's name. If present, it is only sent to the CoSign Web Agent.</li>
<li><b>_signer_pw</b> Optional. It supplies the signer's password. If present, it is only sent to the CoSign Web Agent.</li>
<li><b>_signer_name_field and _signer_pw_field</b> Optional. Used as another level of re-direction for the real _signer_name and _signer_pw fields. They're used when only the fields' labels can be set, eg. GravityForms. Usage: put the _signer_name and _signer_pw field names as the values for these fields.</li>
</ul>
<p><b>Form field names for WebMerge</b> For many Form SaaS products, you can set the field names explicitly. For others, including GravityForms, you can only set the label for a field, not its name. In either case, you can turn on the Debug Mode setting (see below) for this plugin, then submit a form. Then see the log, available from the Dashboard/System logs screen, to see the names of the fields that were received. Then use those field names with WebMerge.</p>
<h3>Details for each SaaS Form System</h3>
		<?php	
			foreach ($this->services as $service) {
				$url = cfs_url_server() . '/' . $this->urls[$service['tag']]->endpoint;
				echo "<h4><a href='{$service['url']}'>{$service['name']}</a></h4>{$service['info']}<br/><b>URL: $url</b>";
			}
		
		}
		public function cfs_options_page(  ) { 
			?>
			<form action='options.php' method='post'>
				<h2>WP CoSign Forms Support</h2>
				
				<?php
				settings_fields( 'pluginPage' );
				do_settings_sections( 'pluginPage' );
				submit_button();
				?>
			</form>
			<?php
		}
		
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		public function log($text, $severity) {
			// severity levels:
			// WLS_NOCATEGORY = 0
			// WLS_DEBUG = 1
			// WLS_NOTICE = 2
			// WLS_WARNING = 3
			// WLS_ERROR = 4
			// WLS_FATALERROR = 5
			
			$log_category = 'cfs';
			$log_description = 'WP CoSign Forms Support';

			if ($this->logger === CFS_LOGGER_UNKNOWN) {
				if (function_exists ('wls_simple_log')) {
					$this->logger = CFS_LOGGER_GOOD;
					// register our log category
					// See https://wordpress.org/plugins/wordpress-logging-service/other_notes/
					if (! wls_is_registered( $log_category )) {
						wls_register( $log_category, $log_description );
					}
				} else {
					$this->logger = CFS_LOGGER_BAD;
				}
			}
			
			if ($this->logger === CFS_LOGGER_GOOD) {
				return  wls_log( $log_category, $text, 0, date('c'), get_current_blog_id(), $severity);
			}
		}
		public function var_dump($var) {
			ob_start();
			var_dump($var);
			$a=ob_get_contents();
			ob_end_clean();
			$t = htmlspecialchars($a,ENT_QUOTES); // Escape every HTML special chars (especially > and < )
			return $t;
		}
	}
}

// Instantiate class
if ( class_exists( 'CoSign_Forms_Support' ) ) {
	require_once ( plugin_dir_path( __FILE__ ) . 'cfs-url-jotform.php');
	require_once ( plugin_dir_path( __FILE__ ) . 'cfs-url-gravityforms.php');
	require_once ( plugin_dir_path( __FILE__ ) . 'cfs-api.php');
	require_once ( plugin_dir_path( __FILE__ ) . 'lib/header.php');
	require_once ( plugin_dir_path( __FILE__ ) . 'lib/footer.php');
	require_once ( plugin_dir_path( __FILE__ ) . 'lib/utils.php');
	require_once ( plugin_dir_path( __FILE__ ) . 'lib/cosign_web_agent.php');
	require_once ( plugin_dir_path( __FILE__ ) . 'lib/unirest-php/lib/Unirest.php');

	// start up
	// rumor has it this may need to declared global in order to be available at plugin activation
	$cosign_forms_support = new CoSign_Forms_Support();
	Unirest::verifyPeer(false); // Disables SSL cert validation -- we do this since a 
	                            // typical Windows PHP installation does not include
								// trusted root certs for Curl. By turning off verification,
								// we take of the problem without the need to install the
								// trusted root certs.
	

	if(!function_exists('mime_content_type')) {
		function mime_content_type($filename) {
			$mime_types = array(
				'txt' => 'text/plain',
				'htm' => 'text/html',
				'html' => 'text/html',
				'php' => 'text/html',
				'css' => 'text/css',
				'js' => 'application/javascript',
				'json' => 'application/json',
				'xml' => 'application/xml',
				'swf' => 'application/x-shockwave-flash',
				'flv' => 'video/x-flv',

				// images
				'png' => 'image/png',
				'jpe' => 'image/jpeg',
				'jpeg' => 'image/jpeg',
				'jpg' => 'image/jpeg',
				'gif' => 'image/gif',
				'bmp' => 'image/bmp',
				'ico' => 'image/vnd.microsoft.icon',
				'tiff' => 'image/tiff',
				'tif' => 'image/tiff',
				'svg' => 'image/svg+xml',
				'svgz' => 'image/svg+xml',

				// archives
				'zip' => 'application/zip',
				'rar' => 'application/x-rar-compressed',
				'exe' => 'application/x-msdownload',
				'msi' => 'application/x-msdownload',
				'cab' => 'application/vnd.ms-cab-compressed',

				// audio/video
				'mp3' => 'audio/mpeg',
				'qt' => 'video/quicktime',
				'mov' => 'video/quicktime',

				// adobe
				'pdf' => 'application/pdf',
				'psd' => 'image/vnd.adobe.photoshop',
				'ai' => 'application/postscript',
				'eps' => 'application/postscript',
				'ps' => 'application/postscript',

				// ms office
				'doc' => 'application/msword',
				'rtf' => 'application/rtf',
				'xls' => 'application/vnd.ms-excel',
				'ppt' => 'application/vnd.ms-powerpoint',

				// open office
				'odt' => 'application/vnd.oasis.opendocument.text',
				'ods' => 'application/vnd.oasis.opendocument.spreadsheet',
			);

			$ext = strtolower(array_pop(explode('.',$filename)));
			if (array_key_exists($ext, $mime_types)) {
				return $mime_types[$ext];
			}
			elseif (function_exists('finfo_open')) {
				$finfo = finfo_open(FILEINFO_MIME);
				$mimetype = finfo_file($finfo, $filename);
				finfo_close($finfo);
				return $mimetype;
			}
			else {
				return 'application/octet-stream';
			}
		}
	}
}
