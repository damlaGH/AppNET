using AppNET.Domain.Entities;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
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

        public InvoiceService()
        {
            _invoiceRepository = IOCContainer.Resolve<IRepository<Invoice>>();
        }
       
        public void Create(int invoiceNumber, decimal totalAmount, string explanation, TypeOfProcess process, DateTime dateTime)
        {
            if (invoiceNumber == null)
                throw new Exception("Fatura numarası boş olamaz");
            
            Invoice invoice = new Invoice()
            {
                InvoiceNumber = invoiceNumber,
                TotalAmount = totalAmount,
                Explanation = explanation,
                typeOfProcess = process,
                dateTime = DateTime.Now
               
            };
            _invoiceRepository.Add(invoice);
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

