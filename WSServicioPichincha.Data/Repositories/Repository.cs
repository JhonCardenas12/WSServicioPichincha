using Microsoft.EntityFrameworkCore;
using WSServicioPichincha.Data.Context;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Exceptions;
using System.Linq;
using System.Net.NetworkInformation;

namespace WSServicioPichincha.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PichinchaContext pichinchaContext;
        public Repository(PichinchaContext pichinchaContext)
        {
            this.pichinchaContext = pichinchaContext;
        }
        protected DbSet<T> EntitySet
        {
            get
            {
                return pichinchaContext.Set<T>();
            }
        }
        public async Task<T> Delete(int id)
        {
            using var transaction = pichinchaContext.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("Delete");
                T entity = await EntitySet.FindAsync(id);
                EntitySet.Remove(entity);
                pichinchaContext.SaveChanges();
                transaction.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                transaction.RollbackToSavepoint("Update");
                throw new PichinchaException($"Se presento un error al intertar eliminar la información, Message: {ex.Message}");
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await EntitySet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new PichinchaException($"Se presento un error al intertar obtener toda la información, Message: {ex.Message}");
            }
        }

        public async Task<T> GetById(int id)
        {
            using var transaction = pichinchaContext.Database.BeginTransaction();
            try
            {
                return await EntitySet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new PichinchaException($"Se presento un error al intertar obtener la información por Id, Message: {ex.Message}");
            }
        }

        public async Task<T> Save(T entity)
        {
            using var transaction = pichinchaContext.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("Save");
                EntitySet.Add(entity);
                await pichinchaContext.SaveChangesAsync();
                transaction.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                transaction.RollbackToSavepoint("Save");
                throw new PichinchaException($"Se presento un error al intertar guardar la información, Message: {ex.Message}");
            }
        }

        public async Task<T> Update(T entity)
        {
            using var transaction = pichinchaContext.Database.BeginTransaction();
            try
            {
                transaction.CreateSavepoint("Update");
                pichinchaContext.Entry(entity).State = EntityState.Modified;
                await pichinchaContext.SaveChangesAsync();
                transaction.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                transaction.RollbackToSavepoint("Update");
                throw new PichinchaException($"Se presento un error al intertar actualizar la información, Message: {ex.Message}");
            }
        }
    }
}
