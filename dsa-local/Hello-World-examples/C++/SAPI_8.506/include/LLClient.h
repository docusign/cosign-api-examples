#ifndef __LLCLIENT_H
#define __LLCLIENT_H

#ifdef LLCLIENT_EXPORTS
#define LLCLIENT_API __declspec(dllexport)
#else
//#define LLCLIENT_API __declspec(dllimport)
 #ifndef LLCLIENT_API
 #define LLCLIENT_API
 #endif
#endif
#include "LLClientTypes.h"

#ifdef _WIN64
#define LLCLIENT_API_DLL			"LLClient64.dll"
#define COSIGN_DLL					"cosign64.dll"
#else
#define LLCLIENT_API_DLL			"LLClient.dll"
#define COSIGN_DLL					"cosign.dll"
#endif


// Hash algorithm types
#define HASH_TYPE_SHA1 1
#define HASH_TYPE_SHA256 2
#define HASH_TYPE_SHA384 3
#define HASH_TYPE_SHA512 4


#define OBJECT_CONTEXT_LENGTH			15000
#define MAX_ID							200
#define MAX_LABEL						200
#define SERVER_ID_MAX_LEN				50
#define SERVER_SERIAL_NUMBER_LEN		16
#define	MAX_EXPONENT_LENGTH				16
#define MAX_PNAME 32

#define LLCLIENT_REUSE_SESSION_FLAG									0x00000001

#define LLCLIENT_LOGON_FLAG_TYPE_WRITE_OP							0x00000010
#define LLCLIENT_LOGON_FLAG_USE_CLIENT_CACHE						0x00000020		// use static login (store the user creds in ckitcli cache).

// The following flags are duplicate in MOB and SAPI
#define LLCLIENT_LOGON_FLAG_EXTERNAL_COSIGN_SRV						0x20000000

#define LLCLIENT_LOGON_FLAG_AUTH_MODE_SSPI							0x00000100
#define LLCLIENT_LOGON_FLAG_AUTH_MODE_VERIFY_USER_SRV_SIDE			0x00000200
#define LLCLIENT_LOGON_FLAG_AUTH_MODE_SSPI_USRPWD					0x00000400
#define LLCLIENT_LOGON_FLAG_AUTH_MODE_VERIFY_DB_USER_SRV_SIDE		0x00000800
#define LLCLIENT_LOGON_FLAG_AUTH_MODE_SAML_SRV_SIDE					0x00001000
#define LLCLIENT_LOGON_FLAG_AUTH_MODE_JWT_SRV_SIDE					0x00002000

#define LLCLIENT_SIGN_FLAG_USE_PSS_ALG								0x00000001

typedef void			*MOB_SES_HANDLE;
typedef void			*MOB_OBJECT_HANDLE;
typedef unsigned char	MOB_OBJECT_CONTEXT[OBJECT_CONTEXT_LENGTH];
//mask
typedef enum LLCLIENT_ENUM_OBJECT_TYPE
{
	LLCLIENT_ENUM_OBJECT_TYPE_NONE			 = 0x00000000,
    LLCLIENT_ENUM_OBJECT_TYPE_DATA			 = 0x00000001, 
    LLCLIENT_ENUM_OBJECT_TYPE_CERT			 = 0x00000002,
    LLCLIENT_ENUM_OBJECT_TYPE_PUBLIC	     = 0x00000004,
    LLCLIENT_ENUM_OBJECT_TYPE_PRIVATE        = 0x00000008,
} LLCLIENT_ENUM_OBJECT_TYPE;

#ifdef AR_LINUX
#include <wchar.h>
#ifndef WCHAR
#define WCHAR wchar_t
#endif
#endif


