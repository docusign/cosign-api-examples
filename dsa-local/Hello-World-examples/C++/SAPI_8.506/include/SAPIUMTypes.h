#ifndef __SAPIUMTYPES_H__
#define __SAPIUMTYPES_H__

#include "SAPIUMConsts.h"
#include "SAPIUMEnums.h"

/*
 * Windows like type definitions
 */
#ifndef DONT_OVERLOAD_TYPE_DEFINITIONS
#define DONT_OVERLOAD_TYPE_DEFINITIONS
#include "wintypes.h"
#endif

typedef void (SAPI_WINAPI *SAPI_UM_CALC_CREDENTIALS_CALLBACK)(
											unsigned char	*Password,
											unsigned long	PasswordLen,
											unsigned char	*CalcCredential,
											unsigned long	*CalcCredentialLen,
											unsigned char	*ExtraCredential,
											unsigned long	*ExtraCredentialLen);


typedef void			*SAPI_UM_SES_HANDLE;
typedef unsigned char	SAPI_UM_CONTEXT[UM_OPAQUE_CONTEXT_LENGTH];
typedef void			*SAPI_UM_USR_HANDLE;

typedef char			SAPI_UM_GUID[SAPIUM_GUID_LENGTH];

typedef __int64 SAPI_TECH_ID;

typedef unsigned char SAPI_ENUM_USERS_CONTEXT[UM_ENUM_USERS_CONTEXT_LENGTH];

typedef int             SAPI_UM_BOOL;

typedef struct {
	unsigned long	MajorVersion;
	unsigned long	MinorVersion;
}SAPI_UM_INFO_STRUCT, *PSAPI_UM_INFO_STRUCT;

// allows filtering and sorting of results. note that only one order parameter can be used.
typedef struct {
	SAPI_LPCWSTR			UserLoginName;					// if not NULL, order results by name starting from the given value
	SAPI_LPCWSTR			UserCN;							// if not NULL, order results by CN starting from the given value
	SAPI_LPCWSTR			EmailAddress;					// if not NULL, order results by mail starting from the given value
	unsigned long			UpdateTime;						// if not -1, order results by update time starting from the given value
	SAPI_UM_ENUM_USER_ENROLLMENT_STATUS EnrollmentStatus;	// if not -1 filter results where enrollment status matches
	long					RightsMask;						// if not -1 filter results where rights mask matches
	int						OrderDescending;				// if 1 order desc, if 0 order ascending
}SAPI_UM_USERS_EXTENDED_FILTER_STRUCT;

typedef struct {
	SAPI_UM_ENUM_USER_TYPE				 UserType;
	SAPI_UM_USERS_EXTENDED_FILTER_STRUCT *ExtendedFilter;
}SAPI_UM_USERS_FILTER_STRUCT;

typedef struct {
	SAPI_TECH_ID					TechID;
	SAPI_WCHAR						Name[SAPIUM_MAX_GROUP_NAME_LENGTH];
	SAPI_WCHAR						Address[SAPIUM_MAX_GROUP_ADDRESS_LENGTH];
    SAPI_WCHAR    					PhoneNumber[SAPIUM_PHONE_NUMBER_LENGTH];
	char							Country[SAPIUM_COUNTRY_LEN + 1];
	SAPI_WCHAR						DomainName[SAPIUM_MAX_DOMAIN_NAME_LENGTH];
	SAPI_WCHAR						OrganizationName[SAPIUM_MAX_ORGANIZATION_LENGTH];
	SAPI_WCHAR						OrganizationUnitName[SAPIUM_MAX_ORGANIZATIONAL_UNIT_LENGTH];
	SAPI_UM_ENUM_GROUP_KEY_SIZE		KeySize;
	SAPI_UM_ENUM_GROUP_STATUS_TYPE	GroupStatus;
	unsigned long					PackagesMask;
	unsigned long					FlagsMask;
} SAPI_UM_GROUP_RECORD;

