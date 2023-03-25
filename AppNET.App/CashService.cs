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
        public class CashService: ICashService
         
        {
            private readonly IInvoiceService invoiceService;
           
            public CashService()
            {
                invoiceService = IOCContainer.Resolve<IInvoiceService>();
               

            }

            public decimal ShowBalance()
            {
            return 1000+(invoiceService.IncomeInvoice().Sum(i => i.TotalAmount) - invoiceService.OutcomeInvoice().Sum(e => e.TotalAmount));
            }

        }
}





