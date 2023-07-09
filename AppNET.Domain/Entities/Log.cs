using AppNET.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Entities
{
    public sealed class Log:BaseEntity
    {
        public int OrderId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedUserId { get; set; }
    }
}
