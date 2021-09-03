using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Werter.DynamoDb.WebApi.Extencions;

namespace Werter.DynamoDb.WebApi.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddControllers();
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}