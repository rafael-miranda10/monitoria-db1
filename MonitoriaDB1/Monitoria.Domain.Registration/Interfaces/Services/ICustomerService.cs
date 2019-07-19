using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Interfaces.Services
{
    public interface ICustomerService 
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomer();
        IEnumerable<Customer> GetByCustomerName(string name);
        Customer GetCostomerById(Guid id);
        void RemoveCostomerById(Guid id);
        Customer GetEntityEqualTo(Customer customer);
        bool ExistingEntity(Customer customer);
    }
}
