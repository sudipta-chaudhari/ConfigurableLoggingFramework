using System;


namespace SLogConfiguration
{
    public static class SLogConfig
    {
        public static string UserName { get; set; }
        public static string MachineName { get; set; }
        public static string LogConnectionString { get; set; }
        public static string LoggerName { get; set; }
        public static string ApplicationName { get; set; }
        public static ApplicationType ApplicationType { get; set; }
        public static SLogLevel LogLevel { get; set; }
    }
}
