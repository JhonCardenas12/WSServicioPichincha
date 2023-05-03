using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Entities;
using WSServicioPichincha.Domain.Exceptions;

namespace WSServicioPichincha.Business.Services
{
    public class ReportesService : IReportesService
    {
        private readonly IRepository<Movimientos> movimientosRepository;
        private readonly IRepository<Cuenta> cuentaRepository;
        private readonly IRepository<Cliente> clienteRepository;
        private readonly IRepository<Persona> personaRepository;

        public ReportesService(IRepository<Movimientos> movimientosRepository, IRepository<Cuenta> cuentaRepository,
            IRepository<Cliente> clienteRepository, IRepository<Persona> personaRepository)
        {
            this.movimientosRepository = movimientosRepository;
            this.cuentaRepository = cuentaRepository;
            this.clienteRepository = clienteRepository;
            this.personaRepository = personaRepository;
        }

        public async Task<IEnumerable<MovimientosDetalle>> GetReport(DateTime FechaInicial, DateTime FechaFinal, int ClienteId)
        {
            List<MovimientosDetalle> movimientosDetallesList = new();
            foreach (var item in movimientosRepository.GetAll().Result.Where(x => x.Fecha >= FechaInicial && x.Fecha <= FechaFinal).ToList())
            {
                MovimientosDetalle movimientosDetalle = new();
                Cuenta cuenta = await cuentaRepository.GetById(item.CuentaId);
                Cliente cliente = await clienteRepository.GetById(cuenta.ClienteId);
                if (cliente.ClienteId == ClienteId)
                {
                    Persona persona = await personaRepository.GetById(cliente.PersonaId);

                    movimientosDetalle.Fecha = item.Fecha;
                    movimientosDetalle.Cliente = persona.Nombre;
                    movimientosDetalle.NumeroCuenta = cuenta.Numero;
                    movimientosDetalle.Tipo = cuenta.Tipo;
                    movimientosDetalle.SaldoInicial = cuenta.SaldoInicial;
                    movimientosDetalle.Estado = cuenta.Estado;
                    movimientosDetalle.Movimiento = item.Valor;
                    movimientosDetalle.SaldoDisponible = item.Saldo;
                    movimientosDetallesList.Add(movimientosDetalle);
                }
            }
            if (movimientosDetallesList.Count == 0)
                throw new PichinchaException($"No se encontro informació para el rango de fechas entre {FechaInicial} y {FechaFinal} y el Id del cliente {ClienteId}");

            return movimientosDetallesList;
        }
    }
}
