namespace SLogConfiguration
{
    public sealed class SLogLevel
    {
        private readonly int iOrdinal;
        private readonly string sText;

        public static readonly SLogLevel Email = new SLogLevel(1, "Email");
        public static readonly SLogLevel Event = new SLogLevel(2, "Event");
        public static readonly SLogLevel Exception = new SLogLevel(3, "Exception");
        public static readonly SLogLevel Message = new SLogLevel(4, "Message");
        public static readonly SLogLevel Warning = new SLogLevel(5, "Warning");

        private SLogLevel(int iValue, string sStringValue)
        {
            iOrdinal = iValue;
            sText = sStringValue;
        }

        public override string ToString()
        {
            return sText;
        }
    }
}
