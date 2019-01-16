#ifndef __LLCLIENT__INT_H
#define __LLCLIENT_INT_H

#ifdef  __cplusplus
extern  "C" {
#endif

//
//	cosign_logon_dialog-
//				Define in Internal header file - No need to expose this in the formal LLClient header file
//
__declspec(dllexport) int cosign_logon_dialog(void **param, int dialog_type, WCHAR *domain, WCHAR *username, int usr_dom_len, unsigned char *credential, int *credential_len);

#ifdef  __cplusplus
}
#endif
#endif