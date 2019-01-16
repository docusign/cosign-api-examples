// arstderrlog.h: interface for the arstderrlog class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_ARSTDERRLOG_H__D1D778D8_A71F_4478_998A_F952E33A8318__INCLUDED_)
#define AFX_ARSTDERRLOG_H__D1D778D8_A71F_4478_998A_F952E33A8318__INCLUDED_
#include "arerrlog.h"
#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define LOG_SET_STDOUT(appname)		ARSTDErrLog::LogInit(appname)
#define LOG_END_THREAD_STDOUT		{if(ARErrLog::Debug()) ARSTDErrLog::KillObject();}
#define LOG_STDOUT					ARSTDErrLog::GLogMessage

class ARSTDErrLog : public ARErrLog  
{
protected:
	ARSTDErrLog(UINT id):ARErrLog(id){};
	virtual ~ARSTDErrLog(){};

public:
    static void GLogMessage( ERR_LOG_LEVEL lvl , const char * sFormat, ... )
    {
        if (level<lvl) return;
        ARErrLog *o=ARSTDErrLog::Object();
		if (o)
		{
			va_list args;
			va_start(args,sFormat);
			o->vLogMessage(lvl,sFormat,args);
			va_end(args);
		}
    }
	static ARErrLog *Object();
	virtual void Flush(char *buf);
	static void KillObject();
	static int LogInit(char *appname);
};

#endif // !defined(AFX_ARSTDERRLOG_H__D1D778D8_A71F_4478_998A_F952E33A8318__INCLUDED_)
