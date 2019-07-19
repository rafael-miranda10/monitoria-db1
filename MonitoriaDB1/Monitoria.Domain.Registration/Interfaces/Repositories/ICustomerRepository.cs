using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Interfaces.Repositories
{
    public interface ICustomerRepository 
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> GetByCustomerName(string name);
        Customer GetById(Guid id);
        void RemoveById(Guid id);
        Customer GetEntityEqualTo(Customer customer);
        bool ExistingEntity(Customer customer);

    }
}
