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
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteController(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            await _clienteRepository.Save(cliente);
            return Created($"/{cliente.Id}", cliente);
        }
        
        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var clientes = await _clienteRepository.GetAll();
            return Ok(clientes);
        }
        
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var cliente = await _clienteRepository.GetById(id);
            if (!cliente.Any())
                return NotFound();
            
            return Ok(cliente.FirstOrDefault());
        }
    }
}