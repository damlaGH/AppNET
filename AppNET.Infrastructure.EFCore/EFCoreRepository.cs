using AppNET.Domain.Entities;
using AppNET.Domain.Entities.Base;
using AppNET.Domain.Interfaces;

namespace AppNET.Infrastructure.EFCore
{
    public class EFCoreRepository<T>: IRepository<T> where T : BaseEntity
    {
        
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetList(Func<T, bool> expression = null)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}