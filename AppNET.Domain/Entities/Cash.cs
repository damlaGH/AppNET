using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Entities
{
    public class Cash
    {
        public decimal Balance { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
