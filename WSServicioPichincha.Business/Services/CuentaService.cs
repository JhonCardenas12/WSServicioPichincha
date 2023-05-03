using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Entities;
using WSServicioPichincha.Domain.Exceptions;

namespace WSServicioPichincha.Business.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly IRepository<Cuenta> cuentaRepository;
        private readonly IRepository<Cliente> clienteRepository;
        public CuentaService(IRepository<Cuenta> cuentaRepository, IRepository<Cliente> clienteRepository)
        {
            this.cuentaRepository = cuentaRepository;
            this.clienteRepository = clienteRepository;
        }
        public async Task<Cuenta> Delete(int id)
        {
            return await cuentaRepository.Delete(id);
        }

        public async Task<IEnumerable<Cuenta>> GetAll()
        {
            return await cuentaRepository.GetAll();
        }

        public async Task<Cuenta> GetById(int id)
        {
            return await cuentaRepository.GetById(id);
        }

        public async Task<Cuenta> Save(Cuenta entity)
        {
            Cliente cliente = await clienteRepository.GetById(entity.ClienteId);
            if (cliente != null)
            {
                return await cuentaRepository.Save(entity);
            }
            throw new PichinchaException($"El cliente con el Id: {entity.ClienteId} que desea agregar no existe, por favor valide.");
        }

        public async Task<Cuenta> Update(Cuenta entity)
        {
            Cliente cliente = await clienteRepository.GetById(entity.ClienteId);
            if (cliente != null)
            {
                return await cuentaRepository.Update(entity);
            }
            throw new PichinchaException($"El cliente con el Id: {entity.ClienteId} que desea actualizar no existe, por favor valide.");
        }
    }
}
