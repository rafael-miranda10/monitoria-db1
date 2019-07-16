using Monitoria.Application.Registration.Interfaces;
using Monitoria.Application.Shared.Apps;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Services;
using System.Collections.Generic;

namespace Monitoria.Application.Registration.Apps
{
    public class CustomerAppService : AppServiceBase<Customer>, ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        
        public CustomerAppService(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }

        public IEnumerable<Customer> GetByCustomerName(string name)
        {
           return _customerService.GetByCustomerName(name);
        }
    }
}
