using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportesController : ControllerBase
    {
        private IReportesService reportesService;
        public ReportesController(IReportesService reportesService)
        {
            this.reportesService = reportesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DateTime fechaIncial, DateTime fechaFinal, int ClienteId)
        {
            return Ok(await reportesService.GetReport(fechaIncial, fechaFinal, ClienteId));
        }
    }
}
