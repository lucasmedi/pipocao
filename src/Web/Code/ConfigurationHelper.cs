using System.Configuration;

namespace Web.Code
{
    public class ConfigurationHelper
    {
        public static string TmdbToken { get; private set; }
        public static string ConfigPath { get; private set; }

        static ConfigurationHelper()
        {
            TmdbToken = ConfigurationManager.AppSettings["tmdbToken"];
            ConfigPath = ConfigurationManager.AppSettings["ConfigPath"];
        }
    }
}