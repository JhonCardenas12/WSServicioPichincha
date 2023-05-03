using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Entities;
using WSServicioPichincha.Domain.Exceptions;

namespace WSServicioPichincha.Business.Services
{
    public class MovimientosService : IMovimientosService
    {
        private readonly IRepository<Movimientos> movimientosRepository;
        private readonly IRepository<Cuenta> cuentaRepository;
        private readonly IRepository<Cliente> clienteRepository;
        private readonly IRepository<Persona> personaRepository;
        
        public MovimientosService(IRepository<Movimientos> movimientosRepository, IRepository<Cuenta> cuentaRepository,
            IRepository<Cliente> clienteRepository, IRepository<Persona> personaRepository)
        {
            this.movimientosRepository = movimientosRepository;
            this.cuentaRepository = cuentaRepository;
            this.clienteRepository = clienteRepository;
            this.personaRepository = personaRepository;
        }
        public async Task<Movimientos> Delete(int id)
        {
            return await movimientosRepository.Delete(id);
        }

        public async Task<IEnumerable<MovimientosDetalle>> GetAll()
        {
            List<MovimientosDetalle> movimientosDetallesList = new();
            foreach (var item in await movimientosRepository.GetAll())
            {
                MovimientosDetalle movimientosDetalle = new();
                Cuenta cuenta = await cuentaRepository.GetById(item.CuentaId);
                Cliente cliente = await clienteRepository.GetById(cuenta.ClienteId);
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

            return movimientosDetallesList;
        }

        public async Task<Movimientos> GetById(int id)
        {
            return await movimientosRepository.GetById(id);
        }

        public async Task<Movimientos> Save(Movimientos entity)
        {
            Cuenta cuenta = await cuentaRepository.GetById(entity.CuentaId);
            if (cuenta != null)
            {
                List<Movimientos> movimientos = movimientosRepository.GetAll().Result.Where(x => x.CuentaId == entity.CuentaId).ToList();
                decimal movimientosSaldo = 0;
                foreach (var item in movimientos)
                {
                    movimientosSaldo += item.Valor;
                }

                entity.Saldo = cuenta.SaldoInicial + movimientosSaldo + entity.Valor;
                if (entity.Saldo <= 0)
                {
                    throw new PichinchaException($"Saldo no disponible, por favor valide.");
                }
                if (entity.Valor > 0)
                    entity.Tipo = $"Deposito de {entity.Valor}";
                else
                    entity.Tipo = $"Retiro de {Math.Abs(entity.Valor)}";


                return await movimientosRepository.Save(entity);
            }
            throw new PichinchaException($"La cuenta con el Id: {entity.CuentaId} que desea agregar no existe, por favor valide.");
        }

        public async Task<Movimientos> Update(Movimientos entity)
        {
            Cuenta cuenta = await cuentaRepository.GetById(entity.CuentaId);
            if (cuenta != null)
            {
                entity.Saldo = cuenta.SaldoInicial + entity.Valor;
                return await movimientosRepository.Update(entity);
            }
            throw new PichinchaException($"La cuenta con el Id: {entity.CuentaId} que desea actualizar no existe, por favor valide.");
        }
    }
}
