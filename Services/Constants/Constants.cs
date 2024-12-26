namespace VCodify.Services.Constants
{
    public static class Constants
    {
        public const string ApproveTripContext = "approvedrejecttrip/";
        public const string RejectTripContext = "approvedrejecttrip";
        public const string SetPinContext = "supervisorpin";
        public const int Pbkdf2Iterations = 12000;
        public const string ImageContentType = "image/png";
        public const string PdfExtention = ".pdf";
        public const string CsvExtention = ".csv";
        public const int ResourceLimit = 10;
        public const int WebsiteLimit = 10;
        public const long MaxRequestBodySize = 10000000000000000;

        //User Roles
        public const string TeleconnexAgentRole = "teleconnex_agent";
        public const string TeleconnexAdminRole = "teleconnex_admin";
        public const string Astrologer = "2";
        public const string User = "3";
        public const string SuperAdmin = "1";
        //gzip constants
        public const string TextPlain = "text/plain";
        public const string TextCss = "text/css";
        public const string AppJavaScript = "application/javascript";
        public const string TextHtml = "text/html";
        public const string AppXml = "application/xml";
        public const string TextXml = "text/xml";
        public const string AppJson = "application/json";
        public const string TextJson = "text/json";
        public const string ImageSvg = "image/svg+xml";
    }
}
