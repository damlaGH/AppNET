using AppNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public interface IInvoiceService
    {
        void Create(int InvoiceNumber ,decimal TotalAmount, string Explanation, TypeOfProcess typeOfProcess, DateTime dateTime);
        bool Delete(int InvoiceNumber);
        IReadOnlyCollection<Invoice> GetAll();
        Invoice Update(int InvoiceNumber, Invoice newInvoice);

        IReadOnlyCollection<Invoice> IncomeInvoice(Func<Invoice, bool> expression = null);
        IReadOnlyCollection<Invoice> OutcomeInvoice(Func<Invoice, bool> expression = null);


    }
}


