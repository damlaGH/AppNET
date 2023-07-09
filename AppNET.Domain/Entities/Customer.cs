using AppNET.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Entities
{
    public class Customer:ContactEntity
    {
        public int? CustomerId { get; set; }
        public string CardHolderName { get; set; }
        public byte CreditCardNumber { get; set; }

        public string CardName { get; set; }

        public DateTime ExpiredDate { get; set; }

        public byte SecurityNumber { get; set; }

        public List<Order> Order { get; set; }

    }
}
