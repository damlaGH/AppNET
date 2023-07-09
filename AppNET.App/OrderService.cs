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
    public class OrderService:IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService()
        {
            _orderRepository = IOCContainer.Resolve<IRepository<Order>>();
        }
        public void Create(int customerId, Customer customer, DateTime orderDate, DateTime shipDate, string shippingCompany, Invoice invoice)
        {
            Order order = new Order()
            {
            CustomerId = customerId,
            Customer = customer,
            OrderDate = orderDate,
            ShipDate = shipDate,
            ShippingCompany = shippingCompany,
            Invoice = invoice
            };

            _orderRepository.Add(order);
        }
    }
}



