using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Business.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IRepository<Persona> personaRepository;
        public PersonaService(IRepository<Persona> personaRepository)
        {
            this.personaRepository = personaRepository;
        }
        public async Task<Persona> Delete(int id)
        {
            return await personaRepository.Delete(id);
        }

        public async Task<IEnumerable<Persona>> GetAll()
        {
            return await personaRepository.GetAll();
        }

        public async Task<Persona> GetById(int id)
        {
            return await personaRepository.GetById(id);
        }

        public async Task<Persona> Save(Persona entity)
        {
            return await personaRepository.Save(entity);
        }

        public async Task<Persona> Update(Persona entity)
        {
            return await personaRepository.Update(entity);
        }
    }
}
