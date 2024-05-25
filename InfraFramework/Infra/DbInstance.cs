using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace InfraFramework.Infra
{
    public static class DbInstance
    {
        private static IConfiguration _config;
        private static string _stringCon;

        public static async Task<SqlConnection> setDatabaseIntance()
        {
            try
            {
                _config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                _stringCon = _config["ConnectionStrings:SQLStringCon"].ToString();

                var conn = new SqlConnection(_stringCon);
                return conn;
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }
        
        public static bool verifyIsConected(SqlConnection _conn)
        {
            var state = _conn;
            if (state.State == System.Data.ConnectionState.Closed)
                return false;
            else
                return true;
        }
    }
}



