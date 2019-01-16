#ifndef __ASN1FUNCS__
#define __ASN1FUNCS__

#define ASN1_PrintableString    0x13
#define ASN1_UniversalString	0x1c
#define ASN1_BMPString			0x1e
#define ASN1_UTF8STRING			0x0C

int GetDnameSN(
             BYTE * cert,					/* IN: asn.1 encoded certificate */
			 int	certLen,				/* IN: length, in bytes, of cert */
			 BYTE **subjectDname,			/* OUT: pointer to start of subject dname */
			 int  *	subjectDnameLen,		/* OUT: length, in bytes, of subjectDname */
			 BYTE **issuerDname,			/* OUT: pointer to start of issuer dname */
			 int  * issuerDnameLen,			/* OUT: length, in bytes, of issuerDname */
			 BYTE **SN,						/* OUT: pointer to start of serial number */
			 int  * SNLen);					/* OUT: length, in bytes, of serial number */

int GetRawPubKeyFromASN1PubKey(
				BYTE * ASN1PubKey,					/* IN: asn.1 encoded certificate */
				int	ASN1PubKeyLen,				/* IN: length, in bytes, of cert */
				BYTE **PubKey,						/* OUT: pointer to start of serial number */
				int  * PubKeyLen);					/* OUT: length, in bytes, of serial number */


void get_CN_from_SN(
                    unsigned char	*subject_dname,
				    int				subject_dname_len,
					unsigned char	**CN,
					int				*CN_len,
				    unsigned char	*CN_field_type);



#endif


