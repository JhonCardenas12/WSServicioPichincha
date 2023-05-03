using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Business.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task<Cliente> Save(Cliente entity);
        Task<Cliente> Delete(int id);
        Task<Cliente> Update(Cliente entity);
    }
}
