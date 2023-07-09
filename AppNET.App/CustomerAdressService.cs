using AppNET.Domain.Entities;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public class CustomerAdressService : ICustomerAdressService
    {
        private readonly IRepository<CustomerAddress> _customerAddressRepository;

        public CustomerAdressService()
        { 
         _customerAddressRepository=IOCContainer.Resolve<IRepository<CustomerAddress>>();
        }


        public void Create(string address, string city, string country, int addressOfCustomerId, Customer customer)
        {
            CustomerAddress customerAddress = new CustomerAddress()
            {
                Address = address,
                City = city,
                Country = country,
                AddressOfCustomerId = addressOfCustomerId,
                Customer = customer
            };


            _customerAddressRepository.Add(customerAddress);

        }
    }
    
}


