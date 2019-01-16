<?php

try
{
	// Custom Values
	$filePath 		= 'c:/temp/demo.pdf';  	// File to sign
	$fileMimeType	= 'application/pdf';	// File MIME type
	$username 		= '{signer_username}';  // CoSign account username
	$password 		= '{signer_password}';	// CoSign account password
	$domain   		= '';                 	// CoSign account domain
	$sigPageNum		= 1;				    // Create signature on the first page
	$sigX			= 145;					// Signature field X location
	$sigY			= 125;					// Signature field Y location
	$sigWidth		= 160;					// Signature field width
	$sigHeight		= 45;					// Signature field height
	$timeFormat		= 'hh:mm:ss';			// The display format of the time
	$dateFormat		= 'dd/MM/yyyy';			// The display format of the date
	$appearanceMask	= 11;					// Elements to display on the signature field (11 = Graphica image + Signer name + Time)
	$signatureType	= 'http://arx.com/SAPIWS/DSS/1.0/signature-field-create-sign';	// The actual operation of the Sign Request function
	$wsdlUrl       	= 'https://prime-dsa-devctr.docusign.net:8080/sapiws/dss.asmx?WSDL';	// URL to the WSDL file
	
	// Read file contents
	$contents = @file_get_contents($filePath);
	if ($contents === False)
		throw new Exception('Cannot read file: ' . $filePath);
	
	// Set file contents + MIME type (the SOAP library automatically base64 encodes the data)
	$document = array(
		'Base64Data' => array(
			'_' => $contents,
			'MimeType' => $fileMimeType
		)
	);
	
	// Set user credentials. In case of Active Directory, the domain name should be defined in the NameQualifier attribute
	$claimedIdentidy = array(
		'Name' => array(
			'_' => $username,
			'NameQualifier' => $domain
		),
		'SupportingInfo' => array(
			'LogonPassword' => $password
		)
	);
	
	// Define signature field settings
	$SAPISigFieldSettings = array(
		'Invisible' => false,
		'X' => $sigX,
		'Y' => $sigY,
		'Width' => $sigWidth,
		'Height' => $sigHeight,
		'Page' => $sigPageNum,
		'AppearanceMask' => $appearanceMask,
		'TimeFormat' => array(
			'ExtTimeFormat' => 'GMT',
			'DateFormat' => $dateFormat,
			'TimeFormat' => $timeFormat
		)
	);
	
	// Build complete request object
	$signRequest = array(
		'SignRequest' => array(
			'OptionalInputs' => array(
				'ClaimedIdentity' => $claimedIdentidy,
				'SignatureType' => $signatureType,
				'SAPISigFieldSettings' => $SAPISigFieldSettings,
				'ReturnPDFTailOnly' => true		// Enable PDFTailOnly feature (Signature object is returned instead of the whole file)
			),
			'InputDocuments' => array(
				'Document' => $document
			)
		)
	);
	
	// Initiate SOAP client
	$client = new SoapClient(
		$wsdlUrl,
		array(
			'stream_context'=>stream_context_create(array(
				'ssl' => array(
					'verify_peer' => true,
					'cafile' => __DIR__ . '/cacert.pem',
					'CN_match' => 'prime-dsa-devctr.docusign.net'
				)
			)
		)
	));
	
	// Send the request
	$output = $client->DssSign($signRequest);

	// Check response output
	if ( $output->DssSignResult->Result->ResultMajor == "urn:oasis:names:tc:dss:1.0:resultmajor:Success")
	{
		// On success- append signature object to the source PDF document (the SOAP library automatically decodes the base64 encoded output)
		$value = $output->DssSignResult->SignatureObject->Base64Signature;
		file_put_contents($filePath, $value->_, FILE_APPEND);
	}
	else
	{
		// On failure- raise exception with the result error message
		throw new Exception($output->DssSignResult->Result->ResultMessage->_);
	}
	
	echo "The document has been successfully signed!";
}
catch (Exception $e)
{
	echo "Error: " . $e->getMessage();
}
	
?>