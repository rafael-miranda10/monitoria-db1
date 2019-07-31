using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Enum;
using Monitoria.Domain.Shared.ValueObjects;
using System;

namespace Monitoria.Domain.PetCare.Tests.Entities
{
    [TestClass]
    public class RowAnimalCareTests
    {
        private readonly Professional _professional;
        private readonly PetServices _petServicesConsult;
        private readonly PetServices _petServicesHairCut;
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Animal _animal;


        public RowAnimalCareTests()
        {
            _name = new Name("Djalma Jorge", "De Oliveira");
            _email = new Email("djalma.jorge@gmail.com");
            _document = new Document("09052751013", DocumentEnum.CPF);
            _address = new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "19033040");
            _professional = new Professional(_name, _document, _email, _address, ProfessionalEnum.Veterinary);
            _petServicesConsult = new PetServices("Consulta Veterinária", CategoryEnum.VeterinaryProcedure, "Examinar o animal para o diagnóstico inicial", (decimal)70.5, true);
            _petServicesHairCut = new PetServices("Banho e Tosa", CategoryEnum.AnimalEsthetics, "Examinar o animal em busca de pequenos ferimentos", (decimal)35.0, true);
            _animal = new Animal("Greg", 2, SpeciesEnum.Canine, true);

        }

        [TestMethod]
        public void ReturnErrorWhenProfessionalServicesAnimalHasError()
        {
            var _servicesAnimal = new ProfessionalServicesAnimal(_professional, _petServicesConsult, "O animal ficará em observação");
            _servicesAnimal.FinalizeThePetService(DateTime.Now.AddDays(-2));

            var rowAnimalCare = new RowAnimalCare(_animal.Id);
            rowAnimalCare.AddProfessionalService(_servicesAnimal);
            Assert.IsTrue(rowAnimalCare.Invalid);
        }

        [TestMethod]
        public void ReturnSuccessWhenProfessionalServicesAnimalIsOk()
        {
            var _SAConsult = new ProfessionalServicesAnimal(_professional, _petServicesConsult, "O animal ficará em observação");
            _SAConsult.FinalizeThePetService(DateTime.Now.AddDays(2));

            var _SAHairCut = new ProfessionalServicesAnimal(_professional, _petServicesHairCut, "O animal apresenta pequenos ferimentos sugerindo alergia");
            _SAConsult.FinalizeThePetService(DateTime.Now);

            var rowAnimalCare = new RowAnimalCare(_animal.Id);
            rowAnimalCare.AddProfessionalService(_SAConsult);
            rowAnimalCare.AddProfessionalService(_SAHairCut);
            Assert.IsTrue(rowAnimalCare.Valid);
        }

        [TestMethod]
        public void ReturnSuccessWhenProfessionalServiceValueTotalIsEqualsThe10550()
        {
            var _SAConsult = new ProfessionalServicesAnimal(_professional, _petServicesConsult, "O animal ficará em observação");
            _SAConsult.FinalizeThePetService(DateTime.Now.AddDays(2));

            var _SAHairCut = new ProfessionalServicesAnimal(_professional, _petServicesHairCut, "O animal apresenta pequenos ferimentos sugerindo alergia");
            _SAConsult.FinalizeThePetService(DateTime.Now);

            var rowAnimalCare = new RowAnimalCare(_animal.Id);
            rowAnimalCare.AddProfessionalService(_SAConsult);
            rowAnimalCare.AddProfessionalService(_SAHairCut);

            rowAnimalCare.CalculatePriceTotal();

            if (rowAnimalCare.ValueTotal == (decimal)105.50)
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }
    }
}
