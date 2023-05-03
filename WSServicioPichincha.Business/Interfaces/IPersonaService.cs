using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Business.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> GetAll();
        Task<Persona> GetById(int id);
        Task<Persona> Save(Persona entity);
        Task<Persona> Delete(int id);
        Task<Persona> Update(Persona entity);
    }
}
