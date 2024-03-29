﻿using AppNET.Domain.Entities;
using AppNET.Infrastructure.EFCore;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;

using AppNET.Infrastructure.IOToTXT;
using AppNET.Infrastructure.LogToTxt;
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
            IOCContainer.Register<IRepository<Category>>(() => new EFCoreRepository<Category>());
            IOCContainer.Register<IRepository<Product>>(() => new EFCoreRepository<Product>());
            IOCContainer.Register<IRepository<Invoice>>(() => new EFCoreRepository<Invoice>());
            IOCContainer.Register<IRepository<Customer>>(() => new EFCoreRepository<Customer>());
            IOCContainer.Register<IRepository<Cash>>(() => new EFCoreRepository<Cash>());
            IOCContainer.Register<IRepository<CustomerAddress>>(() => new EFCoreRepository<CustomerAddress>());
            IOCContainer.Register<IRepository<Log>>(() => new EFCoreRepository<Log>());
            IOCContainer.Register<IRepository<Order>>(() => new EFCoreRepository<Order>());
            IOCContainer.Register<IRepository<OrderDetails>>(() => new EFCoreRepository<OrderDetails>());
            IOCContainer.Register<IRepository<Shipper>>(() => new EFCoreRepository<Shipper>());
            IOCContainer.Register<IRepository<Supplier>>(() => new EFCoreRepository<Supplier>());
           

            IOCContainer.Register<ILogger>(()=> new Logger());
            IOCContainer.Register<ICategoryService>(() => new CategoryService());
            IOCContainer.Register<IProductService>(() => new ProductService());
            IOCContainer.Register<IInvoiceService>(() => new InvoiceService());
            IOCContainer.Register<ICashService>(() => new CashService());
            IOCContainer.Register<IShoppingService>(() => new ShoppingService());
            IOCContainer.Register<ICustomerService>(() => new CustomerService());
            IOCContainer.Register<ICustomerAdressService>(() => new CustomerAdressService());
            IOCContainer.Register<IOrderService>(() => new OrderService());

            //  public static IRepository<Category> Metot()
            //{
            //    return new TextFileRepository<Category>();
            //}
        }
    }
}
