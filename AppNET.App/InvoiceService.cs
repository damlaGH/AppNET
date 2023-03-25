using AppNET.Domain.Entities;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
using AppNET.Infrastructure.LogToTxt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppNET.App
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<Invoice> _invoiceRepository;
        private ILogger logger;

        public InvoiceService()
        {
            _invoiceRepository = IOCContainer.Resolve<IRepository<Invoice>>();
             logger= IOCContainer.Resolve<ILogger>();
        }
       
        public void Create(int invoiceNumber, decimal totalAmount, string explanation, TypeOfProcess process, DateTime dateTime)
        {
            if (invoiceNumber == null)
               logger.Error("Fatura numarası boş olamaz");
            
            Invoice invoice = new Invoice()
            {
                InvoiceNumber = invoiceNumber,
                TotalAmount = totalAmount,
                Explanation = explanation,
                typeOfProcess = process,
                dateTime = DateTime.Now
               
            };
            _invoiceRepository.Add(invoice);
            logger.Info("Yeni fatura oluşturuldu.");
        }
       


        public bool Delete(int InvoiceNumber)
        {
            return _invoiceRepository.Remove(InvoiceNumber);
        }

        public IReadOnlyCollection<Invoice> GetAll()
        {
            return _invoiceRepository.GetList().ToList().AsReadOnly();
        }

        public Invoice Update(int InvoiceNumber, Invoice newInvoice)
        {
            if (InvoiceNumber != newInvoice.Id)
                throw new ArgumentException("Invoice number değerleri eşleşmiyor");
            Invoice oldInvoice = _invoiceRepository.GetById(InvoiceNumber);
            if (oldInvoice == null)
                throw new Exception("Güncellenmek istenen fatura bulunamadı.");
            return _invoiceRepository.Update(InvoiceNumber, newInvoice);
        }
        public IReadOnlyCollection<Invoice> IncomeInvoice(Func<Invoice, bool> expression = null)
        {
            return _invoiceRepository.GetList().Where(x => x.typeOfProcess == TypeOfProcess.Income).ToList().AsReadOnly();
        }
        public IReadOnlyCollection<Invoice> OutcomeInvoice(Func<Invoice, bool> expression = null)
        {
            return _invoiceRepository.GetList().Where(x => x.typeOfProcess == TypeOfProcess.Outcome).ToList().AsReadOnly();
        }

    }
}

