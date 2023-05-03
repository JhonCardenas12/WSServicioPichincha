using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Business.Interfaces
{
    public interface IReportesService
    {
        Task<IEnumerable<MovimientosDetalle>> GetReport(DateTime FechaIncial, DateTime FechaFinal, int ClienteId);
    }
}
