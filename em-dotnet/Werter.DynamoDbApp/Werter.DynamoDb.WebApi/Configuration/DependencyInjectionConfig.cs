using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.DependencyInjection;
using Werter.DynamoDb.WebApi.Data.Repository;

namespace Werter.DynamoDb.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
            services.AddScoped<ClienteRepository>();
        }
    }
}