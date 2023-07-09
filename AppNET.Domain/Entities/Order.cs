using AppNET.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Entities
{
    public class Order:BaseEntity
    {
        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }

        public DateTime OrderDate {get; set; }

        public DateTime ShipDate { get; set; }

        public string  ShippingCompany  { get; set; }

        public Invoice Invoice { get; set; }

        public ICollection<OrderDetails> OrderDetails  { get; set; }
    }
}
