using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SLogConfiguration
{
    public class FileLogger : ILog
    {
        bool disposed = false;
        private readonly string folderName = string.Empty;
        private readonly string filePath = string.Empty;

        public FileLogger()
        {
            folderName = GetApplicationRoot() + "\\SLogs\\" + DateTime.Now.ToString("dd_MMM_yyyy");

            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            filePath = Path.Combine(folderName, $"log_{DateTime.Now.ToString("dd_MMM_yyyy")}.txt");
        }

        private string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }

        //public void Log(SLogLevel logLevel, string sEventType, string sMessageToLog, string sException)
        //{
        //    throw new NotImplementedException();
        //}

        public void LogEmail(string sEventType, string sMessageToLog)
        {
            throw new NotImplementedException();
        }

        public void LogEvent(string sEventType, string sMessageToLog)
        {
            throw new NotImplementedException();
        }

        public void LogException(string sEventType, string sErrorMessage, Exception ex)
        {
            throw new NotImplementedException();
        }

        public void LogException(string sEventType, string sErrorMessage, string sException)
        {
            throw new NotImplementedException();
        }

        public void LogMessage(string sEventType, string sMessageToLog)
        {
            File.AppendAllText(filePath, Environment.NewLine + DateTime.Now + " : " + sMessageToLog);
        }

        public void LogWarning(string sEventType, string sWarningToLog)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
            }

            // Free any unmanaged objects here.
            disposed = true;
        }
    }
}
