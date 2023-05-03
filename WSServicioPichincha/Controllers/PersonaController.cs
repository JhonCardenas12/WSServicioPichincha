using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonaController : ControllerBase
    {
        private IPersonaService personaService;
        public PersonaController(IPersonaService personaService)
        {
            this.personaService = personaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await personaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await personaService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Persona persona)
        {
            return Ok(await personaService.Save(persona));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Persona persona)
        {
            return Ok(await personaService.Update(persona));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await personaService.Delete(id));
        }
    }
}
