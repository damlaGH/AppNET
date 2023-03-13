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
        void Create(int id, string name, decimal price, int stock, int categoryId,decimal buyPrice, decimal sellPrice);      
        bool Delete(int productId);
        IReadOnlyCollection<Product> GetAll();
        Product Update(int productId, Product newProduct);
    }
}
