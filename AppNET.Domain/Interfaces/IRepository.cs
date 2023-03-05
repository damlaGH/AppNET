using AppNET.Domain.Entities;
using AppNET.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Interfaces
{
    public interface IRepository<T>where T:BaseEntity   //interface adları I ile başlar, metodları gövdesiz ve access modifiersız olur
    {
        T Add(T entity);
        bool Remove(int id);

        T GetById(int id);

        ICollection<T> GetList(Func<T, bool> expression = null);  //burda linq query si kullanabiliriz ya da T tipinde değerle çalışmış oluruz.

        T Update(int id, T entity);
    }
}
