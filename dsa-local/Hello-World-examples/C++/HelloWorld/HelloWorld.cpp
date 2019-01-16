// HelloWorld.cpp : Defines the entry point for the console application.
//

#include <SDKDDKVer.h>
#include <stdio.h>
#include <tchar.h>
#include <stdlib.h>
#include <string.h>
#include "SAPICrypt.h"
#include "SAPIErrors.h"

int _tmain(int argc, _TCHAR* argv[])
{
	int							rc;
	SAPI_SES_HANDLE				hSession;

	// Custom Values
	wchar_t 					*filePath				= L"c:\\temp\\demo.pdf";	// PDF file to sign
	wchar_t 					*username				= L"{signer_username}";		// DSA Account Username
	wchar_t						*password				= L"{signer_password}";		// DSA Account Password
	wchar_t						*domain					= NULL;						// DSA Account Domain
	int							sigPageNum				= 1;						// Create Signature on the first page
	int							sigX					= 145;						// Signature Field X location
	int							sigY					= 125;						// Signature Field Y location
	int							sigWidth				= 160;						// Signature Field Width
	int							sigHeight				= 45;						// Signature Field Height
	wchar_t						*timeFormat				= L"hh:mm:ss";				// Time appearance format mask
	wchar_t						*dateFormat				= L"dd/MM/yyyy";			// Date appearance format mask
	int							appearanceMask			= SAPI_ENUM_DRAWING_ELEMENT_GRAPHICAL_IMAGE |		// Elements to display on the Signature Field
														  SAPI_ENUM_DRAWING_ELEMENT_SIGNED_BY       |
														  SAPI_ENUM_DRAWING_ELEMENT_TIME;

	// Initialize SAPI library
	if ((rc = SAPIInit()) != SAPI_OK)
	{
		printf("Error on SAPIInit, rc = 0x%x, Extended error 0x%x\n", rc, SAPIExtendedLastErrorGet());
		return -1;
	}

	// Acquire SAPI session handle
	if ((rc = SAPIHandleAcquire(&hSession)) != SAPI_OK)
	{
		printf("Error on SAPIHandleAcquire, rc = 0x%x, Extended error 0x%x\n", rc, SAPIExtendedLastErrorGet());
		return -1;
	}

	// Personalize SAPI Session
	if ((rc = SAPILogon(hSession, (SAPI_LPCWSTR) username, (SAPI_LPCWSTR) domain, (unsigned char*) password, (wcslen(password)+1)*2)) != SAPI_OK)
	{
		SAPIHandleRelease (hSession);   // Release memory allocated for Session Handle
		printf("Error on SAPILogon, rc = 0x%x, Extended error 0x%x\n", rc, SAPIExtendedLastErrorGet());
		return -1;
	}

	// Instantiate SAPI_SIG_FIELD_SETTINGS struct
	SAPI_SIG_FIELD_SETTINGS sSigFieldSettings;
	memset(&sSigFieldSettings, 0, sizeof(SAPI_SIG_FIELD_SETTINGS));
	sSigFieldSettings.StructLen	= sizeof(SAPI_SIG_FIELD_SETTINGS);

	// Define Signature Field Settings
	sSigFieldSettings.Page				= sigPageNum;
	sSigFieldSettings.X					= sigX;
	sSigFieldSettings.Y					= sigY;
	sSigFieldSettings.Width				= sigWidth;
	sSigFieldSettings.Height			= sigHeight;
	sSigFieldSettings.AppearanceMask	= appearanceMask;
	sSigFieldSettings.SignatureType		= SAPI_ENUM_SIGNATURE_DIGITAL;
	sSigFieldSettings.DependencyMode	= SAPI_ENUM_DEPENDENCY_MODE_INDEPENDENT;
	swprintf((wchar_t*)sSigFieldSettings.TimeFormat.DateFormat, dateFormat);
	swprintf((wchar_t*)sSigFieldSettings.TimeFormat.TimeFormat, timeFormat);
	sSigFieldSettings.TimeFormat.ExtTimeFormat = SAPI_ENUM_EXTENDED_TIME_FORMAT_GMT;	// Display GMT offset

	// Create and sign a new signature field in the document
	if ( SAPI_OK != (rc = SAPISignatureFieldCreateSign (
		hSession,						// Session Handle
		SAPI_ENUM_FILE_ADOBE,			// Type of the file to sign - PDF
		(SAPI_LPCWSTR)filePath,			// Path to PDF file to sign
		&sSigFieldSettings,				// Signature Field details
		0,								// Flags
		NULL,							// Credentials (only if prompt-for-sign feature is enabled)
		0)))							// Credentials length
	{
		SAPILogoff(hSession);			// Release user context
		SAPIHandleRelease (hSession);   // Release memory allocated for Session Handle
		printf("Error on SAPISignatureFieldCreateSign, rc = 0x%x, Extended error 0x%x\n", rc, SAPIExtendedLastErrorGet());
		return -1;
	}

	// Release all memory allocations
	SAPILogoff(hSession);				// Release user context
	SAPIHandleRelease (hSession);		// Release Session Handle

	printf ("The file has been successfully signed!\n");

	return 0;
}

