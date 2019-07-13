using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Interfaces.Repositories;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        IEnumerable<Customer> GetByCustomerName(string name);
    }
}
