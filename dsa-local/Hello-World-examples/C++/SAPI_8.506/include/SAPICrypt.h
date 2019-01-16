#ifndef __SAPICRYPT_H__
#define __SAPICRYPT_H__

#include "SAPITypes.h"

// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the SAPI_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// SAPI functions as being imported from a DLL, wheras this DLL sees symbols
// defined with this macro as being exported.
#ifdef SAPI_EXPORTS
#define SAPI __declspec(dllexport)
//#elif SAPI_INTERNAL
#else
 #ifndef SAPI
 #define SAPI
 #endif
//#else
//#define SAPI __declspec(dllimport)
#endif

#ifdef  __cplusplus
extern  "C" {
#endif

SAPI int SAPIInit();


SAPI int SAPILibInfoGet(
					PSAPI_INFO_STRUCT	SAPIInfoStruct);


SAPI int SAPIExtendedLastErrorGet();


SAPI int SAPIHandleAcquire(
	                SAPI_SES_HANDLE		*Handle);

SAPI int SAPIGetAllTokenIDsEnumInit(
					SAPI_CONTEXT		*TokenIDsContext);

SAPI int SAPIGetAllTokenIDsEnumCont(
					SAPI_CONTEXT		*TokenIDsContext,
					char				*TokenID,
					long				*TokenIDLen);

SAPI int SAPILogon(
	                SAPI_SES_HANDLE		Handle,
	                SAPI_LPCWSTR		UserLoginName,
	                SAPI_LPCWSTR		DomainName,
	                unsigned char		*Password,
	                long				PasswordLen);


SAPI int SAPILogonEx(
	                SAPI_SES_HANDLE		Handle,
	                SAPI_LPCWSTR		UserLoginName,
	                SAPI_LPCWSTR		DomainName,
	                unsigned char		*Password,
	                long				PasswordLen,
					unsigned long		Flags);


SAPI int SAPICAInfoGetInit(
	                SAPI_SES_HANDLE			Handle,
                    SAPI_CONTEXT			*CAInfoContext,
                    SAPI_LPWSTR				CAPublishLocation,
					long					*CAPublishLocationLen,
	                SAPI_ENUM_CA_INFO_TYPE	CAInfoType); // CRL/AIA

SAPI int SAPICAInfoGetInitEx(
	                SAPI_SES_HANDLE			Handle,
                    SAPI_CONTEXT			*CAInfoContext,
					SAPI_LPWSTR				CAName,
                    SAPI_LPWSTR				CAPublishLocation,
					long					*CAPublishLocationLen,
	                SAPI_ENUM_CA_INFO_TYPE	CAInfoType);

SAPI int SAPICAInfoGetCont(
	                SAPI_SES_HANDLE	Handle,
                    SAPI_CONTEXT	*CAInfoContext,
	                unsigned char	*CAInfoBlock, // der encoding
	                long			*CAInfoBlockLen,
                    SAPI_BOOL		*LastBlock); // a flag indicating there is no more data to retrieve

SAPI int SAPIConfigurationValueGet (
						SAPI_SES_HANDLE		Handle,
						SAPI_ENUM_CONF_ID	ConfValueID,
						SAPI_ENUM_DATA_TYPE	*ConfValueType,
						void				*Value,
						unsigned long		*ValueLen,
						SAPI_BOOL			SessionValue);

SAPI int SAPIConfigurationValueSet (
						SAPI_SES_HANDLE		Handle,
						SAPI_ENUM_CONF_ID	ConfValueID,
						SAPI_ENUM_DATA_TYPE	ConfValueType,
						const void			*Value,
						unsigned long		ValueLen,
						SAPI_BOOL			SessionValue);

SAPI int SAPILogoff(
	                SAPI_SES_HANDLE	Handle);


SAPI int SAPIFinalize();


SAPI void SAPIHandleRelease (void *Handle);


SAPI void SAPIContextRelease (SAPI_CONTEXT *Context);


SAPI void SAPIStructRelease (void					*Struct,
							 SAPI_ENUM_STRUCT_TYPE	StructType);
//
SAPI int SAPIGraphicSigImageEnumInit(
						SAPI_SES_HANDLE				Handle,
						SAPI_CONTEXT				*GraphicImageContext,
						unsigned long				FormatsPermitted,
						unsigned long				Flags);

SAPI int SAPIGraphicSigImageEnumCont(
						SAPI_SES_HANDLE				Handle,
						SAPI_CONTEXT				*GraphicImageContext,
						SAPI_GR_IMG_HANDLE			*GraphicImageHandle);

SAPI int SAPIGraphicSigImageInfoGet(
						SAPI_SES_HANDLE					Handle,
						SAPI_GR_IMG_HANDLE				GraphicImageHandle,
						SAPI_GR_IMG_INFO				*GraphicImageInfo,
						SAPI_ENUM_GRAPHIC_IMAGE_FORMAT	Convert,
						unsigned long					Flags);

SAPI int SAPIGraphicSigImageInfoUpdate(
						SAPI_SES_HANDLE				Handle,
						SAPI_GR_IMG_HANDLE			GraphicImageHandle,
						SAPI_GR_IMG_INFO			*GraphicImageInfo,
						unsigned long				Flags);

SAPI int SAPIGraphicSigLogoInfoUpdate(
						SAPI_SES_HANDLE				Handle,
						SAPI_GR_IMG_HANDLE			GraphicImageHandle,
						SAPI_GR_IMG_INFO			*GraphicImageInfo,
						unsigned long				Flags);

SAPI int SAPIGraphicSigInitialsInfoUpdate(
						SAPI_SES_HANDLE				Handle,
						SAPI_GR_IMG_HANDLE			GraphicImageHandle,
						SAPI_GR_IMG_INFO			*GraphicImageInfo,
						unsigned long				Flags);

SAPI int SAPIGraphicSigImageInfoCreate(
						SAPI_SES_HANDLE				Handle,
						SAPI_GR_IMG_HANDLE			*GraphicImageHandle,
						SAPI_GR_IMG_INFO			*GraphicImageInfo);

SAPI int SAPIGraphicSigLogoInfoCreate(
						SAPI_SES_HANDLE				Handle,
						SAPI_GR_IMG_HANDLE			*GraphicImageHandle,
						SAPI_GR_IMG_INFO			*GraphicImageInfo);

SAPI int SAPIGraphicSigInitialsInfoCreate(
						SAPI_SES_HANDLE				Handle,
						SAPI_GR_IMG_HANDLE			*GraphicImageHandle,
						SAPI_GR_IMG_INFO			*GraphicImageInfo);

SAPI int SAPIGraphicSigImageInfoDelete(
						SAPI_SES_HANDLE				Handle,
						SAPI_GR_IMG_HANDLE			GraphicImageHandle);

SAPI int SAPIGraphicSigImageGUISelect (
							SAPI_SES_HANDLE					Handle,
							unsigned long					FormatsPermitted,
							unsigned long					Flags,
							SAPI_ENUM_GR_IMG_SELECT_MODE	Mode,
							SAPI_GR_IMG_HANDLE				*GraphicImageHandle);

SAPI int SAPIGraphicSigImageSetDefault (
							SAPI_SES_HANDLE		Handle,
							SAPI_GR_IMG_HANDLE	GraphicImageHandle);

SAPI int SAPIGraphicSigImageSetDefaultEx (
							SAPI_SES_HANDLE		Handle,
							SAPI_GR_IMG_HANDLE	GraphicImageHandle,
							unsigned long		Flags);

SAPI int SAPIGraphicSigImageGetDefault (
							SAPI_SES_HANDLE		Handle,
							SAPI_GR_IMG_HANDLE	*GraphicImageHandle);


SAPI int SAPIGraphicSigImageGetDefaultEx (
							SAPI_SES_HANDLE		Handle,
							SAPI_GR_IMG_HANDLE	*GraphicImageHandle,
							unsigned long		Flags);


SAPI int SAPIGraphicSigImageGet(
                            SAPI_SES_HANDLE				Handle,
							SAPI_ENUM_IMAGE_SOURCE_TYPE	ImageSource, // can be either token, or PAD
							SAPI_GR_IMG_HANDLE			GraphicImageHandle, //image identifier in case of multiple images 
																	// in token currently must be NULL
							SAPI_GRAPHIC_IMAGE_STRUCT	*GraphicImageStruct);

SAPI int SAPIGraphicSigImageSet(
							SAPI_SES_HANDLE				Handle,
							SAPI_GRAPHIC_IMAGE_STRUCT	*GraphicImageStruct,
							SAPI_GR_IMG_HANDLE			*GraphicImageHandle,
							unsigned long				Flags);


SAPI int SAPISignatureFieldLocatorEnumInit(
							SAPI_SES_HANDLE				Handle,
							SAPI_CONTEXT				*SigFieldLocatorContext,
							SAPI_FILE_HANDLE			FileHandle,
							SAPI_LPWSTR					OpeningPattern,
							SAPI_LPWSTR					ClosingPattern,
							unsigned long				Flags,
							long						*SignatureFieldsLocatedNum);


SAPI int SAPISignatureFieldLocatorEnumCont(
							SAPI_SES_HANDLE				Handle,
							SAPI_CONTEXT				*SigFieldLocatorContext,
							SAPI_SIG_FIELD_SETTINGS		*SigFieldSettings,
							SAPI_LPWSTR					EncodedMessage,
							long						*EncodedMessageLength);


SAPI int SAPISignatureFieldEnumInit(
							SAPI_SES_HANDLE		Handle,
							SAPI_CONTEXT		*SigFieldContext,
							SAPI_ENUM_FILE_TYPE	FileType, 
							SAPI_LPCWSTR		FileUNC,
							unsigned long		Flags, 	
							long				*SignatureFieldsNum);

SAPI int SAPISignatureFieldEnumInitEx(
							SAPI_SES_HANDLE		Handle,
							SAPI_CONTEXT		*SigFieldContext,
							SAPI_ENUM_FILE_TYPE	FileType, 
							SAPI_LPCWSTR		FileUNC,
							SAPI_FILE_HANDLE	FileHandle,
							unsigned long		Flags, 	
							long				*SignatureFieldsNum);


SAPI int SAPISignatureFieldEnumCont(
							SAPI_SES_HANDLE			Handle,
							SAPI_CONTEXT			*SigFieldContext,
							SAPI_SIG_FIELD_HANDLE	*SignatureFieldHandle);

SAPI int SAPISignatureFieldInfoGet(
						SAPI_SES_HANDLE				Handle,
						SAPI_SIG_FIELD_HANDLE		SignatureFieldHandle,
						PSAPI_SIG_FIELD_SETTINGS	SignatureFieldSettingStruct,
						PSAPI_SIGNED_FIELD_INFO		SignedFieldInfoStruct);

SAPI int SAPISignatureFieldDetailsGUIGet(
									SAPI_SES_HANDLE				Handle,
									SAPI_SIG_FIELD_HANDLE		SignatureFieldHandle);

SAPI int SAPISignatureFieldCreate(
							SAPI_SES_HANDLE				Handle,
							SAPI_ENUM_FILE_TYPE			FileType, // Word, Adobe, Tiff
							SAPI_LPCWSTR				FileUNC,
							PSAPI_SIG_FIELD_SETTINGS	NewSignatureFieldStruct,
							unsigned long				Flags, 	
							SAPI_SIG_FIELD_HANDLE		*SignatureFieldHandle);

SAPI int SAPISignatureFieldCreateEx(
							SAPI_SES_HANDLE				Handle,
							SAPI_ENUM_FILE_TYPE			FileType, // Word, Adobe, Tiff
							SAPI_LPCWSTR				FileUNC,
							SAPI_FILE_HANDLE			FileHandle,
							PSAPI_SIG_FIELD_SETTINGS	NewSignatureFieldStruct,
							unsigned long				Flags, 	
							SAPI_SIG_FIELD_HANDLE		*SignatureFieldHandle);

SAPI int SAPISignatureFieldCreateSign(
							SAPI_SES_HANDLE				Handle,
							SAPI_ENUM_FILE_TYPE			FileType,
							SAPI_LPCWSTR				FileUNC,
							PSAPI_SIG_FIELD_SETTINGS	NewSignatureFieldStruct,
							unsigned long				Flags,
						    unsigned char			    *Credential,
						    unsigned long			    CredentialLen);

SAPI int SAPISignatureFieldCreateSignEx(
							SAPI_SES_HANDLE				Handle,
							SAPI_ENUM_FILE_TYPE			FileType,
							SAPI_LPCWSTR				FileUNC,
							SAPI_FILE_HANDLE			FileHandle,
							PSAPI_SIG_FIELD_SETTINGS	NewSignatureFieldStruct,
							unsigned long				Flags,
						    unsigned char			    *Credential,
						    unsigned long			    CredentialLen);

SAPI int SAPISignatureFieldClear(
							SAPI_SES_HANDLE				Handle,
							SAPI_SIG_FIELD_HANDLE		SignatureFieldHandle,
							unsigned long				Flags);

SAPI int SAPISignatureFieldRemove(
							SAPI_SES_HANDLE				Handle,
							SAPI_SIG_FIELD_HANDLE		SignatureFieldHandle,
							unsigned long				Flags);

SAPI int SAPISignatureFieldSign(
                   SAPI_SES_HANDLE			Handle,
				   SAPI_SIG_FIELD_HANDLE	SignatureFieldHandle, 
				   unsigned long			Flags);	  

SAPI int SAPISignatureFieldSignEx(
                   SAPI_SES_HANDLE			Handle,
				   SAPI_SIG_FIELD_HANDLE	SignatureFieldHandle, 
				   unsigned long			Flags,
				   unsigned char			*Credential,
				   unsigned long			CredentialLen);

SAPI int SAPISigningContextPKCS7BlobLenGet(
					                   SAPI_SES_HANDLE	Handle,
									   SAPI_CONTEXT		*SignContext,
									   unsigned long	*SignatureLen);

SAPI int SAPIBufferSign(
                   SAPI_SES_HANDLE	Handle,
				   unsigned char	*Buffer,
				   unsigned long	BufferLen,
				   unsigned char	*SignedData,
				   unsigned long	*SignedDataLen,
				   unsigned long	Flags);

SAPI int SAPIBufferSignEx(
                   SAPI_SES_HANDLE	Handle,
				   unsigned char	*Buffer,
				   unsigned long	BufferLen,
				   unsigned char	*SignedData,
				   unsigned long	*SignedDataLen,
				   unsigned long	Flags,
				   unsigned char	*Credential,
				   unsigned long	CredentialLen);

SAPI int SAPIBufferSignInit(
                   SAPI_SES_HANDLE	Handle,
				   SAPI_CONTEXT		*SignContext,
				   unsigned long	Flags);

SAPI int SAPIBufferSignCont(
                   SAPI_SES_HANDLE	Handle,
				   SAPI_CONTEXT		*SignContext,
				   unsigned char	*Buffer,
				   unsigned long	BufferLen);

SAPI int SAPIBufferSignEnd(
                   SAPI_SES_HANDLE	Handle,
				   SAPI_CONTEXT		*SignContext,
				   unsigned char	*SignedData,
				   unsigned long	*SignedDataLen);

SAPI int SAPIBufferSignEndEx(
                   SAPI_SES_HANDLE	Handle,
				   SAPI_CONTEXT		*SignContext,
				   unsigned char	*SignedData,
				   unsigned long	*SignedDataLen,
				   unsigned char	*Credential,
				   unsigned long	CredentialLen);

SAPI int SAPICertificatesEnumInit(
							SAPI_SES_HANDLE		Handle,
							SAPI_CONTEXT		*CertContext,
							unsigned long		Flags);

SAPI int SAPICertificatesEnumCont(
							SAPI_SES_HANDLE		Handle,
							SAPI_CONTEXT		*CertContext,
							SAPI_CERT_HANDLE	*CertHandle);

SAPI int SAPICertificateGetFieldByHandle(
		                    SAPI_SES_HANDLE			Handle,
							SAPI_CERT_HANDLE		CertHandle,
							SAPI_ENUM_CERT_FIELD	FieldID,
							unsigned char			*Value,
							unsigned long			*ValueLen,
							SAPI_ENUM_DATA_TYPE		*FieldType);

SAPI int SAPICertificateGetFieldByBlob(
		                    SAPI_SES_HANDLE			Handle,
							unsigned char			*EncodedCertificate,
							unsigned long			EncodedCertificateLen,
							SAPI_ENUM_CERT_FIELD	FieldID,
							unsigned char			*Value,
							unsigned long			*ValueLen,
							SAPI_ENUM_DATA_TYPE		*FieldType);

SAPI int SAPIPKCS7BlobGetValue(
	                    SAPI_SES_HANDLE			Handle,
						unsigned char			*PKCS7Blob,
						unsigned long			PKCS7BlobLen,
						SAPI_ENUM_PKCS7_FIELD	FieldID,
						unsigned char			*Value,
						unsigned long			*ValueLen,
						SAPI_ENUM_DATA_TYPE		*FieldType);

SAPI int SAPICertificateGUISelect (
							SAPI_SES_HANDLE		Handle,
							unsigned long		Flags,
							SAPI_CERT_HANDLE	*CertHandle);

SAPI int SAPICertificateSetDefault (
							SAPI_SES_HANDLE		Handle,
							SAPI_CERT_HANDLE	CertHandle);

SAPI int SAPICertificateGetDefault (
							SAPI_SES_HANDLE		Handle,
							SAPI_CERT_HANDLE	*CertHandle);

SAPI int SAPIFileIsSigned(
		                SAPI_SES_HANDLE			Handle,
						SAPI_ENUM_FILE_TYPE		FileType,
						SAPI_LPCWSTR			FileUNC,
						unsigned long			Flags,
						SAPI_BOOL				*IsSigned); 

SAPI int SAPIFileIsSignedEx(
		                SAPI_SES_HANDLE			Handle,
						SAPI_ENUM_FILE_TYPE		FileType,
						SAPI_LPCWSTR			FileUNC,
						SAPI_FILE_HANDLE		FileHandle,
						unsigned long			Flags,
						SAPI_BOOL				*IsSigned); 

SAPI int SAPISignatureFieldVerify(
		                    SAPI_SES_HANDLE			Handle,
							SAPI_SIG_FIELD_HANDLE	SignatureFieldHandle, 
							SAPI_CERT_STATUS_STRUCT	*CertificateStatus,
							unsigned long			Flags);


SAPI int SAPIBufferVerifySignature(
                    SAPI_SES_HANDLE			Handle,
					const unsigned char		*Buffer,
					unsigned long			BufferLen,
					const unsigned char		*SignedData,
					unsigned long			SignedDataLen,
					SAPI_FILETIME			*SignatureTime,
					SAPI_CERT_STATUS_STRUCT	*CertificateStatus,
					unsigned long			Flags);

SAPI int SAPIBufferVerifySignatureInit(
                    SAPI_SES_HANDLE			Handle,
					SAPI_CONTEXT			*VerifyContext,
					const unsigned char		*SignedData,
					unsigned long			SignedDataLen,
					unsigned long			Flags);

SAPI int SAPIBufferVerifySignatureCont(
                   SAPI_SES_HANDLE		Handle,
				   SAPI_CONTEXT			*VerifyContext,
				   const unsigned char	*Buffer,
				   unsigned long		BufferLen);

SAPI int SAPIBufferVerifySignatureEnd(
                    SAPI_SES_HANDLE			Handle,
					SAPI_CONTEXT			*VerifyContext,
					SAPI_FILETIME			*SignatureTime, // currently not supported
   					SAPI_CERT_STATUS_STRUCT	*CertificateStatus);

SAPI int SAPISigningCeremonyGUI (
					SAPI_SES_HANDLE							Handle,
					SAPI_SIG_FIELD_HANDLE					SignatureFieldHandle,
					unsigned long							Flags,
					unsigned long							DisplayComponentsMask,
					unsigned long							GraphicFormatsPermitted,
					SAPI_LPCWSTR							InstructToSigner,
					SAPI_ENUM_CEREMONY_COMPONENT_SHOW_MODE	ImageSelection,
					SAPI_ENUM_CEREMONY_COMPONENT_SHOW_MODE	CertSelection,
					SAPI_ENUM_CEREMONY_COMPONENT_SHOW_MODE	ReasonSelection,
					SAPI_ENUM_CEREMONY_COMPONENT_SHOW_MODE	TitleSelection,
					SAPI_ENUM_GR_IMG_SELECT_MODE			GraphicalSelectionMode);

SAPI int SAPISignatureFieldSignedVersionGet(
		                    SAPI_SES_HANDLE			Handle,
							SAPI_SIG_FIELD_HANDLE	SignatureFieldHandle, 
							SAPI_FILE_HANDLE		*FileHandle, // can be null
							unsigned long			*FileLen,	// cannot be null
							unsigned long			Flags);		// not relevant

SAPI int SAPISetAppName (
						char			*ExtAppName);

SAPI int SAPIGetTokenID(
	                SAPI_SES_HANDLE	Handle,
	                char				*TokenID);

SAPI int SAPISetTokenID(
	                SAPI_SES_HANDLE	Handle,
					char				*TokenID);

SAPI int SAPIGetOCSP(
	                SAPI_SES_HANDLE				Handle,
					unsigned char				*Certificate,
					unsigned long				CertificateLen,
					unsigned char				*OCSP,
					unsigned long				*OCSPLen);

// unsupported function
SAPI int SAPIFileExtractClearFile(
							SAPI_SES_HANDLE			Handle,
							SAPI_LPCWSTR			SignedFileUNC,
							SAPI_LPCWSTR			ClearFileUNC,
							SAPI_ENUM_FILE_TYPE		*FileType, // the file type that was used for enveloping
							unsigned long			Flags); // overwrite existing file

SAPI int SAPICACertInstall(
		                SAPI_SES_HANDLE			Handle,
						unsigned char			*RootCert, 
						long					RootCertLen,
						SAPI_ENUM_STORE_TYPE	SystemStoreType);


SAPI int SAPIUserActivate(
					SAPI_SES_HANDLE					Handle,
					SAPI_LPCWSTR					UserLoginName,
					unsigned char					*Password,
	                unsigned long					PasswordLen,
					unsigned char					*NewPassword,
	                unsigned long					NewPasswordLen,
					unsigned char					*ExtCred,
	                unsigned long					ExtCredLen,
					unsigned long					Flags);


SAPI int SAPICredentialChange(
	                SAPI_SES_HANDLE					Handle,
	                SAPI_LPCWSTR					UserLoginName,
	                unsigned char					*OldPassword,
	                unsigned long					OldPasswordLen,
	                unsigned char					*NewPassword,
	                unsigned long					NewPasswordLen,
					SAPI_CALC_CREDENTIALS_CALLBACK	CalcCredentialFunc);

SAPI int SAPICreateFileHandleByMem (
						SAPI_FILE_HANDLE	*Handle,
						SAPI_ENUM_FILE_TYPE	FileType, 
						unsigned long		Flags,
						unsigned char		*FileMemBuffer,
						unsigned long		FileMemBufferLen);

SAPI int SAPICreateFileHandleByName (
						SAPI_FILE_HANDLE		*Handle,
						SAPI_ENUM_FILE_TYPE		FileType, 
						unsigned long			Flags,
						SAPI_LPCWSTR			FileUNC);


SAPI int SAPIGetFileMemData (
						SAPI_FILE_HANDLE		Handle,
						unsigned long			Flags,
						unsigned char			*FileMemBuffer,
						unsigned long			*FileMemBufferLen);

SAPI int SAPIGetFileHandleType (
						SAPI_FILE_HANDLE			Handle,
						SAPI_ENUM_FILE_HANDLE_TYPE	*FileHandleType);


/* ------------- Miscellaneous functions -----*/

SAPI int SAPITimeGet(SAPI_SES_HANDLE	Handle,
					 SAPI_FILETIME		*SystemTime);


SAPI int SAPILoginTicketCheckInit(
	                SAPI_SES_HANDLE			Handle,
                    SAPI_CONTEXT			*TicketCheckContext,
	                unsigned long			Flags); 


SAPI int SAPILoginTicketCheckCont(
	                SAPI_SES_HANDLE					Handle,
                    SAPI_CONTEXT					*TicketCheckContext,
	                unsigned char					*BufferIn, 
	                long							BufferInLen,
	                unsigned char					*BufferOut, 
	                long							*BufferOutLen,
                    SAPI_ENUM_TICKET_CHECK_STATUS	*Status); 

SAPI int SAPILoginTicketCheckEnd(
	                SAPI_SES_HANDLE					Handle,
                    SAPI_CONTEXT					*TicketCheckContext,
	                unsigned char					*BufferOut, 
	                long							*BufferOutLen); 

SAPI int SAPIGetTokenInfo(
					SAPI_SES_HANDLE			Handle,
					char					*TokenID,
					int						Flags,
					SAPI_TOKEN_INFO_STRUCT	*TokenInfo);

SAPI int SAPIKeyPairGenerate(SAPI_SES_HANDLE		Handle,
							 SAPI_LPCWSTR			UserLoginName, 
							 SAPI_LPCWSTR			DomainName, 
							 unsigned char			*Password,
							 long					PasswordLen,
							 unsigned long			Flags,
							 SAPI_LPWSTR			ContainerName,
							 unsigned long			*ContainerNameLen,
							 unsigned char			*PublicKey,
							 unsigned long			*PublicKeyLen);


SAPI int SAPIImportCertificate(SAPI_SES_HANDLE		Handle, 
							  SAPI_LPCWSTR			UserLoginName, 
							  SAPI_LPCWSTR			DomainName, 
							  unsigned char*		Password,
							  long					PasswordLen,
							  unsigned char*		Certificate,
							  unsigned long			CertificateLength);


SAPI int SAPIGenerateUserToken(	SAPI_SES_HANDLE					Handle,
								unsigned char					*ExtCredential,
								long							ExtCredentialLen,
								SAPI_FILETIME					*ExpirationTime,
								SAPI_ENUM_TOKEN_KIND			TokenKind,
								char*							Audience,
								SAPI_ENUM_TOKEN_PURPOSES		Purposes,
								unsigned long					Flags,
								unsigned char					*Token,
								long							*TokenLen);

SAPI int SAPICAGetAnonymousEnumInit(
					SAPI_SES_HANDLE					Handle,			//IN mandatory
	                SAPI_CONTEXT					*CAEnumContext,
					int								OrderDescending, // if 1 order desc, if 0 order ascending
					unsigned long					Flags,
					SAPI_LPCWSTR					FlagsStrValue);

SAPI int SAPICAGetAnonymousEnumCont(
						SAPI_SES_HANDLE					Handle,
						SAPI_CONTEXT					*CAEnumContext,
						SAPI_CA_RECORD_ANONYMOUS		*AnonymousCAList,
						unsigned long					*NumOfCAs);


#ifdef  __cplusplus
}
#endif

#endif