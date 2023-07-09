using AppNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public interface IOrderService
    {

        void Create(int customerId, Customer customer, DateTime orderDate, DateTime shipDate, string shippingCompany, Invoice invoice);
    }
}


