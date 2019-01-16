#ifndef __SAPICONSTS_H__
#define __SAPICONSTS_H__

#define OPAQUE_CONTEXT_LENGTH			1024
#define EMPTY_FIELD_LABEL_MAX_LEN		128
#define SIGNATURE_FIELD_NAME_MAX_LEN	128
#define DATE_FORMAT_MAX_LEN				32
#define TIME_FORMAT_MAX_LEN				32
#define GR_SIG_NAME_MAX_LEN				124
#define SAPI_MAX_SIG_INSTRUCT_LEN		256
#define TOKEN_ID_MAX_LEN				50
#define MAX_APPLIANCES					128

#define NUMBER_OF_POSSIBLE_DRAWING_ELEMENTS                 7

// SAPILogon flags
#define SAPI_LOGON_FLAG_TYPE_WRITE_OP							0x00000001

#define SAPI_LOGON_FLAG_TYPE_DIRECT								0x10000000


// The following flags are duplicate in MOB and LLClient:
#define SAPI_LOGON_FLAG_EXTERNAL_COSIGN_SRV						0x20000000

#define SAPI_LOGON_FLAG_AUTH_MODE_SSPI							0x00000100
#define SAPI_LOGON_FLAG_AUTH_MODE_VERIFY_USER_SRV_SIDE			0x00000200
#define SAPI_LOGON_FLAG_AUTH_MODE_SSPI_USRPWD					0x00000400
#define SAPI_LOGON_FLAG_AUTH_MODE_VERIFY_DB_USER_SRV_SIDE		0x00000800
#define SAPI_LOGON_FLAG_AUTH_MODE_SAML_SRV_SIDE					0x00001000
#define SAPI_LOGON_FLAG_AUTH_MODE_JWT_SRV_SIDE					0x00002000


#define SAPI_SIGN_FLAG_USE_PSS_ALG								0x00000001

// SAPIGetTokenInfo flags
#define SAPI_TOKEN_FLAG_TYPE_WRITE_OP			0x00000001

// SAPICertificateGUISelect flags
#define DISPLAY_ALL_CERTS_IN_DIALOG				0x00
#define DONT_DISPLAY_DIALOG_FOR_SINGLE_CERT		0x01

// SAPIGraphicalImageGUISelect flags
#define ALWAYES_DISPLAY_GRAPHICAL_GUI_DIALOG	0x00000002
#define GR_IMG_FLG_ALWAYES_DISPLAY_DIALOG		0x00000002
#define GR_IMG_FLG_ALWAYS_ON_TOP				0x00000004
#define GR_IMG_FLG_EDIT_AUTO_OK					0x00000008
#define GR_IMG_FLG_HIDE_COLOR					0x00000010
#define GR_IMG_FLG_FORCE_EDIT_DLG				0x00001000

// Image type flags should be used by:
// GraphicSigImageEnumInit SAPIGraphicalImageGUISelect
#define AR_GR_FLAG_IMAGE_TYPE					0x00010000
#define AR_GR_FLAG_INITIALS_TYPE				0x00020000
#define AR_GR_FLAG_LOGO_TYPE					0x00040000
#define AR_GR_FLAG_VOLATILE_TYPE				0x01000000
// When adding one of the above flags increment MAX_NUMBER_OF_SIG_DATA_FORMAT too
#define AR_GR_FLAG_ALL_TYPE						0x00FF0000

// Used for the application to notify the signing ceremony that it allows the display of time stamp checkbox
#define AR_DISPLAY_ALLOW_TIMESTAMP				0x02000000

#define MAX_NUMBER_OF_SIG_DATA_FORMAT_FOR		3


