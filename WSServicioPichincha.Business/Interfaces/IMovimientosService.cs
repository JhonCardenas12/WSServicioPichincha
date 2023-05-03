using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Business.Interfaces
{
    public interface IMovimientosService
    {
        Task<IEnumerable<MovimientosDetalle>> GetAll();
        Task<Movimientos> GetById(int id);
        Task<Movimientos> Save(Movimientos entity);
        Task<Movimientos> Delete(int id);
        Task<Movimientos> Update(Movimientos entity);
    }
}
