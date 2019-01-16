#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AUTH_OTP_SRV_H__
#define __AUTH_OTP_SRV_H__

#ifdef AR_LINUX
#include <inttypes.h>

#define IN
#define OUT
typedef long long LONGLONG;
#else
#include <windows.h>
#endif

#define OTP_VALIDATION_METHOD_NONE	0 
#define OTP_VALIDATION_METHOD_HOTP	1
#define OTP_VALIDATION_METHOD_VASCO	3

#ifdef  __cplusplus
extern  "C" {
#endif
typedef void		*OTP_SESSION_HANDLE;




	/***	
			UnloadOTPAuth Unloads ExtAuthOTPSrvPlugIN.dll.

			DLL location should be defined on:
			HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\ARL\CoSign\CkitCli
			install_path.
			This function calls the OTPServerInit from the above DLL:
	***/
	void	UnloadOTPAuth();



	/***	
			OTPAuthServerInit loads ExtAuthOTPSrvPlugIN.dll.
			DLL location should be defined on:
			HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\ARL\CoSign\CkitCli
			install_path.
			This function calls OTPServerInit function from the above DLL:

			
			OTPServerInit - Init a session to CoSign server.
			The fucntions open ssl connection to CoSign server.

			Parameters:
			SessionHandle  - Indicates CoSign server session state.
            ServerAddress  - CoSign server IP address.

			Return Values:
			0			   - Success on session creation.
			1			   - Error while session creation.
			
	***/ 
	int		OTPAuthServerInit(
						IN OUT OTP_SESSION_HANDLE* SessionHandle,
						IN					char* ServerAddress);



	/***	
			OTPAuthServerInit loads ExtAuthOTPSrvPlugIN.dll.
			DLL location should be defined on:
			HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\ARL\CoSign\CkitCli
			install_path.
			This function calls OTPServerInit function from the above DLL:

			
			OTPServerInit - Init a session to CoSign server.
			The fucntions open ssl connection to CoSign server.

			Parameters:
			SessionHandle  - Indicates CoSign server session state.
			ClientAddress  - Client (source) IP address.
            ServerAddress  - CoSign server IP address.

			Return Values:
			0			   - Success on session creation.
			1			   - Error while session creation.
			
	***/ 




	int		OTPAuthServerInitFromClient(
						IN OUT OTP_SESSION_HANDLE* SessionHandle,
						IN					char* ClientAddress,
						IN					char* ServerAddress);

	/***
			OTPAuthServerValidate calls OTPServerValidate function from the above DLL:

			
			OTPServerValidate - Sends the OTP blob to CoSign Server for validation
			
			Parameters:
			SessionHandle  - Indicates CoSign server session state.
            DummyOTP	   - A DummyOTP data (ascii) accepted from CoSign for validation
			DummyOTPLen	   - The DummyOTP len including the null terminator
			OTPMethod	   - Validation Method. Suported methos :
							 OTP_VALIDATION_METHOD_NONE  - will be defined by CoSign appliance system parameter.
							 OTP_VALIDATION_METHOD_HOTP  - OATH HMAC one time password validation
							 OTP_VALIDATION_METHOD_VASCO - VASCO proprietary validation.
			Secert		   - Token Secret/Blob data (binary). The field will be modified for success validation. 
			SecretLen	   - The Secret/Blob data len. The field indicates the Secret/Blob updated len. 
			Counter		   - Token counter(factor).The counter will be advanced for success validation.
			Return Values:
			0			   - Success while OTP validation.
			1			   - Error while OTP validation.
			
	***/




	int		OTPAuthServerValidate(
						IN		OTP_SESSION_HANDLE		 SessionHandle,
						IN		const unsigned char*	 DummyOTP,
						IN		int						 DummyOTPLen,
						IN		int						 OTPMethod,
						IN OUT	unsigned char*			 Secret,
						IN OUT	unsigned long*			 SecretLen,
						IN OUT  LONGLONG*				 Counter);




	/***	
			OTPAuthServerRelease calls OTPServerRelease function from the above DLL.

	
			OTPServerRelease - Release the resources of CoSign server session.
			
			Parameters:
			SessionHandle  - Indicates CoSign server session state.
            

			Return Values:
			0			   - Success on session release.
			1			   - Error while session release.
			
	***/ 	
	int		OTPAuthServerRelease(
						IN		OTP_SESSION_HANDLE		 SessionHandle);

#ifdef  __cplusplus
}
#endif

#endif //__AUTH_OTP_SRV_H__