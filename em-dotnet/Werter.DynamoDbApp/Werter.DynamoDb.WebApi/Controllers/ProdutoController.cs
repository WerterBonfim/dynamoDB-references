using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Werter.DynamoDb.WebApi.Data.Repository;
using Werter.DynamoDb.WebApi.Models;

namespace Werter.DynamoDb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar(Produto produto)
        {
            await _produtoRepository.Save(produto);
            return Created($"/{produto.Id}", produto);
        }
        
        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var clientes = await _produtoRepository.ListarTodos();
            return Ok(clientes);
        }
        
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var cliente = await _produtoRepository.ObterPorId(id);
            if (!cliente.Any())
                return NotFound();
            
            return Ok(cliente.FirstOrDefault());
        }

        [HttpPatch]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Produto produto)
        {
            await _produtoRepository.Atualizar(id, produto);
            return NoContent();
        }
        
    }
}