using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Business.Services;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private IClienteService clienteService;
        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await clienteService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await clienteService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            return Ok(await clienteService.Save(cliente));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            return Ok(await clienteService.Update(cliente));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await clienteService.Delete(id));
        }
    }
}
