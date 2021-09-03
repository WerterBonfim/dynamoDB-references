using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Amazon.Util;
using ConsoleTables;

namespace Werter.DynamoDbApp
{
    public class Rascunho
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly IDynamoDBContext _context;

        private readonly AWSCredentials _credenciais =
            new BasicAWSCredentials("fakeMyAccessKey", "fakeSecretAccessKey");

        private readonly AmazonDynamoDBConfig _config = new()
        {
            ServiceURL = "http://localhost:7000",
            AuthenticationRegion = "ap-southeast-1"
        };

        public string NomeDaTabela { get; } = "ProdutosDotnet";

        public Rascunho()
        {
            _client = new AmazonDynamoDBClient(_credenciais, _config);
            _context = new DynamoDBContext(_client);
            
            
        }

        public async Task ExecutarExemplos()
        {
            await CriarTabela();
            //await ListarTabelas();
            // await VerificaSeTabelaExiste(NomeDaTabela);
            //await AdicionarUmProduto();
            //await ExtrairInformacoes();

            await AdicionarProdutoViaContexto();
            await ListarOsProdutos();
        }

        public async Task ListarTabelas()
        {
            var resposta = await _client.ListTablesAsync();
            VerificaSeOcorreuAlgumErro(resposta);

            foreach (var tabela in resposta.TableNames)
                Console.WriteLine(tabela);
        }

        public async Task ExtrairInformacoes()
        {
            var time = await _client.DescribeTimeToLiveAsync(NomeDaTabela);
            var endpoint = await _client.DescribeEndpointsAsync(new DescribeEndpointsRequest());
        }

        public async Task CriarTabela()
        {
            var requisicao = MontarRequisicaoParaCriarTabela();
            var resposta = await _client.CreateTableAsync(requisicao);
            VerificaSeOcorreuAlgumErro(resposta);
        }

        public async Task VerificaSeTabelaExiste(string tabela)
        {
            var resposta = await _client.DescribeTableAsync(NomeDaTabela);
        }

        public async Task AdicionarUmProduto()
        {
            var item = new PutItemRequest(NomeDaTabela, new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue { N = "2" } },
                { "Tipo", new AttributeValue { S = "Instrumento" } },
                { "Nome", new AttributeValue { S = "Ibanez" } }
            });

            var resposta = await _client.PutItemAsync(item);

            VerificaSeOcorreuAlgumErro(resposta);
        }

        public async Task AdicionarProdutoViaContexto()
        {
            var alicate = new Produto { Nome = "Alicate", Tipo = "Ferramenta" };
            await _context.SaveAsync(alicate);
        }


        public async Task ListarOsProdutos()
        {
            var resposta = await _client.ScanAsync(NomeDaTabela, new List<string>());
            VerificaSeOcorreuAlgumErro(resposta);

            var produtos = await _context.ScanAsync<Produto>(null)
                .GetRemainingAsync();

            ConsoleTable.From(produtos).Write();
        }

        private CreateTableRequest MontarRequisicaoParaCriarTabela()
        {
            return new CreateTableRequest
            {
                TableName = NomeDaTabela,
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new("Id", ScalarAttributeType.N),
                    new("Tipo", ScalarAttributeType.S)
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new("Id", KeyType.HASH), // Partition Key
                    new("Tipo", KeyType.RANGE) // Sort Key
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 1,
                    WriteCapacityUnits = 1
                }
            };
        }

        private static void VerificaSeOcorreuAlgumErro(AmazonWebServiceResponse resposta)
        {
            if (resposta == null) throw new Exception("Ocorreu um erro ao tentar fazer uma requisição");

            if (resposta.HttpStatusCode == HttpStatusCode.OK)
                return;

            var excessao = new Exception("Erro ao tentar consumir algum recurso da AWS DynamoDB");
            excessao.Data.Add("Reposta AWS DynamoDB", resposta);
            throw excessao;
        }
    }
}