//SAPIGraphicalImages Capturing devices IDs
#define CAP_DEV_DLG_ID_AUTOMATIC				0
#define CAP_DEV_DLG_ID_GUI_OR_AUTOMATIC			1
#define CAP_DEV_DLG_ID_VIRTUAL					2
#define CAP_DEV_DLG_ID_TOPAZ					3
#define CAP_DEV_DLG_ID_EPAD						4
#define CAP_DEV_DLG_ID_TABLET_PC				5
#define CAP_DEV_DLG_ID_TEXT						6


// SAPISignatureFieldCreate flags for DOC files
#define AR_WORD_DUMMY_FIELD_CREATION            0x00000001	// Reserved

// SAPISignatureFieldCreate flags for PDF files
#define AR_PDF_FLAG_FIELD_NAME_SET				0x00000080	// indicate field name is set on input

// SAPISignatureFieldCreate flags for TIF files
#define AR_TIFF_FLAG_FIELD_DRAW_BANNER_METHOD	0x00000100	// indicate field drawing method is set to banner style
#define AR_TIFF_FLAG_FIELD_DONOT_CLEAR_EMBEDDED_METHOD	0x00000200	// indicate field clear method on embedded signature is not set


// SAPI_SIG_FIELD_SETTINGS flags for DOC files
#define AR_WORD_XP_COMPATIBLE_FLAG              0x00000001
#define AR_WORD_OUTLOOK_INCOMPATIBLE	        0x00000002  // include document properties summary information
#define AR_WORD_SHAREPOINT_2007_COMPATIBLE	    0x00000004  

// SAPI_SIG_FIELD_SETTINGS flags for PDF files
#define AR_PDF_DISABLE_REASON					0x00000001
#define AR_PDF_SIGN_HORIZONTAL					0x00000002 // include signature split: horizontal
#define AR_PDF_SIGN_VERTICAL					0x00000004 // include signature split: vertical
#define AR_PDF_FIELD_LOCATOR					0x00000008 // Field locator type

// SAPISignatureFieldSign flags for DOC files
#define AR_WORD_REDRAW_SIG_METAFILE_FLAG        0x00000001
#define AR_WORD_OPERTAION_FROM_ADDIN_FLAG       0x00000002	// Reserved
#define AR_WORD_CLEAR_DEPENDENT_SIGNATURES_FLAG 0x00000004	// also used in remove, create, clear
#define AR_WORD_CLEAR_ALL_SIGNATURES_FLAG       0x00000008	// also used in remove, create, clear

// SAPISignatureFieldSign flags for PDF files
#define AR_PDF_FLAG_FILESIGN_LINE		        0x00000010	// use line vectors instead of BMP in graphical image
#define AR_PDF_FLAG_FILESIGN_VERTICAL	        0x00000020	// vertical sinature field organization instead of horizontal
#define AR_PDF_FLAG_CERTIFY						0x00000040  // certify file
#define AR_PDF_FLAG_CERTIFY_2					0x00000040  // certify file flag 2 of 2, same as the old one for backward compatibility
#define AR_PDF_FLAG_CERTIFY_1					0x40000000  // certify file flag 1 of 2, combination of these two flags gives 3 different options:
															// CERTIFY_2 = off, CERTIFY_1 = on - no changes are allowed
															// CERTIFY_2 = on, CERTIFY_1 = off - form filling and signing are allowed
															// CERTIFY_2 = on, CERTIFY_1 = on - annotations and form filling and signing are allowed
//#define AR_PDF_FLAG_FIELD_NAME_SET			0x00000080	// already used in CRETE FIELD flags (passed create||sign to CreateAndSign)
#define AR_PDF_FLAG_RESEERVE_FLAG				0x20000000  // this flag is used internally. Don't use this value
#define AR_PDF_FLAG_FILESIGN_FORCE_GRIMG_ERR	0x80000000  // force error if there is no graphical image
#define AR_PDF_FLAG_ENFORCE_DIGITAL_SIGN_FLAG	0x01000000  // this flag is used internally. Don't use this value

