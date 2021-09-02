using System;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace Werter.DynamoDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Explorando DynamoDB Local");
            
            new Rascunho().ExecutarExemplos().Wait();
        }
    }
}