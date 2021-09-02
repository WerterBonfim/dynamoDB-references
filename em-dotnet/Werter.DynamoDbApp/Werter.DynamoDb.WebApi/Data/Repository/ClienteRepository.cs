using Amazon.DynamoDBv2.DataModel;
using Werter.DynamoDb.WebApi.Models;

namespace Werter.DynamoDb.WebApi.Data.Repository
{
    public class ClienteRepository : DynamoAbstract<Cliente>
    {
        public ClienteRepository(IDynamoDBContext context) : base(context)
        {
        }
    }
}