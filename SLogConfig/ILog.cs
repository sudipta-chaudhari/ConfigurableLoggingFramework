using System;

namespace SLogConfiguration
{
    public interface ILog : IDisposable
    {
        void LogMessage(string sEventType, string sMessageToLog);
        void LogEvent(string sEventType, string sMessageToLog);
        void LogWarning(string sEventType, string sWarningToLog);
        void LogException(string sEventType, string sErrorMessage, Exception ex);
        void LogException(string sEventType,string sErrorMessage, string sException);
        void LogEmail(string sEventType, string sMessageToLog);
        //void Log(SLogLevel logLevel, string sEventType, string sMessageToLog, string sException);
    }
}
