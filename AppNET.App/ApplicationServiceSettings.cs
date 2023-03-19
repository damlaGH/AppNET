using AppNET.Domain.Entities;
using AppNET.Domain.Entities.LogAggregate;
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

            //public void ConfigureServices(IServiceCollection services)
            //{ 
            //  services.Add ... Register Services
            //}

            //services.AddTransient<>()

           

            //singleton service:uygulama boyunca yalnızca 1 nesne oluşturup hep onu kullanır. 
            //scoped service: response oluşana kadar aynı nesneyi kullanır. (bir request geldiğinde nesne oluşur sonlanana kadar aynısı yeni requestte yeni nesne)
            //transient service:nesneye her erişmek istediğimizde her seferinde yeniden oluşturulur. bu container ve method injection ile 
            
            // IOCContainer.Register<IRepository<Category>>(Metot); //TextFileRepository i parametre olarak alamadığımız için bir metot oluşturduk 
            IOCContainer.Register<IRepository<Category>>(() => new TextFileRepository<Category>());
            IOCContainer.Register<IRepository<Product>>(() => new TextFileRepository<Product>());
            IOCContainer.Register<IRepository<Invoice>>(() => new TextFileRepository<Invoice>());
            IOCContainer.Register<IRepository<Log>>(() => new TextFileRepository<Log>());
            
            IOCContainer.Register<ICategoryService>(() => new CategoryService());
            IOCContainer.Register<IProductService>(() => new ProductService());
            IOCContainer.Register<IInvoiceService>(() => new InvoiceService());
            IOCContainer.Register<ICashService>(() => new CashService());
            IOCContainer.Register<ILogService>(() => new LogService());
            IOCContainer.Register<CashService>(() => new CashService());
            IOCContainer.Register<InvoiceService>(() => new InvoiceService());
            IOCContainer.Register<ShoppingService>(() => new ShoppingService());
            IOCContainer.Register<LogService>(() => new LogService());
            IOCContainer.Register<CategoryService>(() => new CategoryService());
            IOCContainer.Register<ProductService>(() => new ProductService());
            //  public static IRepository<Category> Metot()
            //{
            //    return new TextFileRepository<Category>();
            //}
        }
    }
}
