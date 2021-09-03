using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Werter.DynamoDb.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Estudos do DynamoDB",
                    Description = "Esta API serve de laboratório para meus estudos do DynamoDB",
                    Contact = new OpenApiContact { Name = "Werter Bonfim", Email = "werter@hotmail.com.br" },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/license") }
                });
                
                //c.AddSecurityDefinition();
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            }
        }
    }
}