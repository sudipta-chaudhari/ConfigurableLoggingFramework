namespace SLogConfiguration
{
    public class LoggerFactory
    {
        public static ILog GetLogger(LoggerType loggerType)
        {
            ILog objLogger;

            switch (loggerType)
            {
                case LoggerType.DATABASE:
                    objLogger = new DatabaseLogger();
                    break;

                case LoggerType.FILE:
                    objLogger = new FileLogger();
                    break;

                default:
                    objLogger = null;
                    break;
            }

            return objLogger;
        }
    }
}
