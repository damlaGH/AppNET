using AppNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public interface IProductService
    {
        void Create(int id, string name, decimal price, int stock);
        bool Delete(int id);
        IReadOnlyCollection<Product> GetAll();
        Product Update(int id, string newProductName, decimal newPrice, int newStock);

    }
}
