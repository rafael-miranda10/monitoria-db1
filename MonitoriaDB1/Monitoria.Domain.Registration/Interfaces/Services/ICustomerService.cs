using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Interfaces.Services;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Interfaces.Services
{
    public interface ICustomerService : IServiceBase<Customer>
    {
        IEnumerable<Customer> GetByCustomerName(string name);
    }
}
