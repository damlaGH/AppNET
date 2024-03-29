﻿using AppNET.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Entities
{
    public class CustomerAddress:BaseEntity
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int AddressOfCustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
