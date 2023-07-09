using AppNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public interface ICustomerAdressService
    {
        void Create(string address, string city, string country, int addressOfCustomerId, Customer customer);
    }
}
