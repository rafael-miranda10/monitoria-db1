using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Enum;
using Monitoria.Domain.Shared.ValueObjects;

namespace Monitoria.Domain.Registration.Tests.Entities
{
    [TestClass]
    public class CustomerTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Animal _animal;
        private readonly Customer _customer;

        public CustomerTests()
        {
            _name = new Name("Djalma Jorge", "De Oliveira");
            _email = new Email("djalma.jorge@gmail.com");
            _document = new Document("09052751013", DocumentEnum.CPF);
            _address = new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "19033040");
            _animal = new Animal("Gerg", 2, SpeciesEnum.Canine, true);
            _customer = new Customer(_name, _document, _email, _address);
        }


        [TestMethod]
        public void ReturnErrorWhenTheNameAnimalIsTheSame()
        {
            _customer.AddAnimal(_animal);
            _customer.AddAnimal(_animal);
            Assert.IsTrue(_customer.Invalid);
        }
    }
}
