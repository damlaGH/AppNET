using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Entities.Base
{
    public class ContactEntity:BaseEntity
    {
        public string Name { get; set; }
        public string? SurName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
