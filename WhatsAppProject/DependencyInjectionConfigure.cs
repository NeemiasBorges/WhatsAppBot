using Infra.Interfaces;
using Infra.Repositorio; 
using Microsoft.Extensions.DependencyInjection; 
using System.Windows.Forms;

namespace WhatsAppProject
{
    public static class DependencyInjectionConfig
    {
        //public static ServiceCollection Configure()
        //{
        //    var services = new ServiceCollection();
        //    services.AddSingleton<IMensagensRepository, MensagemRepository>();
        //    var serviceProvider = services.BuildServiceProvider();
        //    return services;
        //}

        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IMensagensRepository, MensagemRepository>();
            return services.BuildServiceProvider();
        }
    }
}
