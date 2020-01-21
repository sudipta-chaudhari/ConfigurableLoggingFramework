using System;
using System.Data;
using System.Data.SqlClient;

namespace SLogConfiguration
{
    public class DatabaseLogger : ILog
    {
        bool disposed = false;

        public void LogMessage(string sEventType, string sMessageToLog)
        {
            WriteLog(SLogLevel.Event, sEventType, sMessageToLog, null);
        }
        public void LogEvent(string sEventType, string sMessageToLog)
        {
            WriteLog(SLogLevel.Event, sEventType, sMessageToLog, null);
        }
        public void LogWarning(string sEventType, string sWarningToLog)
        {
            WriteLog(SLogLevel.Warning, sEventType, sWarningToLog, null);
        }
        public void LogException(string sEventType, string sErrorMessage, Exception ex)
        {
            WriteLog(SLogLevel.Exception, sEventType, sErrorMessage, ex.ToString());
        }
        public void LogException(string sEventType, string sErrorMessage, string sException)
        {
            WriteLog(SLogLevel.Exception, sEventType, sErrorMessage, sException);
        }
        public void LogEmail(string sEventType, string sMessageToLog)
        {
            WriteLog(SLogLevel.Email, sEventType, sMessageToLog, null);
        }
        public void Log(SLogLevel logLevel, string sEventType, string sMessageToLog, string sException)
        {
           WriteLog(logLevel, sEventType, sMessageToLog, sException);
        }
        private void WriteLog(SLogLevel logLevel, string sEventType, string sLogMessage, string sStackTrace)
        {
            string sql = @"INSERT INTO [dbo].[tblLog] (app_name, app_type, log_date, log_message, log_level, event_type, userid, user_machine_name) VALUES (@app_name,@app_type,@log_date,@log_message,@log_level,@event_type,@userid,@user_machine_name)";

            using (SqlConnection cnn = new SqlConnection(SLogConfig.LogConnectionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@app_name", SqlDbType.NVarChar).Value = SLogConfig.ApplicationName;
                        cmd.Parameters.Add("@app_type", SqlDbType.NVarChar).Value = SLogConfig.ApplicationType.ToString();
                        cmd.Parameters.Add("@log_date", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@log_message", SqlDbType.NVarChar).Value = sLogMessage;
                        cmd.Parameters.Add("@log_level", SqlDbType.NVarChar).Value = logLevel.ToString();
                        cmd.Parameters.Add("@event_type", SqlDbType.NVarChar).Value = sEventType;
                        cmd.Parameters.Add("@userid", SqlDbType.NVarChar).Value = SLogConfig.UserName;
                        cmd.Parameters.Add("@user_machine_name", SqlDbType.NVarChar).Value = SLogConfig.MachineName;
                        
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR:" + ex.Message);
                    throw ex;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Dispose();
            }

            disposed = true;
        }
    }
}
