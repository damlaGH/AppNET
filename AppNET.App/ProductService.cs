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

        private readonly IRepository<Product> _productsRepository;
        public ProductService()
        {
            _productsRepository = IOCContainer.Resolve<IRepository<Product>>();  //product repository sine IOCContainerdaki resolve metodu ile kaydettiğimiz her şeyi yüklemiş olduk.
        }
        public void Create(int id, string name, decimal price, int stock, int categoryId, decimal buyPrice, decimal sellPrice)
        {
            if (id == null)
                throw new ArgumentException("Id değeri boş olamaz");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Kategori adı boş olamaz");
            Product product = new Product()
            {
                Id = id,
                Name = name,
                Price = price,
                Stock = stock,
                CategoryId = categoryId,
                BuyPrice=buyPrice,
                SellPrice=sellPrice,
                CreatedDate = DateTime.Now
                //UpdatedDate = DateTime.Now;
            };
               _productsRepository.Add(product);

        }

        public bool Delete(int productId)
        {
           return _productsRepository.Remove(productId);
        }
        
        public IReadOnlyCollection<Product> GetAll()
        {
            return _productsRepository.GetList().ToList().AsReadOnly();
        }

        public Product Update(int productId, Product newProduct)
        {
        if (productId != newProduct.Id)
            throw new ArgumentException("Product Id değerleri eşleşmiyor.");

        Product oldProduct = _productsRepository.GetById(productId);
        if (oldProduct==null)
            throw new Exception("Güncellenmek istenen ürün bulunamadı.");
        newProduct.UpdatedDate = DateTime.Now;
        return _productsRepository.Update(productId, newProduct);
        }
    }
}