// Added by Ilan Zisser to support features in 7.5
#define AR_PDF_FLAG_CENTER_ALIGN_TEXT_LINES		0x00400000  // Align the text lines of the signature is "center" and not "left"
#define AR_PDF_FLAG_NO_IMAGE_RESIZE				0x00800000  // Do not try to resize graphical image. Fail if there is no room.

// Added by Ilan Zisser to support features in 8.5
#define AR_PDF_FLAG_CLEAR_POLICY_NEVER  		0x00200000  // Puts a custom field with ID of SAPI_ENUM_SIG_FIELD_SETTING_CLEAR_PERMIT and value of SAPI_ENUM_SIG_CLEAR_POLICY_NEVER
#define AR_PDF_FLAG_CLEAR_POLICY_SIGNER_BY_CN	0x00100000  // Puts a custom field with ID of SAPI_ENUM_SIG_FIELD_SETTING_CLEAR_PERMIT and value of SAPI_ENUM_SIG_CLEAR_POLICY_SIGNER_BY_CN



// SAPISignatureFieldSign flags for TIFF files
#define AR_TIFF_FLAG_SIGNING_FLAGS_MASK			0x0000003F	// a mask that covers all the signing flags
#define AR_TIFF_FLAG_PACKBITS_COMPRESSION		0x00000002	// use pack bits compression when creating the banner
#define AR_TIFF_FLAG_GROUP4FAX_COMPRESSION		0x00000004	// use group 4 fax compression when creating the banner

// Field sign flags for XML
#define AR_XML_XML_SIG_TYPE_ENVELOPED			0x00000001	// Envelopped signature
#define AR_XML_XML_SIG_TYPE_ENVELOPING			0x00000002

#define AR_XML_SIG_TYPE_XMLDIGSIG				0x00000008	// regular XML-DigSig
#define AR_XML_SIG_TYPE_XADES_BES				0x00000010	// Advanced sig - XAdES-BES

// SAPISignatureFieldVerify/SAPISignatureFieldVerifyInit flags 
#define DONT_USE_FIELD_TIME_FOR_CERT_VERIFY		0x00000001

// GraphicSigImageEnumInit used for "FormatsPermitted"
#define AR_GR_SIG_DATA_FORMAT_MONO_BMP			0x00000001
#define AR_GR_SIG_DATA_FORMAT_COLOR_BMP			0x00000002
#define AR_GR_SIG_DATA_FORMAT_COLOR_1_BMP		0x00000004
#define AR_GR_SIG_DATA_FORMAT_JPG				0x00000008
#define AR_GR_SIG_DATA_FORMAT_TIFF				0x00000010
#define AR_GR_SIG_DATA_FORMAT_GIF				0x00000020
#define AR_GR_SIG_DATA_FORMAT_UNKNOWN			0x80000000
#define AR_GR_SIG_DATA_FORMAT_ALL				0xFFFFFFFF

// SAPIGraphicSigImageInfoGet flags
#define	AR_GR_SIG_GET_INTERNAL_ALLLOC			0x00000001

// SAPIBufferSignInit / SAPIBufferSign flags
// These flags influence all File providers and should not collide
// with file provider specific flags
#define	AR_SAPI_SIG_ENABLE_STS					0x00000100
#define	AR_GR_SIG_ENABLE_STS					0x00000100
#define	AR_GR_SIG_DISABLE_STS					0x00000200
#define	AR_SAPI_SIG_DISABLE_STS					0x00000200
#define	AR_SAPI_SIG_HASH_ONLY					0x00000400 // the value for the buffer signing is hash and not the data itself
#define	PREDICT_SIGNATURE_SIZE					0x00000800 // return only the expected size of the signature buffer
#define AR_SAPI_SIG_PDF_REVOCATION				0x00001000
#define AR_SAPI_SIG_CAdES_REVOCATION			0x00002000
#define AR_SAPI_SHA256_FLAG						0x00004000
#define AR_SAPI_SHA384_FLAG						0x00008000
#define AR_SAPI_SHA512_FLAG						0x00010000
#define AR_SAPI_SIG_ENFORCE_NO_LOGOUT			0x00020000
#define AR_SAPI_SIG_ENFORCE_LOGOUT				0x00040000
#define AR_SAPI_SIG_PKCS1						0x00080000 // Indicates that a PKCS#1 signature will be produced
#define AR_SAPI_ENFORCE_SHA1_FLAG				0x00100000 // if the application wants to enforce a SHA-1 based signature
#define AR_SAPI_SIG_CREATE_WITH_EMFONLY_FLAG	0x00200000 // Use to avoid mismatch signature appearance in Office and SAPI.
#define AR_SAPI_NO_SIGNING_TIME_ATTR			0x01000000 // Do not include the signing time as an attribute in the PKCS7 

