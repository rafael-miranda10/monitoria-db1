using System;
using System.Collections.Generic;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Domain.Registration.Interfaces.Services;

namespace Monitoria.Domain.Registration.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) 
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public bool ExistingEntity(Customer customer)
        {
          return _customerRepository.ExistingEntity(customer);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _customerRepository.GetAllCustomer();
        }

        public IEnumerable<Customer> GetByCustomerName(string name)
        {
            return _customerRepository.GetByCustomerName(name);
        }

        public Customer GetCostomerById(Guid id)
        {
            return _customerRepository.GetCostomerById(id);
        }

        public Customer GetEntityEqualTo(Customer customer)
        {
            return _customerRepository.GetEntityEqualTo(customer);
        }

        public void RemoveCostomerById(Guid id)
        {
            _customerRepository.RemoveCostomerById(id);
        }

        public void RemoveCustomer(Customer customer)
        {
            _customerRepository.RemoveCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }
    }
}
