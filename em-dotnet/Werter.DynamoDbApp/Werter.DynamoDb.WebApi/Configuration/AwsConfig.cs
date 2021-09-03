using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Werter.DynamoDb.WebApi.Extencions;

namespace Werter.DynamoDb.WebApi.Configuration
{
    public static class AwsConfig
    {
        public static void AddAwsConfiguration(this IServiceCollection servicos, IConfiguration configuracao)
        {
            var section = configuracao.GetSection("DynamoDb");
            var dynamoDbConfig = section.Get<DynamoDbSettings>();

            if (!dynamoDbConfig.ModoLocal)
            {
                servicos.AddAWSService<IAmazonDynamoDB>();
                return;
            }

            servicos.AddSingleton<IAmazonDynamoDB>(sp =>
            {
                var config = new AmazonDynamoDBConfig();
                config.ServiceURL = dynamoDbConfig.Url;

                var credencial = new BasicAWSCredentials(dynamoDbConfig.AccessKeyId, dynamoDbConfig.SecretAccessKey);
                return new AmazonDynamoDBClient(credencial, config);
            });

        }
    }
}