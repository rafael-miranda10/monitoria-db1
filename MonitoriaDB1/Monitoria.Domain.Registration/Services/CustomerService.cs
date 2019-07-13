using System.Collections.Generic;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Domain.Registration.Interfaces.Services;
using Monitoria.Domain.Shared.Services;

namespace Monitoria.Domain.Registration.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetByCustomerName(string name)
        {
            return _customerRepository.GetByCustomerName(name);
        }
    }
}
