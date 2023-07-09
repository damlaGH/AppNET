using AppNET.Domain.Entities;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService()
        {
            _customerRepository = IOCContainer.Resolve<IRepository<Customer>>();
        }

        public void Create(int customerId,string cardHolderName, byte creditCardNumber, string cardName, DateTime expiredDate, byte securityNumber)
        {
            Customer customer = new Customer()
            {
                CustomerId = customerId,
                CardHolderName = cardHolderName,
                CreditCardNumber = creditCardNumber,
                CardName = cardName,
                ExpiredDate = expiredDate,
                SecurityNumber = securityNumber,
                
            };
            _customerRepository.Add(customer);
        }
    }

}





