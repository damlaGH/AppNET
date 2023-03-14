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

        public IReadOnlyCollection<Invoice> IncomeInvoice(Func<Invoice, bool> expression = null)
        {
            return _invoiceRepository.GetList().Where(x => x.typeOfProcess == TypeOfProcess.Income).ToList().AsReadOnly();
        }
        public IReadOnlyCollection<Invoice> OutcomeInvoice(Func<Invoice, bool> expression = null)
        {
            return _invoiceRepository.GetList().Where(x => x.typeOfProcess == TypeOfProcess.Outcome).ToList().AsReadOnly();
        }
        public decimal Balance()
        {
            return IncomeInvoice().Sum(i => i.TotalAmount) - OutcomeInvoice().Sum(e => e.TotalAmount);
        }

          

    }
}





