using AppNET.App;
using AppNET.Domain.Entities;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public class ProductService : IProductService
    {

        private readonly IRepository<Product> p_repository;
        public ProductService()
        {
            p_repository = IOCContainer.Resolve<IRepository<Product>>();  //product _repository sine IOCContainerdaki resolve metodu ile kaydettiğimiz her şeyi yüklemiş olduk.
        }
        public void Create(int id, string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Ürün adı boş olamaz.");
            if (price <= 0)
                throw new ArgumentOutOfRangeException("Ürün fiyatı 0 dan büyük olmalı.");
            Product product = new Product();
            product.Id = id;
            product.Name = name;
            product.Price = price;
            product.Stock = stock;
            product.CreatedDate= DateTime.Now;
            product.UpdatedDate = DateTime.Now;
            p_repository.Add(product);

        }

        public bool Delete(int id)
        {
            return p_repository.Remove(id);
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return p_repository.GetList().ToList().AsReadOnly();
        }

        public Product Update(int id, string newProductName,decimal newPrice, int newStock)
        {
            if (string.IsNullOrWhiteSpace(newProductName))
                throw new ArgumentNullException("Ürün adı boş olamaz.");
            if (newStock < 0)
                throw new ArgumentOutOfRangeException("Stok 0'dan küçük olamaz.");
            if (newPrice<= 0)
                throw new ArgumentOutOfRangeException("Fiyat 0'dan küçük veya eşit olamaz.");
            var product = new Product();
            product.Id = id;
            product.Name = newProductName;
            product.Price = newPrice;
            product.Stock = newStock;
            return p_repository.Update(id, product);
        }
    }
}