typedef struct
{
	SAPI_WCHAR				Name[SAPIUM_MAX_CA_NAME_LENGTH];
	SAPI_WCHAR				Organization[SAPIUM_MAX_ORGANIZATION_LENGTH];
	SAPI_WCHAR				OrganizationalUnit[SAPIUM_MAX_ORGANIZATIONAL_UNIT_LENGTH];
	char					Country[SAPIUM_COUNTRY_LEN+1];
	SAPI_WCHAR	 			City[SAPIUM_MAX_CITY_LENGTH];
	SAPI_WCHAR				State[SAPIUM_MAX_STATE_LENGTH];
	SAPI_WCHAR				Email[SAPIUM_MAX_EMAIL_LENGTH];
	unsigned long			KeySize;
	unsigned long 			CertHashAlgorithm;
	SAPI_WCHAR 				LocalityName[SAPIUM_MAX_LOCALITY_LENGTH];
	SAPI_WCHAR				RootCertCN[SAPIUM_CN_LENGTH];
	unsigned long			CertValidityInDays;
	
}SAPI_UM_BASE_CERT_INFO;

typedef struct 
{
	SAPI_WCHAR			AIAPublicationLocation[SAPIUM_MY_MAX_AIA_PUBLICATION_LENGTH];
	SAPI_UM_BOOL 		UseAIAPublicationLocation; // true, update not allowed 
	SAPI_WCHAR			CRLPublicationLocation[SAPIUM_MY_MAX_CRL_PUBLICATION_LENGTH];
	SAPI_UM_BOOL 		UseCRLPublicationLocation; // true, update not allowed
	char				CPSObjectID [SAPIUM_MAX_CPS_OBJECT_ID_LENGTH];		
	char				CPSUri[SAPIUM_MAX_CPS_URI_LENGTH];
	unsigned long		KeyUsageMask;
	SAPI_UM_BOOL		EnhancedKeyUsageEnabled;
	unsigned long		EnhancedKeyUsageMask;
}SAPI_UM_EXTENDED_CERT_INFO;

typedef struct 
{
	SAPI_WCHAR				CAUserName[SAPIUM_MAX_CA_USER_NAME_LENGTH];
	SAPI_WCHAR				CAUserPassword[SAPIUM_MAX_CA_USER_PASSWORD_LENGTH];
	SAPI_WCHAR 				ServiceConnectionPoint[SAPIUM_MAX_SERVICE_CONNECTION_POINT_URL_LEN];
	SAPI_WCHAR 				CertificateProfileID[SAPIUM_MAX_CERT_PROFILE_ID];
	SAPI_WCHAR 				AuthCertSerialNumber[SAPIUM_CERT_SERIAL_NUMBER_LEN];
	SAPI_WCHAR 				AccountName[SAPIUM_MAX_CA_ACCOUNT_NAME];
	
}SAPI_UM_CA_ACCOUNT_INFO;

typedef struct 
{
	SAPI_UM_BOOL		AddCertificateToCrl;
	unsigned long		CrlPublishingFrequency;
	unsigned long		CrlValidityPeriod;
	unsigned long		CertificateValidityPeriodInYears;
	unsigned long		CertificateRefreshWindow;
	unsigned long		CertificateExpirationVariance;
	unsigned long		CATasks;
}SAPI_UM_CA_PROCESS_INFO;

typedef struct
{
	SAPI_TECH_ID				CATechID;
	SAPI_UM_ENUM_CA_TYPE 		Type;
	SAPI_WCHAR					Description[SAPIUM_MAX_DESCRIPTION_LENGTH];
	SAPI_WCHAR					CAVersion[SAPIUM_MAX_CA_VERSION_LEN];
	unsigned long 				CAOCSPSecondsBeforeSignTime;
	unsigned long 				CAOCSPSecondsNextUpdate;
	SAPI_UM_ENUM_CA_ROLE		CARole; 
	SAPI_WCHAR 					ValidDomains[SAPIUM_MAX_VALID_EMAIL_DOMAINS];
	SAPI_UM_ENUM_CA_STATUS		CAStatus;
	SAPI_UM_BOOL				RegenerateUserKey;
	SAPI_UM_BASE_CERT_INFO		BaseCertInfo;
	SAPI_UM_EXTENDED_CERT_INFO	ExtendedCertInfo;
	SAPI_UM_CA_ACCOUNT_INFO		CAAccountInfo;
	SAPI_UM_CA_PROCESS_INFO		CAProcessInfo;

}SAPI_UM_CA_RECORD;

#endif