using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Infra.Data.Contexts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Monitoria.Infra.Data.Repositories.Registration;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Enum;
using Monitoria.Domain.Shared.ValueObjects;

namespace Monitoria.Repository.Registration.Tests.Repository
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Animal _animal;
        private readonly Customer _customer;
        private readonly List<Animal> _list;
        private RegistrationContext _context;

        public CustomerRepositoryTests()
        {
            _name = new Name("Djalma Jorge", "De Oliveira");
            _email = new Email("djalma.jorge@gmail.com");
            _document = new Document("09052751013", DocumentEnum.CPF);
            _address = new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "19033040");
            _list = new List<Animal>();
            _animal = new Animal("Gerg", 2, SpeciesEnum.Canine, true);
            _customer = new Customer(_name, _document, _email, _address);
            _customer.AddAnimal(_animal);
            _animal = new Animal("Cindy", 2, SpeciesEnum.Feline, true);
            _customer.AddAnimal(_animal);
            var options = new DbContextOptions<RegistrationContext>();
            _context = new RegistrationContext(options);

        }

        [TestMethod]
        public void ReturnSuccessWhenTheCustomerIsOk()
        {
            //var repository = new CustomerRepository(_context);
            //if(_customer.Valid)
            //   repository.Add(_customer);

            //Assert.IsTrue(_customer.Valid);
        }

    }
}
