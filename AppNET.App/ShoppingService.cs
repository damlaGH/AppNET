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
                soldProduct.Stock -= soldProduct.Stock;
                soldProduct.UpdatedDate = DateTime.Now;
                // int invoiceNumber = Convert.ToInt32($"{soldProduct.Id}  EŞSİZ FATURA NUMARASI ÜRETEN BİŞEY YAZMAN LAZIM!
                invoiceService.Create(1,
                    stock * sellPrice,
                    $"{soldProduct.Id} id'li üründen {soldProduct.Stock} adet satıldı. Toplam tutar: {stock * sellPrice}",
                    TypeOfProcess.Outcome,
                    DateTime.Now);                       
            }
            else
                throw new Exception("İşlem başarısız");
        }

        public void BuyProduct(int id, string name, int stock, decimal buyPrice)
        {
            
            Product buyProduct = new Product()
            {
                Id = id,
                Name = name,
                Stock = stock,           
                BuyPrice = buyPrice,

            };

            buyProduct = _productsRepository.GetList().FirstOrDefault(p => p.Id == id);
            if (buyProduct != null)
            {
                if (cashService.ShowBalance() >= stock * buyPrice)
                {
                    buyProduct.Stock += buyProduct.Stock;
                    buyProduct.UpdatedDate = DateTime.Now;
                    invoiceService.Create(1,
                        stock * buyPrice,
                        $"{buyProduct.Id} id'li üründen {buyProduct.Stock} adet alındı. Toplam tutar: {stock * buyPrice}",
                        TypeOfProcess.Income,
                        DateTime.Now);
                }
                else
                    throw new Exception("Bakiye yetersiz!");
            }

            else
            {
                throw new Exception("Yeni ürün kaydı yapınız:");
                productService.Create(id, name,stock, 1, buyPrice, 1); // categoryId ve sellPrice i almadığım için 1 verdim
              

            }
        }

        public bool StockControlForSale(int id, int sellAmount)
        {
            Product controlProduct = new Product();
           
            controlProduct=_productsRepository.GetList().FirstOrDefault(p=>p.Id == id);
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
