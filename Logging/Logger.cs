using Elastic.Channels;
using Elastic.CommonSchema.Serilog;
using Elastic.Ingest.Elasticsearch;
using Elastic.Serilog.Sinks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Logging
{
    public static class Logger
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =>
            (context, loggerConfiguration) => {
                var env = context.HostingEnvironment;
                loggerConfiguration.MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("ApplicationName", env.ApplicationName)
                    .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                    .WriteTo.Console();

                if (context.HostingEnvironment.IsDevelopment())
                {
                    loggerConfiguration.MinimumLevel.Override("API", LogEventLevel.Debug);
                }
                var elasticUrl = context.Configuration.GetValue<string>("ElasticConfiguration:Uri");
                if (!string.IsNullOrEmpty(elasticUrl))
                {
                    loggerConfiguration.WriteTo.Elasticsearch(new[] { new Uri(elasticUrl) },
                   options =>
                   {
                       //Есть мастер Ingest и дата ноды
                       options.DataStream = new Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName($"api-logs-{DateTime.UtcNow:yyyy.MM.dd}-generic");

                       // Форматирование текста, использующее Elastic Common Schema(стандарт).
                       options.TextFormatting = new EcsTextFormatterConfiguration();

                       // Тут ты выбираешь либо Success/Failure т.е приложение завершит ли работу если индекс не создался
                       options.BootstrapMethod = BootstrapMethod.Failure;

                       // указываешь настройки канала для отправки логов в ElasticSearch
                       options.ConfigureChannel = channelOptions =>
                       {
                           // тут всякие настройки буфера на стороне приложения перед отправкой в ElasticSearch
                           channelOptions.BufferOptions = new BufferOptions()
                           {
                           };
                       };
                   });
                }
            };

    }
}
