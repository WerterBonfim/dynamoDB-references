using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Werter.DynamoDb.WebApi.Models;

namespace Werter.DynamoDb.WebApi.Data.Repository
{
    public class ProdutoRepository : DynamoAbstract<Produto>
    {
        public ProdutoRepository(IDynamoDBContext context) : base(context)
        {
        }

        public async Task<List<Produto>> ListarTodos() => await Scan();
        public async Task<List<Produto>> ObterPorId(int id) => await QueryByHash(id);

        public async Task Atualizar(int id, Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}