#ifdef  __cplusplus
extern  "C" {
#endif

//
// InitLLClient
//
// Initialize the API. Call this once in the program startup.
LLCLIENT_API int InitLLClient();

// The InitLLClientEx function gets as input parameters the install path, log path and level (instead of extract them from regestry)
LLCLIENT_API int InitLLClientEx(char *install_path,
								char *log_file_path,
								int log_level);

//
// SignKey
//
// Sign with the unique key of the user.
// A reply that is different from 0 indicates an error
//
//	IPAddress		- The IP Address of the CoSign appliance
//  UserID			- The Identity of the signer
//	UserPassword	- Logon password of the user
//	UserPasswordLen	- Length of Logon password of the user
//	SignPassword	- Relevant when using extended Auth and represents the ext auth password
//	SignPasswordLen	- Len of SignaturePassword. If the given value is 0, no extended authentication is used.
//	HashType		- What Hash Type to use (SHA1, ...) - Look at above Identifiers
//	Hash			- Hash Value
//	HashLen			- The length of the Hash
//	Signature		- Output Signature value. Should be allocated by the application.
//	SigLen			- In/Out. As Input represent the maximal size of the Signature buffer.
//                            As Output will include the size of the actual signature.
//	Certificate		- Output Certificate value. Should be allocated by the application.
//	CertLen			- In/Out. As Input represent the maximal size of the Certificate buffer.
//                            As Output will include the size of the actual certificate.

LLCLIENT_API int LLSignKey(
						char			*IPAddress,
						WCHAR			*UserID,
						unsigned char 	*UserPassword,
						int				UserPasswordLen,
						unsigned char 	*SignPassword,
						int				SignPasswordLen,
						int				HashType,
						unsigned char	*Hash, 
						long			HashLen, 	
						unsigned char	*Signature,
						long			*SigLen,
						unsigned char	*Certificate,
						long			*CertLen);

LLCLIENT_API int LLGetCert(
						char			*IPAddress,
						WCHAR			*UserID,
						unsigned char 	*UserPassword,
						int				UserPasswordLen,
						unsigned char	*Certificate,
						long			*CertLen);






/************************************************************************************************************************

 LLSetAppName

	The LLSetAppName functions set the application name that will be written to the event log when LLSignSession is called.

	Parameters:

			AppName				- [In]			The application anme to set.

	Returns:
			LLCLIENT_SUCCES on success, LLCLIENT error code otherwise.

	Remarks:


************************************************************************************************************************/

LLCLIENT_API int LLSetAppName(char * AppName);




/************************************************************************************************************************
  LLIsLoggedIn

	The LLIsLoggedIn function will check the login state of the user and return the state using the IsLoggedIn out parameter
	TRUE if user logged on and FALSE otherwise.

	Parameters:
			
			Handle			- [In]				Pointer to a handle of a session. Should be allocated by the application. 
			IsLoggedIn		- [Out]				Pointer to a BOOL value, indicates whether a user is logged on, MUST not be null.


	Returns:
			LLCLIENT_SUCCES on success, LLCLIENT error code otherwise.

	Remarks:
			Before using this function the following function calls must be made 
				1. InitLLClient or InitLLClientEx
				2. LLInitSession

			determine login state when LLCLIENT_LOGON_FLAG_USE_CLIENT_CACHE flag is set is done using the Ckit cache (static logon), user is considered logged in as long as the last
			logon state in CKit cache was not changed, for example if a user logs in using LLCLient and then logs off using other app (i.e. control panel) at this point the user considered logged off even if 
			the user logs in again using the same app.


************************************************************************************************************************/
LLCLIENT_API int LLIsLoggedIn(MOB_SES_HANDLE Handle, BOOL *IsLoggedIn);






/************************************************************************************************************************
  LLInitSession

	The LLInitSession function acquires a session handle and logon the user using the provided credentials.
	The function returns a Handle as out parameter and the Handle is later used when calling LLClient functions.

	Parameters:
			
			Handle			- [Out]				Pointer to a handle of a session. Should be allocated by the application. 
			IPAddress		- [In]				The IP Address of the CoSign appliance
			UserID			- [In]				The Identity of the user to logon
			UserPassword	- [In]				Logon password of the user		
			UserPasswordLen	- [In]				Length of Logon password of the user
			Domain			- [In]				The Domain can be NULL
			Flags			- [In}				Flags for LLInitSession, look at Remarks section for more info.

	Returns:
			LLCLIENT_SUCCES on success, LLCLIENT error code otherwise.

	Remarks:
			Before using this function the following function calls must be made 
				1. InitLLClient or InitLLClientEx

			If the user name and password are NULL a logon dialog will be prompt (if not disabled), if the LLCLIENT_LOGON_FLAG_USE_CLIENT_CACHE flag is set then the 
			creds provided in logon prompt will be stored in client cache (static login).

			If write operation is needed (i.e. create graphical signature) LLCLIENT_LOGON_FLAG_TYPE_WRITE_OP flag must be set.
			if LLCLIENT_REUSE_SESSION_FLAG flag is set and a Handle parameter provided is from previous call to LLInitSession, then the existing session will 
			be reused. at this case user name and passsword must be provided.

			LLCLIENT_LOGON_FLAG_AUTH_MODE_XXX flags can be used to set the auth mode.

			The returned Handle must be released using a call to LLHandleRelease.

************************************************************************************************************************/
LLCLIENT_API int LLInitSession(
								MOB_SES_HANDLE		*Handle,
								char				*IPAddress,
								WCHAR				*UserID,
								unsigned char 		*UserPassword,
								int					UserPasswordLen,
								WCHAR				*Domain,
								unsigned long		Flags);



/************************************************************************************************************************

 LLKeyPairGenerate

	The LLKeyPairGenerate function generates private and public RSA pair.
	returns a pointers to a single object handle of the new public and private objects.

	Parameters:

			Handle				- [In]			Handle of a session. 
			KeySize				- [In]			The size of the keys to generate (256, 512).
			Flags				- [In]			Flags for key pair generate, look at Remarks section for more info.
			PublicObjectHandle	- [Out]			Pointer to a handle of a single object of the generated public, can be NULL.
			PrivateObjectHandle	- [Out]			Pointer to a handle of a single object of the generated private, can be NULL.

	Returns:
			LLCLIENT_SUCCES on success, LLCLIENT error code otherwise.

	Remarks:
			Before using this function the following function calls must be made 
				1. InitLLClient or InitLLClientEx
				2. LLInitSession

			The returned ObjectHandles must be released using a call to LLHandleRelease


************************************************************************************************************************/
LLCLIENT_API int LLKeyPairGenerate(
								MOB_SES_HANDLE				Handle,
								long						KeySize,
								unsigned long				Flags,
								MOB_OBJECT_HANDLE			*PublicObjectHandle,
								MOB_OBJECT_HANDLE			*PrivateObjectHandle);






//
// LLObjectsInit
//
//	The LLObjectsInit function initializes the continuous operation 
//	of retrieving all the objects that requested by specific user.
//
//	Handle			- [In] Handle of a session.
//	ObjectContext	- Output Pointer to the Object context.Should be allocated by the application. 
//					  This context contains information about the objects.
//	MaskObjectsType - [In] the objects types the user request to retrieve.
//  Flags			- [In} Flags for future use. Not Implement Yet.
//	PubNum			- [Out] Number of Public keys. Should be allocated by the application.Can be NULL
//	PrivNum			- [Out] Number of Private keys. Should be allocated by the application.Can be NULL 
//	CertsNum		- [Out] Number of Certficates. Should be allocated by the application.Can be NULL 
//	DataNum			- [Out] Number of Data objects. Should be allocated by the application.Can be NULL 
//  TotalObjectsNum	- [Out] Total number of objects. Should be allocated by the application.Can be NULL 
//
//	MOB_OBJECT_CONTEXT =  15000, if enlarge the size, notify the appliction
// if MaskObjectsType include data objects then:
//	MAX number of objects = 15
// otherwise
//	MAX number of objects = 100
//
LLCLIENT_API int LLObjectsInit(
                                MOB_SES_HANDLE					Handle,
                                MOB_OBJECT_CONTEXT				*ObjectContext,
                                long							MaskObjectsType,
								unsigned long					Flags,
                                long							*PubNum,
                                long							*PrivNum,
                                long							*CertsNum,
                                long							*DataNum,
                                long							*TotalObjectsNum);

//
// LLGetObjectByIndex
//
//	The LLGetObjectByIndex function returns a pointer to a single object handle
//
//	Handle			- [In]	Handle of a session. 
//	ObjectContext	- [In]	Pointer to the Object context. 
//							This context contains information about the objects.
//	ObjectIndex		- [In]	Object Index (0-(N-1)) 
//  Flags			- [In}	Flags for future use. Not Implement Yet.
//	ObjectType		- [Out] Pointer to the object type. Should be allocated by the application.Can be NULL 
//  ObjectHandle	- [Out] Pointer to a handle of a single object field. Should be allocated by the application. 
//

LLCLIENT_API int LLGetObjectByIndex(
                                    MOB_SES_HANDLE				Handle,
                                    MOB_OBJECT_CONTEXT			ObjectContext,
                                    long						ObjectIndex,
									unsigned long				Flags,
                                    LLCLIENT_ENUM_OBJECT_TYPE   *ObjectType,   
                                    MOB_OBJECT_HANDLE			*ObjectHandle);




/************************************************************************************************************************


 LLGetObjectByID

	The LLGetObjectByID function returns a pointer to a single object handle with the required id

	Parameters:

			Handle			- [In]	Handle of a session. 
			ObjectContext	- [In]	Pointer to the Object context. 
									This context contains information about the objects.
			ObjectType		- [In]  Object type to retrieve.
			Flags			- [In]	Flags for future use. Not Implement Yet.
			ObjectID		- [In]  Object ID that need to be retrieved
			ObjectIDLen		- [In]	Object id length
			ObjectHandle	- [Out] Pointer to a handle of a single object field. Should be allocated by the application. 


	Returns:
			LLCLIENT_SUCCES on success, LLCLIENT error code otherwise.
			If the requested object not found LLCLIENT_OBJECT_NOT_FOUND error code will be returned.

	Remarks:
			Before using this function the following function calls must be made 
				1. InitLLClient or InitLLClientEx
				2. LLInitSession
				3. LLObjectsInit

			The returned ObjectHandle must be released using a call to LLHandleRelease

************************************************************************************************************************/

LLCLIENT_API int LLGetObjectByID(
								MOB_SES_HANDLE				Handle,
                                MOB_OBJECT_CONTEXT			ObjectContext,
								LLCLIENT_ENUM_OBJECT_TYPE   ObjectType,
								unsigned long				Flags,
								unsigned char				*ObjectID,
								long						ObjectIDLen,
								MOB_OBJECT_HANDLE			*ObjectHandle);




//
// LLObjectInfoGet
//
//	The LLObjectInfoGet function returns all the information related to a specific object field.
//
//	Handle			- [In] Handle of a session
//  ObjectHandle	- [In] Pointer to a handle of a single object field.
//  Flags			- [In}	Flags for future use. Not Implement Yet.
//	ObjectValue		- [Out] Object value (relevant for data object and certificate object) . Should be allocated by the application.
//							Can be NULL.The returned value is not a null-terminated
//	ObjectLen		- [In/Out] As Input represent the maximal size of the Object buffer.
//                             As Output will include the size of the actual Object.Can be NULL
//	ObjectID		- [Out] Object ID (relevant for all objects types). Should be allocated by the application.
//							Can be NULL.The returned value is not a null-terminated
//	ObjectIDLen		- [In/Out] As Input represent the maximal size of the ObjectID buffer.
//                             As Output will include the size of the actual ID.Can be NULL
//	ObjectLabel		- [Out] Object Label (relevant for all objects types). Should be allocated by the application.
//							Can be NULL.The returned value is not a null-terminated
//	ObjectLabelLen	- [In/Out] As Input represent the maximal size of the ObjectLabelLen buffer.
//                             As Output will include the size of the actual Object Label.Can be NULL
//	KeyFileID		- [Out] Key File ID (relevant for Private objects). Should be allocated by the application.Can be NULL 
//	KeySize			- [Out] Key size (relevant for Private objects). Should be allocated by the application.Can be NULL 
//
LLCLIENT_API int LLObjectInfoGet(
                                MOB_SES_HANDLE          Handle,
                                MOB_OBJECT_HANDLE		ObjectHandle,
								unsigned long			Flags,
                                unsigned char           *ObjectValue,
                                long                    *ObjectLen,
								unsigned char			*ObjectID,
								long					*ObjectIDLen,
								unsigned char			*ObjectLabel,
								long					*ObjectLabelLen,
								int						*KeyFileID,
								long					*KeySize);






/************************************************************************************************************************


 LLObjectInfoGetEx

	The LLObjectInfoGetEx function returns object info

	Parameters:

			Handle			- [In]			Handle of a session. 
			ObjectHandle	- [In]			The requested object handle. 
			Flags			- [In]			Flags to create object, look at Remarks section for more info.
			ObjectValue		- [Out]			Object value, can be NULL.
			ObjectLen		- [In, Out]		The length of the ObjectValue buffer, will be set to the actual object value length.
			ObjectID		- [Out]			The object id, can be NULL
			ObjectIDLen		- [In, Out]		The length of the ObjectID buffer, will be set to the actual object id length.
			ObjectLabel		- [Out]			The object label, can be NULL.
			ObjectLabelLen	- [In, Out]		The length of the ObjectLabel buffer, will be set to the actual object label length.
			KeyFileID		- [Out]			The key file id of private key object, can be NULL.
			KeySize			- [Out]			The key size of private key object, can be NULL.
			Exponent		- [Out]			The public exponent of key pair (private, public objects only), can be NULL.
			ExponentLen		- [In, Out]		The length of the exponent buffer, will be set to the actual exponent length.
				
	Returns:
			LLCLIENT_SUCCES on success, LLCLIENT error code otherwise.

	Remarks:
			Before using this function the following function calls must be made 
				1. InitLLClient or InitLLClientEx
				2. LLInitSession
				3. LLObjectsInit
				4. LLGetObjectByID or LLGetObjectByIndex to get the object handle


************************************************************************************************************************/
LLCLIENT_API int LLObjectInfoGetEx(
                                MOB_SES_HANDLE          Handle,
                                MOB_OBJECT_HANDLE		ObjectHandle,
								unsigned long			Flags,
                                unsigned char           *ObjectValue,
                                long                    *ObjectLen,
								unsigned char			*ObjectID,
								long					*ObjectIDLen,
								unsigned char			*ObjectLabel,
								long					*ObjectLabelLen,
								int						*KeyFileID,
								long					*KeySize,
								unsigned char			*Exponent,
								long					*ExponentLen);



/************************************************************************************************************************


 LLObjectCreate

	The LLObjectCreate function creates an object in the appliance and 
	returns a pointer to a single object handle of the new created object.

	Parameters:

			Handle			- [In]	Handle of a session. 
			ObjectType		- [In]  Object type to create	-  currently only data and cert are allowed.
			Flags			- [In]	Flags to create object, look at Remarks section for more info.
			ObjectValue		- [In]	Object data
			ObjectLen		- [In]  Object data length
			ObjectID		- [In]  Object ID of the new object (ignored at certificate creation)
			ObjectIDLen		- [In]	Object ID length (ignored at certificate creation)
			ObjectHandle	- [Out] Pointer to a handle of a single object that was created, can be NULL.


	Returns:
			LLCLIENT_SUCCES on success, LLCLIENT error code otherwise.
			If the required object already exist LLCLIENT_OBJECT_ALREADY_EXIST will be returned.
	Remarks:
			Before using this function the following function calls must be made 
				1. InitLLClient or InitLLClientEx
				2. LLInitSession

			If the object type is not CERT or DATA, LLCLIENT_OBJECT_TYPE_NOT_ALLOWED will be returned.

			The returned ObjectHandle must be released using a call to LLHandleRelease

			When creating Data object Flags can be used to set the data object type using LLCLIENT_ENUM_GRAPHICAL_OBJECT_TYPE.
			When creating CERT object, the function looks for the matching public key and uses its container ID, if the
			matching public is not found, LLCLIENT_NO_MATCHING_PUBLIC_KEY_FOUND will be returned.

************************************************************************************************************************/
LLCLIENT_API int LLObjectCreate(
								MOB_SES_HANDLE				Handle,
								LLCLIENT_ENUM_OBJECT_TYPE	ObjectType,
								unsigned long				Flags,
								unsigned char				*ObjectValue,
                                long						ObjectLen,
								unsigned char				*ObjectID,
								long						ObjectIDLen,
								MOB_OBJECT_HANDLE			*ObjectHandle);




/************************************************************************************************************************


 LLObjectUpdate

	The LLObjectUpdate function updates an existing object in the appliance and 
	returns a pointer to a single object handle of the updated object.

	Parameters:

			Handle			- [In]			Handle of a session. 
			ObjectHandle	- [In, Out]		Object handle to update, currently only DATA object allowed.
			Flags			- [In]			Flags to update object, look at Remarks section for more info.
			ObjectValue		- [In]			New object data, can be NULL.
			ObjectLen		- [In]			New object data length
			ObjectID		- [In]			New object id, can be NULL.
			ObjectIDLen		- [In]			New object id length 


	Returns:
			LLCLIENT_SUCCES on success, LLCLIENT error code otherwise.
			If the object type is other then DATA, LLCLIENT_OBJECT_TYPE_NOT_ALLOWED will be returned.
			If the new object id is assigned to another object in the appliance, LLCLIENT_OBJECT_ALREADY_EXIST will be returned.
			
	Remarks:
			Before using this function the following function calls must be made 
				1. InitLLClient or InitLLClientEx
				2. LLInitSession
				3. LLObjectsInit
				4. LLGetObjectByID or LLGetObjectByIndex to get the object handle

			The returned ObjectHandle must be released using a call to LLHandleRelease

			When updating Data object, Flags can be used to set the data object type using LLCLIENT_ENUM_GRAPHICAL_OBJECT_TYPE.

************************************************************************************************************************/
LLCLIENT_API int LLObjectUpdate(
								MOB_SES_HANDLE				Handle,
								MOB_OBJECT_HANDLE			*ObjectHandle,
								unsigned long				Flags,
								unsigned char				*ObjectValue,
                                long						ObjectLen,
								unsigned char				*ObjectID,
								long						ObjectIDLen);




/************************************************************************************************************************


 LLObjectDelete

	The LLObjectDelete function deletes an object from the appliance.

	Parameters:

			Handle			- [In]	Handle of a session. 
			ObjectHandle	- [In]	Object handle to delete
			Flags			- [In]	Flags to delete object, look at Remarks section for more info.
			Password		- [In]	The extended login password if required for deleteing private key object
			PasswordLen		- [In]  Password length


	Returns:
			LLCLIENT_SUCCES on success, LLCLIENT error code otherwise.
			
	Remarks:
			Before using this function the following function calls must be made 
				1. InitLLClient or InitLLClientEx
				2. LLInitSession
				3. LLObjectsInit
				4. LLGetObjectByID or LLGetObjectByIndex to get the object handle


************************************************************************************************************************/
LLCLIENT_API int LLObjectDelete(
                                MOB_SES_HANDLE          Handle,
                                MOB_OBJECT_HANDLE		ObjectHandle,
								unsigned long			Flags,
								unsigned char 			*Password,
								int						PasswordLen
								);

//
// LLGetCRL
//
//	The LLGetCRL function returns the CRL data
//
//	Handle			- [In]	Handle of a session. 
//  CRLBuff  		- [Out] CRL value. Should be allocated by the application. 
//  CRLLen			- [In/Out] As Input represent the maximal size of the CRL buffer.
//							   As Output will include the size of the actual CRL.
//
LLCLIENT_API int LLGetCRL(
                                MOB_SES_HANDLE					Handle,
                                unsigned char 					*CRLBuff,
                                long							*CRLLen);


//
// LLGetCRL
//
//	The LLGetCRL function returns the CRL data
//
//	Handle			- [In]	Handle of a session. 
//  Issuer			- [In]  CA name
//  CRLBuff  		- [Out] CRL value. Should be allocated by the application. 
//  CRLLen			- [In/Out] As Input represent the maximal size of the CRL buffer.
//							   As Output will include the size of the actual CRL.
//
LLCLIENT_API int LLGetCRLEx(
                                MOB_SES_HANDLE					Handle,
								WCHAR							*Issuer,
                                unsigned char 					*CRLBuff,
                                long							*CRLLen);

// LLSignSession
//
//	The LLSignSession function Sign with the unique key of the user.
//
//	Handle			- [In] Handle of a session
//	ObjectContext	- [In] Pointer to the Object context. 
//					       This context contains information about the objects.
//	ObjectHandle	- [In] Pointer to a handle of a single object field.
//	HashType		- [In] What Hash Type to use (SHA1, ...) - Look at above Identifiers
//	Hash			- [In] Hash Value
//	HashLen			- [In] The length of the Hash
//	SignPassword	- [In] Relevant when using prompt for signature otherwise should be NULL.
//	SignPasswordLen	- [In] Len of SignaturePassword. If the given value is 0, no prompt for signature is used.
//  Flags			- [In}	Flags for future use. Not Implement Yet.
//	Signature		- [Out] Signature value. Should be allocated by the application.
//	SigLen			- [In/Out] As Input represent the maximal size of the Signature buffer.
//                            As Output will include the size of the actual signature.
//
LLCLIENT_API int LLSignSession(
								MOB_SES_HANDLE		Handle,
								MOB_OBJECT_CONTEXT	ObjectContext,
								MOB_OBJECT_HANDLE	ObjectHandle,
								int					HashType,
								unsigned char		*Hash, 
								long				HashLen, 	
								unsigned char 		*SignPassword,
								int					SignPasswordLen,
								unsigned long		Flags,
								unsigned char		*Signature,
								long				*SigLen);



//
// LLGetServerInfo
//
//	The LLGetServerInfo function returns Server Information
//
//	Handle			- [In]	Handle of a session. 
//	ServerID		- [Out]	Server ID. Can be NULL 
//	ServerIDLen		- [In]	Server ID length. 
//	Firmware		- [Out]	Firmware. Can be NULL 
//	Hardware		- [Out]	Hardware. Can be NULL 
//	SerialNumber	- [Out]	Serial Number. Can be NULL 
//  SerialNumberLen	- [In}	Serial Number length
//	ServerTime		- [Out] Server Time.Can be NULL 
//	InstallStatus	- [Out] Install Status.Can be NULL 
//	ServerKind		- [Out]Server Kind.Can be NULL 
//	DirectoryKind	- [Out] Directory Kind.Can be NULL 
//	SubDirectoryKind- [Out]Sub Directory Kind.Can be NULL 
//	SubDirectoryKind- [Out]Sub Directory Kind.Can be NULL
//	AuthMode		- [Out]Authentication Mode.Can be NULL
//	AuthMode2		- [Out]Authentication Mode.Can be NULL
//	ClusterId		- [Out]Cluster Id.Can be NULL
//	ExtendedInfo	- [Out]Extended Information.Can be NULL
//

LLCLIENT_API int LLGetServerInfo(
                                    MOB_SES_HANDLE					Handle,
                                    char							*ServerID,
									unsigned long					ServerIDLen,
									LLCLIENT_SERVER_VERSION			*Firmware,
									LLCLIENT_SERVER_VERSION			*Hardware,
									char		  					*SerialNumber,
									unsigned long					SerialNumberLen,
									unsigned long					*ServerTime,
									int								*InstallStatus,
									LLCLIENT_ENUM_SERVER_KIND		*ServerKind,
									LLCLIENT_ENUM_DIRECTORY_KIND	*DirectoryKind,
									unsigned long					*SubDirectoryKind,
									LLCLIENT_ENUM_AUTH_MODE			*AuthMode,
									LLCLIENT_ENUM_AUTH_MODE			*AuthMode2,
									long							*ClusterId,
									void							*ExtendedInfo);
//
// LLHandleRelease
//
//	The LLHandleRelease function releases all the resources related to any kind of handles.
//	This function is called whenever the application finishes using a handle, 
//	to avoid unnecessary allocation of resources.
//
//	Handle	- [In] Any handle that was created, such as session handle, object handle
//
LLCLIENT_API int LLHandleRelease(void  *Handle);
//
// LLContextRelease
//
//	The LLContextRelease function releases all the resources related to any kind of object context.
//	This function is called whenever the application finishes using a context, 
//	to avoid unnecessary allocation of resources.
//
//	ObjectContext	- [In] Any kind of context that was created by any of the LLClient context creation
//
LLCLIENT_API int LLContextRelease(MOB_OBJECT_CONTEXT  *Context);

//
// LLGetOCSPByCert
//
//	The LLGetOCSPByCert function returns OCSP for a specific certificate
//
//	Handle			- [In]	Handle of a session. 
//	Certificate		- [In]	X509 Certificate buffer
//	CertificateLen	- [In]	X509 Certificate buffer length
//	OCSP 			- [Out] OCSP response buffer
//  OCSPLen			- [Out] OCSP response buffer length
//
LLCLIENT_API int LLGetOCSPByCert(
                                    MOB_SES_HANDLE				Handle,
									unsigned char				*Certificate,
									long						CertificateLen,
									unsigned char				*OCSP,
									long						*OCSPLen);

//
// LLGenerateUserToken
//
//	The LLGenerateUserToken function generates user token according to token kind
//
//	Handle				- [In]	Handle of a session. 
//	ExtCredential		- [In]	password for using extended Auth
//	ExtCredentialLen	- [In]	Len of ExtCredential
//	TokenKind			- [In]	the generated token kind
//	Audience			- [In]	accept token  issued to audience
//	Purposes			- [In]	the purposes of the token
//	Flags				- [In]	flags
//	Token 				- [Out] generated token
//  TokenLen			- [Out] generated token length
//
LLCLIENT_API int LLGenerateUserToken(
                                    MOB_SES_HANDLE					Handle,
									unsigned char					*ExtCredential,
									long							ExtCredentialLen,
									time_t							ExpirationTime,
									LLCLIENT_ENUM_TOKEN_KIND		TokenKind,
									char*							Audience,
									LLCLIENT_ENUM_TOKEN_PURPOSES	Purposes,
									unsigned long					Flags,
									unsigned char					*Token,
									long							*TokenLen);



//
// LLGetAllTokenIDsEnumInit
//
//	The LLGetAllTokenIDsEnumInit function Initialize the returns of all the available CoSign Server Addresses
//
//	TokenIDsContext	- [In/Out]	Context to be used in the LLGetAllTokenIDsEnumCont function
//
LLCLIENT_API int LLGetAllTokenIDsEnumInit(TOKEN_IDS_CONTEXT	*TokenIDsContext);

//
// LLGetAllTokenIDsEnumCont
//
//	The LLGetAllTokenIDsEnumCont function returns a CoSign Server Addresses one by one. When there are no more addresses, the function will return LLCLIENT_NO_MORE_ITEMS
//
//	TokenIDsContext	- [In/Out]	Context to be used in the LLGetAllTokenIDsEnumCont function
//	TokenID			- [Out]		A CoSign Address Token
//	TokenIDLen		- [In/Out]  Length of TokenID string input. Will be set to the length of the TokenID returned.
//
LLCLIENT_API int LLGetAllTokenIDsEnumCont(
											TOKEN_IDS_CONTEXT	*TokenIDsContext,
											char				*TokenID,
											long				*TokenIDLen);

//
// LLChangeCredentials
//
//	The LLChangeCredentials function change user password
//	Note: this is an independent entry point with no need to call init session
//
//	Parameters:
			
//			UserID				- [In]				The Identity of the user to logon
//			UserPassword		- [In]				Old\Current Logon password of the user		
//			UserPasswordLen		- [In]				Length of Logon Old\Current password of the user
//			NewUserPassword		- [In]				New Logon password of the user		
//			NewUserPasswordLen	- [In]				Length of New Logon password of the user
//			IPAddress			- [In]				The IP Address of the CoSign appliance
//			Flags				- [In}				Flags for LLInitSession, look at Remarks section for more info.
//
LLCLIENT_API int LLChangeCredentials(
											WCHAR				*UserID,
											unsigned char 		*UserPassword,
											unsigned long		UserPasswordLen,
											unsigned char 		*NewUserPassword,
											unsigned long		NewUserPasswordLen,
											char				*IPAddress,
											unsigned long		Flags);




#ifdef AR_LINUX

// 
// convert_password
// 
// Converts a wide character password to a byte stream
//
void convert_password( wchar_t * password, unsigned char * converted_password, int * len );


#endif


#ifdef  __cplusplus
}
#endif
#endif