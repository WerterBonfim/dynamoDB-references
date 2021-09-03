using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Werter.DynamoDb.WebApi.Models;

namespace Werter.DynamoDb.WebApi.Data.Repository
{
    public class ClienteRepository : DynamoAbstract<Cliente>
    {
        public ClienteRepository(IDynamoDBContext context) : base(context)
        {
        }

        public async Task<List<Cliente>> GetAll() => await Scan();
        public async Task<List<Cliente>> GetById(Guid id) => await QueryByHash(id);
    }
}