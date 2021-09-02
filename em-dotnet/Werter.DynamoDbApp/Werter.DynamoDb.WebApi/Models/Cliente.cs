using System;
using Amazon.DynamoDBv2.DataModel;

namespace Werter.DynamoDb.WebApi.Models
{
    [DynamoDBTable("ClienteTable")]
    public class Cliente
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }

        [DynamoDBProperty]
        public string Nome { get; set; }
        
        [DynamoDBProperty]
        public string Cpf { get; set; }
        
        [DynamoDBProperty]
        public string DataNascimento { get; set; }
    }
}