#define ENCAPSULATED_FLAG						0x80000000 // This flag should NOT be used

#define AR_SAPI_SIG_CREDS_TYPE_INTERNAL_OTP		0x04000000

// SAPISignatureFieldEnumInit flags for docx
#define AR_INCLUDE_LEGACY_DOC_FIELDS_FLAG		0x00000001
#define AR_MS_SIGNATURE_LINE_ONLY				0x00000002 // If this flag is set, create a signature line and not an AR signature.

// SAPISignatureFieldEnumInit flags for pdf
#define AR_SAPI_PDF_USE_SIGNER_GMT_OFFSET		0x00000002
#define AR_SAPI_PDF_ALLOW_FIELD_LOCATOR			0x00000004

// LOCATOR MAX STRING LENGTH
#define AR_SF_LOCATOR_MAX_STRING_LENGTH			256
// SAPISignatureFieldLocatorEnumInit flags
#define AR_LOCATOR_TEXT_DIRECTION_AS_PAGE_ROTATION	0x00000001	// flag that indicates that the direction 
																// of the text is as the rotation of the page 
																// which means that if the page rotated 90 clockwise
																// then the text should be from up to down..

// Signature field's custom attributes related constants
#define MAX_NUM_OF_CUSTOM_FIELDS				15
#define CURRENT_CUSTOM_FIELDS_STRUCT_VERSION	1
#define CUSTOM_FIELD_STRUCT_VERSION_10			1

#define COSIGN_BASIC_SLOT_STRING	"AR CoSign Appliance"

// constant for auto logoff
#define AR_SAPI_AUTO_LOGOFF_HANDLE	1

// constant for logoff all users
#define AR_SAPI_LOGOFF_ALL_HANDLE	2

// constant for clear handle
#define CLEAR_HANDLE	(void*)-1

// constant for extended validation
#define PERFORM_EXTENDED_VALIDATION	0x00000001

// constant for graphical image reduction.
#define	PERFORM_IMAGE_REDUCTION_DEFAULT		0xFFFFFFFF
#define	NOT_PERFORM_IMAGE_REDUCTION			0x00000000

// constants for sign ceremony
#define RESERVED_SC_ENABLE_THREAD			0x00000001
#define RESERVED_SC_STORAGE_BASIC_CONFIG	0x00000002

// constants for get token info
#define SERVER_SERIAL_NUMBER_LEN	16


// Values for IDs of custom fields
#define CUSTOM_FIELD_ID_ARX_ELECTRONIC_FIELD	0x4f4d4e49
#define CUSTOM_FIELD_ID_GRSIG_SPACING			68

// constant for Key generate
#define SAPI_KEY_PAIR_4096						0x00000001
#define SAPI_KEY_PAIR_3072						0x00000002

#define MAX_CRYPT_GUID_LENGTH					256

// CA consts - the following were copied from mobconst.h
#define SAPI_MAX_DESCRIPTION_LENGTH				128
#define SAPI_MAX_CA_NAME_LENGTH					128
#define SAPI_MAX_NUMBER_OF_ANON_CA_IN_CONT		50

#endif
