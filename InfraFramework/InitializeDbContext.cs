
namespace InfraFramework
{
    public class InitializeDbContext
    {
        public InitializeDbContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string value = configuration["MyKey"];
        }
    }
}
