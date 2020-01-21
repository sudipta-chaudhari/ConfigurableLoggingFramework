using System;
using SLogConfiguration;

namespace SLog
{
    public sealed class SLog : IDisposable
    {
        #region Variables
        private static readonly Lazy<SLog> lazy = new Lazy<SLog>(() => new SLog());
        private static ILog logger = null;
        #endregion

        #region Properties
        private static SLog Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public string Name { get; private set; }
        public static LoggerType LoggerType { get; private set; }
        #endregion

        #region Ctor
        private SLog() { }
        #endregion

        #region Methods

        #region Initialize
        public static ILog Initialize(string sLogConnectionString, string loggerName, string sApplicationName, ApplicationType applicationType,
            SLogLevel logLevel, string userName, LoggerType loggerType)
        {
            switch (loggerType)
            {
                case LoggerType.DATABASE:

                    LoggerType = LoggerType.DATABASE;

                    logger = (DatabaseLogger)LoggerFactory.GetLogger(LoggerType.DATABASE);

                    break;

                case LoggerType.FILE:

                    logger = (FileLogger)LoggerFactory.GetLogger(LoggerType.FILE);

                    break;
            }

            return logger;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            if (logger != null)
                logger = null;
        }
        #endregion

        #endregion 
    }
}
