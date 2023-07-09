using AppNET.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Entities
{
    public sealed class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        //public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }   //Navigation property

        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }   //Navigation property

        public  DateTime UpdatedDate { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
