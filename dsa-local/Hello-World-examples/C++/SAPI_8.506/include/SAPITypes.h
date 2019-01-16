#ifndef __SAPITYPES_H__
#define __SAPITYPES_H__

/*
 * Windows like type definitions
 */
#ifndef DONT_OVERLOAD_TYPE_DEFINITIONS
#define DONT_OVERLOAD_TYPE_DEFINITIONS
#include "wintypes.h"
#endif

#include "SAPIConsts.h"
#include "SAPIEnums.h"

typedef void			*SAPI_SES_HANDLE;
typedef void			*SAPI_GR_IMG_HANDLE;
typedef void			*SAPI_SIG_FIELD_HANDLE;
typedef void			*SAPI_CERT_HANDLE;
typedef void			*SAPI_FILE_HANDLE;
typedef int             SAPI_BOOL;

typedef void (SAPI_WINAPI *SAPI_PROGRESS_CALLBACK)(
							SAPI_ENUM_PROGRESS_CALLBACK_OPERATION	Operation,
							void									*Arg);

typedef void (SAPI_WINAPI *SAPI_CALC_CREDENTIALS_CALLBACK)(
											unsigned char	*Password,
											unsigned long	PasswordLen,
											unsigned char	*CalcCredential,
											unsigned long	*CalcCredentialLen,
											unsigned char	*ExtraCredential,
											unsigned long	*ExtraCredentialLen);

typedef struct _SAPI_CONTEXT 
{
	SAPI_ENUM_CONTEXT_TYPE	ContextType;
	void					*OpaqueData;
}SAPI_CONTEXT;

typedef struct {
	SAPI_ENUM_EXTENDED_TIME_FORMAT	ExtTimeFormat; // system time, with GMT etc.
	SAPI_WCHAR						DateFormat[DATE_FORMAT_MAX_LEN]; // for example "dd/mm/yyyy"
	SAPI_WCHAR						TimeFormat[TIME_FORMAT_MAX_LEN]; // for example "hh:mm:ss"
}SAPI_SF_TIME_FORMAT_STRUCT;
/*
 * This structure holds all the information that is set while creating the field
 *  None of the fields in this structure is supposed to be changed because of the
 *	signing operation
 */

#define MAX_SUGGESTED_SIGNER_NAME 64
#define MAX_SUGGESTED_TITLE_NAME 64
#define MAX_SUGGESTED_EMAIL 64
#define MAX_SIGNING_INSTRUCTION 128
#define MAX_GENERAL_PROPERTY_SIZE 256

typedef struct
{
	unsigned long				StructLen;		// The length of this structure (not including the strings it points at)
	SAPI_WCHAR					SuggestedSignerName[MAX_SUGGESTED_SIGNER_NAME];
    SAPI_WCHAR                  SuggestedTitle[MAX_SUGGESTED_TITLE_NAME];
    SAPI_WCHAR                  SuggestedEmail[MAX_SUGGESTED_EMAIL];
    SAPI_WCHAR                  SigningInstruction[MAX_SIGNING_INSTRUCTION];
    SAPI_BOOL                   AllowComment;
} SAPI_SIG_FIELD_SETTINGS_OXMLP_EXT, *PSAPI_SIG_FIELD_SETTINGS_OXMLP_EXT;

typedef struct
{
	unsigned long				StructLen;		// The length of this structure (not including the strings it points at)
	SAPI_WCHAR					Name[SIGNATURE_FIELD_NAME_MAX_LEN];			// name of the signature field
	SAPI_ENUM_DEPENDENCY_MODE	DependencyMode; // whether it is a dependent or indepentent signature field
	SAPI_ENUM_SIGNATURE_TYPE	SignatureType;	// digital/electronic
	long						Page;			//page where the field is placed (0 for first, max long for last)
	long						X;				// X coordinate of the left bottom corner
	long						Y;				// Y coordinate of the left bottom corner
	long						Height;			// Height in pixels
	long						Width;			// width in pixels
	unsigned long				AppearanceMask;	// a bit for each attribute that is displayed (reason, date etc.)
	unsigned long				LabelsMask;		// a bit for each label that says whether this label is displayed or not
	SAPI_SF_TIME_FORMAT_STRUCT	TimeFormat;		// the way the time is displayed
	SAPI_WCHAR					EmptyFieldLabel[EMPTY_FIELD_LABEL_MAX_LEN];	// what string to display when the field is not signed
    SAPI_BOOL                   Invisible;
	unsigned long				Flags;				// signature field flags
	void						*ExtendedInfo;	// A pointer to an extended info structure, currently should be NULL
} SAPI_SIG_FIELD_SETTINGS, *PSAPI_SIG_FIELD_SETTINGS;

