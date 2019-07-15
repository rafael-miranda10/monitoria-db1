using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Infra.Data.Repositories.Registration
{
    public class CustomerRepository : RepositoryBase<Customer, RegistrationContext>, ICustomerRepository
    {
        private readonly RegistrationContext _context;

        public CustomerRepository(RegistrationContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetByCustomerName(string name)
        {
            return _context.Set<Customer>().Where(x => x.Name.Equals(name)).AsEnumerable();
        }
    }
}
