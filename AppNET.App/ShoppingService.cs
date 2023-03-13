using AppNET.Domain.Entities;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppNET.App
{
    public class ShoppingService
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly CashService cashService;
        private readonly ProductService productService;
        private readonly InvoiceService invoiceService;
        public ShoppingService() 
        {
            _productsRepository = IOCContainer.Resolve<IRepository<Product>>();
            cashService = IOCContainer.Resolve<CashService>();
            productService = IOCContainer.Resolve<ProductService>();
            invoiceService = IOCContainer.Resolve<InvoiceService>();
        }
        public void SellProduct(int id,string name, int stock, decimal sellPrice) //satılacak ürünün stoğu yerine adeti demek daha doğru ama product ın içinde piece olmadığı için stock dan ilerledim.
        {
            Product soldProduct = new Product()
            {
                Id = id,
                Name = name,
                Stock = stock,
                SellPrice = sellPrice,
              
            };
            if (StockControlForSale(id, stock))
            {
                var currentStock = _productsRepository.GetList().FirstOrDefault(p => p.Id == soldProduct.Id);
                currentStock.Stock -= soldProduct.Stock;
               
            }
            else
                throw new Exception("İşlem başarısız");
        }

        public void BuyProduct(int id, string name, int stock, decimal buyPrice)
        {
            Product buyProduct = new Product();
            Invoice outcomeInvoice = new Invoice();
            buyProduct = _productsRepository.GetList().FirstOrDefault(p => p.Id == Id);
            //if (buyProduct != null)
            //{
            //    productService.Update(int productId, Product buyProduct);
            //    //cashService.OutcomeInvoice(id, stock, buyPrice)
            //}
            //else
                //productService.Create(int id, string name, decimal price, int stock, int categoryId, decimal buyPrice, decimal sellPrice);

        }

        public bool StockControlForSale(int id, int sellAmount)
        {
            Product controlProduct = new Product();
           
            controlProduct=_productsRepository.GetList().FirstOrDefault(p=>p.Id == Id);
            if (sellAmount > controlProduct.Stock)
            {
                throw new Exception($"Stokta {controlProduct.Stock} kadar ürün vardır");
                return false;
            }
            else
                return true;
        }  
    }
}
