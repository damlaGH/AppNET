using AppNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public interface ICustomerService
    {

        void Create(int customerId, string cardHolderName, byte creditCardName, string cardName, DateTime expiredDate, byte securityNumber);
    }
}