typedef struct {
	unsigned char					*GraphicImage;
	long							GraphicImageLen;
	SAPI_ENUM_GRAPHIC_IMAGE_FORMAT	GraphicImageFormat;
	long							Width;
	long							Height;
} SAPI_GRAPHIC_IMAGE_STRUCT, *PSAPI_GRAPHIC_IMAGE_STRUCT;


// this structure hold all information available for a singel graphical 
// signature object. it is used to get the info from a handle, create new 
// graphical signature object, or update existing one.
typedef struct _SAPI_GR_IMG_INFO
{
	unsigned long					StructLen;
	SAPI_WCHAR						szGraphicImageName[GR_SIG_NAME_MAX_LEN];
	unsigned long					DataFormat;
	unsigned char					*GraphicImage;
	unsigned long					GraphicImageLen;
	SAPI_ENUM_GRAPHIC_IMAGE_FORMAT	ImageConvertedFormat;
	long							Width;
	long							Height;
	long							DataType;		// The attribute has been added to differ the logo/initials/image 
} SAPI_GR_IMG_INFO, *PSAPI_GR_IMG_INFO;




typedef struct
{
	unsigned long				StructLen;		// The length of this structure (not including the strings it points at)
	SAPI_LPWSTR					SignerName;		// Signer name as displayed in the common name field
	SAPI_BOOL				    IsSigned;		// A flag indicating whether the field is signed or not
	unsigned char				*Certificate;	// The raw certificate
	long						CertificateLen;	// The raw certificate length
	SAPI_FILETIME				SignatureTime;	// time when the file was signed
	SAPI_LPWSTR					Reason;			// Reason as stored in the file (not necessarily displayed)
	PSAPI_GRAPHIC_IMAGE_STRUCT	GraphicImageStruct;	// raw data of the graphic image (the format might be different from one file type to another)
													// length of raw data of the graphic image 
	SAPI_LPWSTR					DependencyString;	// A list of signature field names this field depends on
	PSAPI_GRAPHIC_IMAGE_STRUCT	GraphicLogoStruct;	// raw data of the graphic Logo (the format might be different from one file type to another)
} SAPI_SIGNED_FIELD_INFO, *PSAPI_SIGNED_FIELD_INFO;

typedef struct {
	SAPI_BOOL		VerifyModeOnly;
	unsigned long	MajorVersion;
	unsigned long	MinorVersion;
}SAPI_INFO_STRUCT, *PSAPI_INFO_STRUCT;

typedef struct {
	SAPI_ENUM_CERT_STATUS	SAPICertStatus;
	unsigned long			OSCertStatus;
} SAPI_CERT_STATUS_STRUCT, *PSAPI_CERT_STATUS_STRUCT;

typedef struct {
	int					ID;
	SAPI_ENUM_DATA_TYPE Type;
	unsigned char		*Value;
	unsigned long		ValueLen;
} SAPI_CUSTOM_FIELD_ELEMENT_STRUCT;

typedef struct {
	int									StructLen;
	int									Version;
	int									NumOfElements;
	SAPI_CUSTOM_FIELD_ELEMENT_STRUCT	CustomFieldsArray[MAX_NUM_OF_CUSTOM_FIELDS];
} SAPI_CUSTOM_FIELD_ELEMENTS_STRUCT, *PSAPI_CUSTOM_FIELD_ELEMENTS_STRUCT;

typedef struct
{
	unsigned long  	Major;
	unsigned long  	Minor;
} SAPI_TOKEN_VERSION;

typedef struct {
	SAPI_WCHAR					TokenID[TOKEN_ID_MAX_LEN];
	SAPI_TOKEN_VERSION			Firmware;
	SAPI_TOKEN_VERSION			Hardware;
	SAPI_WCHAR  				SerialNumber[SERVER_SERIAL_NUMBER_LEN];
	unsigned long				TokenTime;
	int							InstallStatus;
	SAPI_ENUM_SERVER_KIND		ServerKind;
	SAPI_ENUM_DIRECTORY_KIND	DirectoryKind;
    unsigned long				SubDirectoryKind;
	SAPI_ENUM_AUTH_MODE			AuthMode;
	SAPI_ENUM_AUTH_MODE			AuthMode2;
	long						ClusterId;
	void						*ExtendedInfo;
} SAPI_TOKEN_INFO_STRUCT;

typedef __int64 SAPI_TECH_ID;

typedef struct
{
	SAPI_TECH_ID				CATechID;
	SAPI_ENUM_CA_TYPE 			Type;
	SAPI_WCHAR					Name[SAPI_MAX_CA_NAME_LENGTH];
	SAPI_WCHAR					Description[SAPI_MAX_DESCRIPTION_LENGTH];
	SAPI_ENUM_CA_ROLE			CARole; // default CA
	SAPI_ENUM_CA_STATUS			CAStatus;
}SAPI_CA_RECORD_ANONYMOUS;

#endif