using Monitoria.Application.Registration.Interfaces;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.Registration.Apps
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        
        public CustomerAppService(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

        public void AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
        }

        public void AddCustomerAnimals(Customer customer)
        {
            _customerService.AddCustomerAnimals(customer);
        }

        public bool ExistingEntity(Customer customer)
        {
            return _customerService.ExistingEntity(customer);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _customerService.GetAllCustomer();
        }

        public IEnumerable<Customer> GetByCustomerName(string name)
        {
           return _customerService.GetByCustomerName(name);
        }

        public Customer GetCostomerById(Guid id)
        {
            return _customerService.GetCostomerById(id);
        }

        public Customer GetEntityEqualTo(Customer customer)
        {
            return _customerService.GetEntityEqualTo(customer);
        }

        public void RemoveCostomerById(Guid id)
        {
            _customerService.RemoveCostomerById(id);
        }

        public void RemoveCustomer(Customer customer)
        {
            _customerService.RemoveCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerService.UpdateCustomer(customer);
        }
    }
}
