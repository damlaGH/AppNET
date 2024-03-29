﻿using AppNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public interface IProductService
    {
        void Create(int id, string name,int stock, int categoryId,decimal buyPrice, decimal sellPrice, int supplierId);      
        bool Delete(int productId);
        bool DeleteProductsByCategory(int categoryId);
        IReadOnlyCollection<Product> GetAll();
        Product Update(int productId, Product newProduct);
    }
}
