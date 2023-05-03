using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Entities;
using WSServicioPichincha.Domain.Exceptions;

namespace WSServicioPichincha.Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> clienteRepository;
        private readonly IRepository<Persona> personaRepository;
        public ClienteService(IRepository<Cliente> clienteRepository, IRepository<Persona> personaRepository)
        {
            this.clienteRepository = clienteRepository;
            this.personaRepository = personaRepository;
        }
        public async Task<Cliente> Delete(int id)
        {
            return await clienteRepository.Delete(id);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await clienteRepository.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await clienteRepository.GetById(id);
        }

        public async Task<Cliente> Save(Cliente entity)
        {
            Persona persona = await personaRepository.GetById(entity.PersonaId);
            if (persona != null)
            {
                return await clienteRepository.Save(entity);
            }
            throw new PichinchaException($"La persona con el Id: {entity.PersonaId} que desea agregar no existe, por favor valide.");
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            Persona persona = await personaRepository.GetById(entity.PersonaId);
            if (persona != null)
            {
                return await clienteRepository.Update(entity);
            }
            throw new PichinchaException($"La persona con el Id: {entity.PersonaId} que desea actualizar no existe, por favor valide.");
        }
    }
}
