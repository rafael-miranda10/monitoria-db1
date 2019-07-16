using Monitoria.Application.Shared.Interfaces;
using Monitoria.Domain.Registration.Entities;
using System.Collections.Generic;

namespace Monitoria.Application.Registration.Interfaces
{
    public interface ICustomerAppService : IAppServiceBase<Customer>
    {
        IEnumerable<Customer> GetByCustomerName(string name);
    }
}
