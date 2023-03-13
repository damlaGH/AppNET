using AppNET.Domain.Entities;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
using AppNET.Infrastructure.IOToTXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public class ApplicationServiceSettings
    {
        public static void RegisterAllService()

        {
            // IOCContainer.Register<IRepository<Category>>(Metot); //TextFileRepository i parametre olarak alamadığımız için bir metot oluşturduk 
            IOCContainer.Register<IRepository<Category>>(() => new TextFileRepository<Category>());
            IOCContainer.Register<IRepository<Product>>(() => new TextFileRepository<Product>());
            IOCContainer.Register<IRepository<Invoice>>(() => new TextFileRepository<Invoice>());
            IOCContainer.Register<ICategoryService>(() => new CategoryService());
            IOCContainer.Register<IProductService>(() => new ProductService());
            IOCContainer.Register<IInvoiceService>(() => new InvoiceService());


            //  public static IRepository<Category> Metot()
            //{
            //    return new TextFileRepository<Category>();
            //}
        }
    }
}
