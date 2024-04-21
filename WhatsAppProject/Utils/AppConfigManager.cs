using System.Collections.Specialized;
using System.Configuration;

namespace WhatsAppProject.Utils
{
    public class AppConfigManager
    {
        private NameValueCollection GetSection(string sectionName)
        {
            var section = ConfigurationManager.GetSection(sectionName) as NameValueCollection;
            if (section == null)
            {
                throw new ConfigurationErrorsException($"A seção '{sectionName}' não foi encontrada no arquivo de configuração.");
            }
            return section;
        }

        public string? GetSeleniumOption(string key)
        {
            var seleniumSection = GetSection("SeleniumDef");
            var value           = seleniumSection.GetValues(key);
            return value[0] ?? "";
        }

        public string GetConfigOption(string key)
        {
            var configSection = GetSection("ConfigSettings");
            var value         = configSection.GetValues(key);
            return value[0] ?? "";
        }

        public string GetLogOption(string key)
        {
            var logSection = GetSection("LogSettings");
            var value      = logSection.GetValues(key);
            return value[0] ?? "";
        }
    }
}