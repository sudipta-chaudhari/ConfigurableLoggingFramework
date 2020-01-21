namespace SLogConfiguration
{
    public class ApplicationType
    {
        private readonly int iOrdinal;
        private readonly string sText;

        public static readonly ApplicationType Website = new ApplicationType(1, "Website");
        public static readonly ApplicationType WindowsApplication = new ApplicationType(2, "Windows Application");
        public static readonly ApplicationType WindowsService = new ApplicationType(3, "Windows Service");
        public static readonly ApplicationType WebService = new ApplicationType(4, "Web Service");
        public static readonly ApplicationType Executable = new ApplicationType(5, "Executable");

        private ApplicationType(int iValue, string sText)
        {
            iOrdinal = iValue;
            this.sText = sText;
        }

        public override string ToString()
        {
            return sText;
        }
    }
}
