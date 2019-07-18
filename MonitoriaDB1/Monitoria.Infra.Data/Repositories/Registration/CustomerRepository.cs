using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.RepoModels.Registration.Models;
using System.Collections.Generic;
using System.Linq;


namespace Monitoria.Infra.Data.Repositories.Registration
{
    public class CustomerRepository : RepositoryBase<Customer, RegistrationContext>, ICustomerRepository
    {
        private readonly RegistrationContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(RegistrationContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public override void Add(Customer customer)
        {
            var customerRepModel = _mapper.Map<Customer,CustomerRepModel>(customer);
            _context.Customer.Add(customerRepModel);
            _context.SaveChanges();
        }
        public override void Update(Customer customer)
        {
            var customerRepModel = _mapper.Map<Customer,CustomerRepModel>(customer);
            _context.Set<CustomerRepModel>().Attach(customerRepModel);
            _context.Entry(customerRepModel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public override void Remove(Customer customer)
        {
            var customerRepModel = _mapper.Map<Customer, CustomerRepModel>(customer);
            _context.Set<CustomerRepModel>().Remove(customerRepModel);
            _context.SaveChanges();
        }

        public override IEnumerable<Customer> GetAll()
        {
            var query = _context.Customer
                         .Include(x => x.Animails)
                         .AsEnumerable();
            var list = _mapper.Map<IEnumerable<CustomerRepModel>, IEnumerable<Customer>>(query);
            return list;
        }

        public IEnumerable<Customer> GetByCustomerName(string name)
        {
            var query = _context.Customer
                          .Include(x => x.Animails)
                          .Include(x => x.Name)
                          .Include(x => x.Address)
                          .Include(x => x.Email)
                          .Include(x => x.Document)
                          .Where(x => x.Name.FirstName == name)
                          .AsEnumerable();
           var listCustomers = _mapper.Map<IEnumerable<CustomerRepModel>,IEnumerable<Customer>>(query);
           return listCustomers;
        }
    }
}
