using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Business.Interfaces
{
    public interface ICuentaService
    {
        Task<IEnumerable<Cuenta>> GetAll();
        Task<Cuenta> GetById(int id);
        Task<Cuenta> Save(Cuenta entity);
        Task<Cuenta> Delete(int id);
        Task<Cuenta> Update(Cuenta entity);
    }
}
