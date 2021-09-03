using System;
using Amazon.DynamoDBv2.DataModel;

namespace Werter.DynamoDb.WebApi.Models
{
    [DynamoDBTable("ProdutosDotnet")]
    public class Produto
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        
        [DynamoDBRangeKey]
        public string Tipo { get; set; }

        [DynamoDBProperty]
        public string Nome { get; set; }
    }
}