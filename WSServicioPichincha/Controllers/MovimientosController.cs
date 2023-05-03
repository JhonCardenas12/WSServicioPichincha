using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovimientosController : ControllerBase
    {
        private IMovimientosService movimientosService;
        public MovimientosController(IMovimientosService movimientosService)
        {
            this.movimientosService = movimientosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await movimientosService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await movimientosService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Movimientos movimientos)
        {
            return Ok(await movimientosService.Save(movimientos));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Movimientos movimientos)
        {
            return Ok(await movimientosService.Update(movimientos));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await movimientosService.Delete(id));
        }
    }
}
