using AppNET.Domain.Entities;
using AppNET.Domain.Entities.Base;
using AppNET.Domain.Interfaces;
using System.Collections.Generic;

namespace AppNET.Infrastructure.EFCore
{
    public class EFCoreRepository<T>: IRepository<T> where T : BaseEntity
    {  

        AppNETdbContext context=new AppNETdbContext();
        
        public T Add(T entity)
        {
            context.Add(entity);

            return entity;
        }


        public T GetById(int id)
        {
           return context.Set<T>().Find(id);
        
        }

        public ICollection<T> GetList(Func<T, bool> expression = null) //expression funct. dır
        {

            if (expression == null)
                return context.Set<T>().ToList();
            else
                return context.Set<T>().Where<T>(expression).ToList();
        }
        public bool Remove(int id)
        {
            context.Remove(id);
            return false;
        }

        public bool Remove(T entity)
        {
            context.Remove<T>(entity);
            context.SaveChanges();
            return true;
        }

        public T Update(int id, T entity)
        {
            if (id != entity.Id)
                throw new ArgumentException("ID değerleri uyuşmuyor");

            context.Update(entity);
            return entity;
                    
        }
    }
}