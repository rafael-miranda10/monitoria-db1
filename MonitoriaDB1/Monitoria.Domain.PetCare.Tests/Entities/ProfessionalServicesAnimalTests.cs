using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.Shared.Enum;
using Monitoria.Domain.Shared.ValueObjects;
using System;

namespace Monitoria.Domain.PetCare.Tests.Entities
{
    [TestClass]
    public class ProfessionalServicesAnimalTests
    {
        private readonly Professional _professional;
        private readonly PetServices _petServices;
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;


        public ProfessionalServicesAnimalTests()
        {
            _name = new Name("Djalma Jorge", "De Oliveira");
            _email = new Email("djalma.jorge@gmail.com");
            _document = new Document("09052751013", DocumentEnum.CPF);
            _address = new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "19033040");
            _professional = new Professional(_name, _document, _email, _address, ProfessionalEnum.Veterinary);
            _petServices = new PetServices("Consulta Veterinária", CategoryEnum.VeterinaryProcedure, "Examinar o aniaml para o diagnóstico inicial", (decimal)70.5, true);

        }

        [TestMethod]
        public void ReturnErrorWhenEndDateIsLowerThanStartDate()
        {
            var serviceToAnimal = new ProfessionalServicesAnimal(_professional, _petServices, "O animal ficará em observação");
            serviceToAnimal.FinalizeThePetService(DateTime.Now.AddDays(-2));
            Assert.IsTrue(serviceToAnimal.Invalid);
        }

        [TestMethod]
        public void ReturnSuccessWhenEndDateIsGreaterThanStartDate()
        {
            var serviceToAnimal = new ProfessionalServicesAnimal(_professional, _petServices, "O animal ficará em observação");
            serviceToAnimal.FinalizeThePetService(DateTime.Now.AddDays(2));
            Assert.IsTrue(serviceToAnimal.Valid);
        }

        [TestMethod]
        public void ReturnSuccessWhenEndDateAreEqualsToStartDate()
        {
            var serviceToAnimal = new ProfessionalServicesAnimal(_professional, _petServices, "O animal ficará em observação");
            serviceToAnimal.FinalizeThePetService(serviceToAnimal.StartDate);
            Assert.IsTrue(serviceToAnimal.Valid);
        }
    }
}
