using AppNET.App;
using AppNET.Domain.Entities;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public class CashService: ICashService
    {
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly InvoiceService invoiceService;
        public CashService()
        {
            invoiceService = IOCContainer.Resolve<InvoiceService>();
            _invoiceRepository = IOCContainer.Resolve<IRepository<Invoice>>();

        }
        //public IReadOnlyCollection<Invoice> FilterByDate(Func<Invoice, bool> expression = null)
        //{
        //    DateTime startDate = new DateTime();
        //    DateTime endDate = new DateTime();
        //    var invoices = _invoiceRepository.Where(invoice => invoice.Date >= startDate && invoice.Date <= endDate);
        //    return invoices;
        //}

      
        public decimal ShowBalance()
        {
            return invoiceService.IncomeInvoice().Sum(i => i.TotalAmount) - invoiceService.OutcomeInvoice().Sum(e => e.TotalAmount);
        }



      
    }
}





