#ifndef __SAPIUM_H__
#define __SAPIUM_H__

#include "SAPIUMTypes.h"
// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the CSNOBAPI_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// SAPIUM functions as being imported from a DLL, wheras this DLL sees symbols
// defined with this macro as being exported.
#ifdef SAPIUM_EXPORTS
#define SAPIUM __declspec(dllexport)
//#elif SAPI_INTERNAL
#else
 #ifndef SAPIUM
 #define SAPIUM
 #endif
//#else
//#define SAPIUM __declspec(dllimport)
#endif
#ifdef  __cplusplus
extern  "C" {
#endif

SAPIUM int SAPIUMInit();

SAPIUM int SAPIUMInitEx(char		*InstallPath,
						char		*LogFilePath,
						int			 Log_Level);

SAPIUM int SAPIUMLibInfoGet(
					PSAPI_UM_INFO_STRUCT	SAPIUMInfoStruct);

SAPIUM int SAPIUMExtendedLastErrorGet();

SAPIUM int SAPIUMHandleAcquire(
	                SAPI_UM_SES_HANDLE	*Handle);

SAPIUM int SAPIUMLogon(
	                SAPI_UM_SES_HANDLE	Handle,
	                SAPI_LPCWSTR		UserLoginName,
					SAPI_LPCWSTR		DomainName,
	                unsigned char		*Password,
	                long				PasswordLen);

SAPIUM int SAPIUMLogonEx(
	                SAPI_UM_SES_HANDLE	Handle,
	                SAPI_LPCWSTR		UserLoginName,
					SAPI_LPCWSTR		DomainName,
	                unsigned char		*Password,
	                long				PasswordLen,
					unsigned long		Flags);

SAPIUM int SAPIUMLogonBuiltIn(
	                SAPI_UM_SES_HANDLE	Handle,
	                SAPI_LPCWSTR		UserLoginName,
	                unsigned char		*Password,
	                long				PasswordLen);

SAPIUM int SAPIUMUserAdd(
	                SAPI_UM_SES_HANDLE					Handle,
	                SAPI_LPCWSTR						UserLoginName,
	                SAPI_LPCWSTR						UserCN,
	                SAPI_LPCWSTR						emailAddress,
	                unsigned char						*Password,
	                unsigned long						PasswordLen,
					SAPI_UM_CALC_CREDENTIALS_CALLBACK	CalcCredentialFunc,
	                unsigned long						flags); // user rights

SAPIUM int SAPIUMUserAddEx1(
	                SAPI_UM_SES_HANDLE					Handle,
	                SAPI_LPCWSTR						UserLoginName,
	                SAPI_LPCWSTR						UserCN,
	                SAPI_LPCWSTR						emailAddress,
	                unsigned char						*Password,
	                unsigned long						PasswordLen,
					SAPI_UM_CALC_CREDENTIALS_CALLBACK	CalcCredentialFunc,
					SAPI_TECH_ID						GroupTechID,
	                unsigned long						flags);

SAPIUM int SAPIUMUserUpdate(
	                SAPI_UM_SES_HANDLE	Handle,
	                SAPI_LPCWSTR		UserLoginName,
	                SAPI_LPCWSTR		UserCN,
	                SAPI_LPCWSTR		emailAddress,
	                unsigned long		flags); // user rights

SAPIUM int SAPIUMCredentialSet(
	                SAPI_UM_SES_HANDLE					Handle,
	                SAPI_LPCWSTR						UserLoginName,
	                unsigned char						*Password,
	                unsigned long						PasswordLen,
					SAPI_UM_CALC_CREDENTIALS_CALLBACK	CalcCredentialFunc);

SAPIUM int SAPIUMUserDelete(
	                SAPI_UM_SES_HANDLE	Handle,
	                SAPI_LPCWSTR		UserLoginName);

SAPIUM int SAPIUMUserSetLogonState(
	                SAPI_UM_SES_HANDLE				Handle,
	                SAPI_LPCWSTR					UserLoginName,
                    SAPI_UM_ENUM_USER_LOGIN_STATUS  UserLogonStatus	);

SAPIUM int SAPIUMUsersSyncBegin(
	                SAPI_UM_SES_HANDLE	Handle,
                    SAPI_UM_CONTEXT		SyncContext);

SAPIUM int SAPIUMUserSync(
	                SAPI_UM_SES_HANDLE					Handle,
	                SAPI_LPCWSTR						UserLoginName,
	                SAPI_LPCWSTR						UserCN,
	                SAPI_LPCWSTR						emailAddress,
	                unsigned char						*Password,
	                unsigned long						PasswordLen,
					SAPI_UM_CALC_CREDENTIALS_CALLBACK	CalcCredentialFunc,
	                unsigned long						flags); // user rights

SAPIUM int SAPIUMUsersSyncEnd(
	                SAPI_UM_SES_HANDLE	Handle,
                    SAPI_UM_CONTEXT		SyncContext);

SAPIUM int SAPIUMUsersSyncStop(
	                SAPI_UM_SES_HANDLE	Handle,
                    SAPI_UM_CONTEXT		SyncContext);

SAPIUM int SAPIUMUsersCount(
					SAPI_UM_SES_HANDLE			Handle,
					long						*UsersCount);


SAPIUM int SAPIUMUsersEnumInit(
	                SAPI_UM_SES_HANDLE			Handle,
					SAPI_ENUM_USERS_CONTEXT		UsersEnumContext,
					SAPI_UM_USERS_FILTER_STRUCT	*UsersFilterStruct);

SAPIUM int SAPIUMUsersEnumInitEx(
	                SAPI_UM_SES_HANDLE				Handle,
					SAPI_ENUM_USERS_CONTEXT			UsersEnumContext,
					SAPI_UM_USERS_FILTER_STRUCT		*UsersFilterStruct,
					SAPI_UM_USERS_FILTER_EXT_TYPE	UsersFilterExtType,
					void							*UsersFilterExtValue);

SAPIUM int SAPIUMUsersEnumCont(
	                SAPI_UM_SES_HANDLE		Handle,
					SAPI_ENUM_USERS_CONTEXT	UsersEnumContext,
					SAPI_UM_USR_HANDLE		*UserHandle); 

SAPIUM int SAPIUMUsersEnumNumberOfUsersGet(
					SAPI_UM_SES_HANDLE		Handle,
					SAPI_ENUM_USERS_CONTEXT	UsersEnumContext,
					long					*NumOfRemainigUsers);

SAPIUM int SAPIUMUserInfoGet(
	                SAPI_UM_SES_HANDLE		Handle,
					SAPI_UM_USR_HANDLE		UserHandle, 
	                SAPI_LPWSTR				UserLoginName,
	                long					*UserLoginNameLen,
	                SAPI_LPWSTR				UserCN,
	                long					*UserCNLen,
	                SAPI_LPWSTR				EmailAddress,
	                long					*EmailAddressLen,
					SAPI_UM_ENUM_USER_TYPE	*Kind,
					long					*RightsMask,
					unsigned long			*UpdateTime,
					SAPI_UM_GUID			Guid
					);

SAPIUM int SAPIUMUserInfoGetEx(
	                SAPI_UM_SES_HANDLE							Handle,
					SAPI_UM_USR_HANDLE							UserHandle, 
	                SAPI_LPWSTR									UserLoginName,
	                long										*UserLoginNameLen,
	                SAPI_LPWSTR									UserCN,
	                long										*UserCNLen,
	                SAPI_LPWSTR									EmailAddress,
	                long										*EmailAddressLen,
					SAPI_UM_ENUM_USER_TYPE						*Kind,
					long										*RightsMask,
					unsigned long								*UpdateTime,
					SAPI_UM_GUID								Guid,
					SAPI_UM_ENUM_USER_ENROLLMENT_STATUS			*EnrollmentStatus,
					SAPI_UM_ENUM_USER_ENROLLMENT_REASON			*EnrollmentReason,
					SAPI_UM_ENUM_USER_LOGIN_STATUS				*LoginStatus,
					long										*Counter1,
					long										*Counter2,
					long										*Counter3,
                    SAPI_UM_ENUM_USER_CERT_STATUS_TYPE			*UserCertStatus,
                    SAPI_UM_ENUM_PENDING_REQUEST_STATUS_TYPE	*CertRequestStatus					
					);

SAPIUM int SAPIUMUserGroupTechIDGet(
	                SAPI_UM_SES_HANDLE		Handle,
					SAPI_UM_USR_HANDLE		UserHandle, 
	                SAPI_TECH_ID			*GroupTechID);

SAPIUM int SAPIUMCounterReset(
	                SAPI_UM_SES_HANDLE			Handle,
	                SAPI_LPCWSTR				UserLoginName,
					SAPI_UM_ENUM_COUNTER_TYPE	CounterToReset);

SAPIUM int SAPIUMUserGetByLoginName(
	                SAPI_UM_SES_HANDLE		Handle,
	                SAPI_LPCWSTR			UserLoginName,
					SAPI_UM_USR_HANDLE		*UserHandle);

SAPIUM int SAPIUMGroupGetByUserGUID(
		                SAPI_UM_SES_HANDLE			Handle,
                        SAPI_UM_GUID                UserGUID,
						SAPI_UM_GROUP_RECORD		*GroupRecord);

SAPIUM int SAPIUMGroupAdd(
                SAPI_UM_SES_HANDLE			Handle,
				SAPI_UM_GROUP_RECORD		*GroupRecord,
				SAPI_TECH_ID				*GroupTechID);

SAPIUM int SAPIUMGroupGetByTechID(
		                SAPI_UM_SES_HANDLE			Handle,
						SAPI_TECH_ID				GroupTechID,
						SAPI_UM_GROUP_RECORD		*GroupRecord);

SAPIUM int SAPIUMGroupSetStatusByTechID(
		                SAPI_UM_SES_HANDLE				Handle,
						SAPI_TECH_ID					GroupTechID,
						SAPI_UM_ENUM_GROUP_STATUS_TYPE	GroupStatus);


SAPIUM int SAPIUMGroupUpdate(
		                SAPI_UM_SES_HANDLE			Handle,
						SAPI_UM_GROUP_RECORD		*GroupRecord);

SAPIUM int SAPIUMGroupDelete(
		                SAPI_UM_SES_HANDLE			Handle,
						SAPI_TECH_ID				GroupTechID,
						unsigned long				UserOP);

SAPIUM int SAPIUMUserAssignGroup(
		                SAPI_UM_SES_HANDLE			Handle,
						SAPI_TECH_ID				UserTechID,
						SAPI_TECH_ID				GroupTechID,
						unsigned long				Flags);

SAPIUM int SAPIUMGroupsEnumInit(
						SAPI_UM_SES_HANDLE					Handle,
						SAPI_UM_CONTEXT						GroupsEnumContext,
						SAPI_UM_ENUM_GROUPS_ORDER_TYPE		GroupsOrderType,// Not Implement Yet
						SAPI_LPCWSTR						StartValue,// Not Implement Yet
						int									StartNumberValue,// Not Implement Yet
						int									OrderDescending);// if 1 order desc, if 0 order ascending

SAPIUM int SAPIUMGroupsEnumCont(
						SAPI_UM_SES_HANDLE					Handle,
						SAPI_UM_CONTEXT						GroupsEnumContext,
						SAPI_UM_GROUP_RECORD				*GroupsList,
						unsigned long						*NumOfGroups);

SAPIUM int SAPIUMUserTechIDGet(
		                SAPI_UM_SES_HANDLE			Handle,
						SAPI_UM_USR_HANDLE			UserHandle,
						SAPI_TECH_ID				*UserTechID);

SAPIUM int SAPIUMGroupGetByName(
		                SAPI_UM_SES_HANDLE			Handle,
						SAPI_LPCWSTR				GroupName,
						SAPI_UM_GROUP_RECORD		*GroupRecord);

SAPIUM int SAPIUMUserExtInfoAdd(
							SAPI_UM_SES_HANDLE					Handle,
							SAPI_UM_USR_HANDLE					UserHandle, //in
							SAPI_UM_ENUM_USER_EXT_INFO_TYPE		UserInfoType,//in
							unsigned char						*UserInfoData,//in
							unsigned long						UserInfoDataLen,//in
							SAPI_UM_BOOL						UpdateExistingUserExtInfo,//in - The flag is indicate whether create new user info or update existing user info
							unsigned long						Flags); // not relevant

SAPIUM int  SAPIUMUserExtInfoDelete (
							SAPI_UM_SES_HANDLE					Handle,
							SAPI_UM_USR_HANDLE					UserHandle, //in
							SAPI_UM_ENUM_USER_EXT_INFO_TYPE		UserInfoType,//in
							unsigned long						Flags); // not relevant

SAPIUM int SAPIUMUserExtInfoGet(
							SAPI_UM_SES_HANDLE					Handle,
							SAPI_UM_USR_HANDLE					UserHandle, //in
							SAPI_UM_ENUM_USER_EXT_INFO_TYPE		UserInfoType,//in
							unsigned char						*UserInfoData,//out
							unsigned long						*UserInfoDataLen,//in-out
							SAPI_UM_ENUM_DATA_TYPE				*DataType,//out - indicate what type of data retrieve
							unsigned long						Flags); // not relevant

SAPIUM int  SAPIUMGroupExtDataUpdate(
		                SAPI_UM_SES_HANDLE				Handle,
						SAPI_TECH_ID					GroupTechID,
						SAPI_UM_ENUM_GROUP_VALUE_NAME	ValueType,	//in
						long							*IntVal,	//in
						char							*StrVal);	//in

SAPIUM int  SAPIUMGroupExtDataGet(
		                SAPI_UM_SES_HANDLE				Handle,
						SAPI_TECH_ID					GroupTechID,
						SAPI_UM_ENUM_GROUP_VALUE_NAME	ValueType,	//in
						long							*IntVal,	//out
						char							*StrVal);	//out

SAPIUM int SAPIUMSCPSet(
	                char *Address);

SAPIUM int SAPIUMLogoff(
	                SAPI_UM_SES_HANDLE	Handle);

SAPIUM void SAPIUMHandleRelease (void *Handle);

SAPIUM int SAPIUMFinalize();

SAPIUM int SAPIUMGetTokenID(
	                SAPI_UM_SES_HANDLE	Handle,
	                char				*TokenID);

SAPIUM int SAPIUMSetTokenID(
	                SAPI_UM_SES_HANDLE	Handle,
	                char				*TokenID);

SAPIUM int SAPIUMResetPasswordCounter(
							SAPI_UM_SES_HANDLE		Handle,
							SAPI_LPCWSTR			UserLoginName);	//IN

SAPIUM int SAPIUMUserGetByKind(
	                SAPI_UM_SES_HANDLE		Handle,			//IN mandatory
	                SAPI_LPCWSTR			UserIdValue,	//IN
					SAPI_ENUM_USER_ID_KIND  IdKind,			//IN
					SAPI_UM_USR_HANDLE		*UserHandle);	//OUT mandatory


SAPIUM int SAPIUMCAGetEnumInit(
					SAPI_UM_SES_HANDLE					Handle,			//IN mandatory
	                SAPI_UM_CONTEXT						CAEnumContext,
					int									OrderDescending, // if 1 order desc, if 0 order ascending
					unsigned long						Flags,
					SAPI_LPCWSTR						FlagsStrValue);

SAPIUM int SAPIUMCAGetEnumCont(
						SAPI_UM_SES_HANDLE					Handle,
						SAPI_UM_CONTEXT						CAEnumContext,
						SAPI_UM_CA_RECORD					*CAList,
						unsigned long						*NumOfCAs);

SAPIUM int SAPIUMGroupAssignCA(
		                SAPI_UM_SES_HANDLE			Handle,
						SAPI_TECH_ID				GroupTechID,
						SAPI_TECH_ID				CATechID,
						unsigned long				Operation,
						unsigned long				Flags);

#ifdef  __cplusplus
}
#endif

#endif