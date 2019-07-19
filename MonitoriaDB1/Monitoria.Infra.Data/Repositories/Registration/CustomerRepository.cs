using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.RepModels.Shared.Enum;
using Monitoria.Infra.RepoModels.PetCare.Models;
using Monitoria.Infra.RepoModels.Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Monitoria.Infra.Data.Repositories.Registration
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RegistrationContext _context;
        private readonly PetCareContext _contextPetCare;
        private readonly IMapper _mapper;

        public CustomerRepository(RegistrationContext context, IMapper mapper, PetCareContext contextPetCare) 
        {
            _context = context;
            _mapper = mapper;
            _contextPetCare = contextPetCare;
        }

        public void AddCustomer(Customer customer)
        {
            var customerRepModel = _mapper.Map<Customer, CustomerRepModel>(customer);
            _context.Customer.Add(customerRepModel);
            foreach (var item in customer.Animails)
            {
                //var animal = _mapper.Map<Animal, AnimalPetCareRepModel>(item);
                var animal = new AnimalPetCareRepModel(customer.Id, item.Name, item.Age,(SpeciesEnum)item.Specie);
                _contextPetCare.AnimalPetCare.Add(animal);
            }
            _context.SaveChanges();
            _contextPetCare.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            var customerRepModel = _mapper.Map<Customer, CustomerRepModel>(customer);
            _context.Set<CustomerRepModel>().Attach(customerRepModel);
            _context.Entry(customerRepModel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveCustomer(Customer customer)
        {
            var customerRepModel = _mapper.Map<Customer, CustomerRepModel>(customer);
            _context.Set<CustomerRepModel>().Remove(customerRepModel);
            RemoveAnimalPetCareById(customer.Id);
            _context.SaveChanges();
            _contextPetCare.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomer()
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
            var list = _mapper.Map<IEnumerable<CustomerRepModel>, IEnumerable<Customer>>(query);
            return list;
        }

        public Customer GetCostomerById(Guid id)
        {
            var result = _context.Customer.Find(id);
            var customer = _mapper.Map<CustomerRepModel, Customer>(result);
            return customer;
        }

        public void RemoveCostomerById(Guid id)
        {
            var result = _context.Customer.Find(id);
            if (result != null)
            {
                _context.Customer.Remove(result);
                RemoveAnimalPetCareById(id);
                _contextPetCare.SaveChanges();
                _context.SaveChanges();
            }
        }

        public Customer GetEntityEqualTo(Customer customer)
        {
            var query = (from entity in _context.Customer.AsEnumerable()
                         where entity.Equals(customer)
                         select entity).FirstOrDefault();
            var result = _mapper.Map<CustomerRepModel, Customer>(query);
            return result;
        }

        public bool ExistingEntity(Customer customer)
        {
            var existing = GetEntityEqualTo(customer);
            return existing != null;
        }

        private void RemoveAnimalPetCareById(Guid id)
        {
            var result = _contextPetCare.AnimalPetCare.Where(x => x.CustomerId.Equals(id)).FirstOrDefault();
            if (result != null)
                _contextPetCare.AnimalPetCare.Remove(result);
        }
    }
}
