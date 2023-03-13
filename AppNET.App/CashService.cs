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
    public class CashService
    {
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly InvoiceService invoiceService;
        public CashService()
        {
            invoiceService = IOCContainer.Resolve<InvoiceService>();
            _invoiceRepository = IOCContainer.Resolve<IRepository<Invoice>>();
        }

        public void SaveInvoiceToCash(Invoice invoice)
        {
            Cash cash = new Cash();
            decimal totalAmount = invoice.TotalAmount;

            if (invoice.typeOfProcess==TypeOfProcess.Income)
                cash.Balance += invoice.TotalAmount;
            else
                cash.Balance -= invoice.TotalAmount;
        }

        public List<Invoice> AddInvoiceToCashList(Invoice invoice)
        {
            Cash cash = new Cash();
            List<Invoice> listOfInvoice = new List<Invoice>();

            listOfInvoice.Add(invoice);

            return cash.Invoices = listOfInvoice;
        }

    }
}





