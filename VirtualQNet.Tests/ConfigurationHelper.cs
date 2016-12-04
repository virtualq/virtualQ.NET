using System.Configuration;

namespace VirtualQNet.Tests
{
    public static class ConfigurationHelper
    {
        public static string GetApiUrl() =>
             ConfigurationManager.AppSettings["ApiUrl"];

        public static string GetApiKey() =>
             ConfigurationManager.AppSettings["ApiKey"];

        public static int GetTimeout()
        {
            int timeout;
            int.TryParse(ConfigurationManager.AppSettings["Timeout"], out timeout);

            return timeout;
        }

    }
}
