#ifndef __WINTYPES_H__
#define __WINTYPES_H__

typedef unsigned short		SAPI_wchar_t;
typedef SAPI_wchar_t		SAPI_WCHAR;    // wc,   16-bit UNICODE character
typedef const SAPI_WCHAR	*SAPI_LPCWSTR;
typedef SAPI_WCHAR			*SAPI_LPWSTR;
typedef const char			*SAPI_LPCSTR;
typedef char				*SAPI_LPSTR;
typedef void	            *SAPI_LPVOID;

// should be changed to standard 64 bits 
//typedef long				SAPI_time;

typedef struct {
	struct {
		unsigned long LowDateTime;
		unsigned long HighDateTime;
	} LocalTime;
	long			GMTOffset; // in minutes
}   SAPI_FILETIME;


#ifndef WINAPI
#define WINAPI      __stdcall
#endif
#ifndef APIENTRY
#define APIENTRY    WINAPI
#endif

#define SAPI_WINAPI WINAPI

#ifndef TRUE
#define TRUE		1
#endif
#ifndef FALSE
#define FALSE		0
#endif

#endif