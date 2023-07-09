using AppNET.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Entities
{
    public sealed class Invoice: BaseEntity
    {
        public int InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string Explanation { get; set; }
        public TypeOfProcess  typeOfProcess  { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;

        public Order Order { get; set; }

    }
}
