<?php
// utils.php
//
// Copyright 2014 (c) by Larry Kluger
// License: The MIT License. See http://opensource.org/licenses/MIT
//
// Utility Library
//
// Error if called separately

//============================================================+
// cfs_encode_parms -- encode an associative array as query string
// ARGS
//   $a -- array to be encoded
// RETURNS 
//   $r -- a string
//============================================================+
function cfs_encode_parms($a) {
	$first = true;
	$r = "";
	foreach ($a as $k => $v) {
		if (! $first) {
			$r .= "&";
		}
		$first = false;
		$r .= $k . "=" . urlencode($v);
	}
	return $r;
}

//============================================================+
// cfs_url_for -- returns the url for a file
// ARGS
//   $for -- supply the url for this file or path/file
//============================================================+
function cfs_url_for($for)
{
  return cfs_url_dir() . $for; 
}

//============================================================+
// cfs_api_url -- returns the complete url for an api end point
// ARGS
//   $ep -- the end point. Include leading /
//============================================================+

function cfs_api_url($ep)
{
  return cfs_url_server() . '/wp-json' . $ep; 
}

function cfs_url_server()
{
  cfs_fix_request_uri();
  $server_port = $_SERVER['SERVER_PORT'];
  $https = (!empty($_SERVER['HTTPS']) && $_SERVER['HTTPS'] !== 'off' || $server_port == 443);
  $scheme = $https ? "https://" : "http://";
  $host = $_SERVER['SERVER_NAME'];
  
  $port = "";
  if (($https  && $server_port <> 443) || 
      (!$https && $server_port <> 80)) {
    $port = ":" . $server_port;
  }
    
  return $scheme . $host . $port; 
}


// cfs_url_dir returns the url path for the current doc's directory.
// It includes the trailing /
function cfs_url_dir()
{
  $url_server = cfs_url_server();
  $parts = parse_url($_SERVER['REQUEST_URI']); // see http://php.net/manual/en/function.parse-url.php  
  $path = $parts['path']; //  /foo.php  or /a/b/foo.php

  $path_parts = preg_split("[\/]", $path);
  array_pop ($path_parts);
  
  return $url_server . implode('/', $path_parts) . (count($path_parts) > 0 ? '/' : '');  
}

// request_uri is not set on some IIS servers
function cfs_fix_request_uri() 
{ 
  if (!isset($_SERVER['REQUEST_URI'])) {
    $_SERVER['REQUEST_URI'] = substr($_SERVER['PHP_SELF'],0);

    if (isset($_SERVER['QUERY_STRING']) && $_SERVER['QUERY_STRING'] != '') {
      $_SERVER['REQUEST_URI'] .= '?'.$_SERVER['QUERY_STRING'];
    }
  }
}

function cfs_LogToWebServer($Message) {
	error_log ($Message);

	$stderr = fopen('php://stderr', 'w'); 
    fwrite($stderr, APP_NAME . " " . $Message); 
    fclose($stderr); 
}
