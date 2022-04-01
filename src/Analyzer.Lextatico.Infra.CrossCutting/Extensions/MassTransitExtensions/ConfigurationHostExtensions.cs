using MassTransit;
using Microsoft.Extensions.Configuration;

namespace Analyzer.Lextatico.Infra.CrossCutting.Extensions.MassTransitExtensions
{
    public static class ConfigurationHostExtensions
    {
        public static void ConfigurationAccountHost(this IRabbitMqBusFactoryConfigurator cfg, IConfiguration configuration)
        {
            cfg.Host(configuration.GetConnectionString("RabbitMqAccount"), config => {
                config.PublisherConfirmation = true;
            });
        }
    }
}
