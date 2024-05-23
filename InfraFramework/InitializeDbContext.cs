using Microsoft.Extensions.Configuration;
using System;

namespace InfraFramework
{
    static class InitializeDbContext
    {
        private IConfiguration _config;

        public InitializeDbContext(IConfiguration conf)
        {
            _config = conf;
            setInitializeDbContext();
        }
        public static void setInitializeDbContext()
        {
            try
            {
                var teste = _config["ConfigurationString"].ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static string ConectionString { get; set; }
    }
}
