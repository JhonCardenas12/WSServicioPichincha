using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CuentaController : ControllerBase
    {
        private ICuentaService cuentaService;
        public CuentaController(ICuentaService cuentaService)
        {
            this.cuentaService = cuentaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await cuentaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await cuentaService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cuenta cuenta)
        {
            return Ok(await cuentaService.Save(cuenta));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cuenta cuenta)
        {
            return Ok(await cuentaService.Update(cuenta));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await cuentaService.Delete(id));
        }
    }
}
