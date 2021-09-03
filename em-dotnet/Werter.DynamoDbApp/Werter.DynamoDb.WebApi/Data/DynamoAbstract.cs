using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace Werter.DynamoDb.WebApi.Data
{
    public abstract class DynamoAbstract<T> where T : class, new()
    {
        private readonly IDynamoDBContext _context;

        protected DynamoAbstract(IDynamoDBContext context)
        {
            _context = context;
        }

        protected async Task<List<T>> Scan()
        {
            return await _context
                .ScanAsync<T>(new List<ScanCondition>())
                .GetRemainingAsync();
        }

        protected async Task<List<T>> QueryByHash(object hashKey)
        {
            return await _context.QueryAsync<T>(hashKey).GetRemainingAsync();
        }

        // protected async Task Atualizar(int id, T obj)
        // {
        //     await _context.CreateBatchWrite<T>();
        // }

        public async Task Save(T obj)
        {
            await _context.SaveAsync<T>(obj);
        }
    }
}