﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.PetCare.Services;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Enum;
using Monitoria.Domain.Shared.ValueObjects;
using Monitoria.Infra.CrossCutting.Mappings;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.Data.Repositories.PetCare;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Services.PetCare.Tests.Services
{
    [TestClass]
    public class RowAnimalServicesTests
    {
        //Entities
        private  Professional _professional;
        private  PetServices _petServicesConsult;
        private  PetServices _petServicesHairCut;
        private  Name _name;
        private  Email _email;
        private  Document _document;
        private  Address _address;
        private  Animal _animal;
        private  RowAnimalCare _rowAniamlCare;
        private List<ProfessionalServicesAnimal> _animalServices;

        // Mocks
        //private string conectionString = "Server=RAFAEL-NOTE\\SQLExpress02;Database=MonitoriaDB1;Trusted_Connection=True;MultipleActiveResultSets=true";
        private string conectionString = "Server=localhost;Database=MonitoriaDB1;Trusted_Connection=True;MultipleActiveResultSets=true";
        private Mock<RowAnimalCareRepository> _rowAniamlCareRepository;
        private Mock<PetServicesRepository> _petServicesRepository;
        private Mock<ProfessionalRepository> _professionalServicesRepository;
        private List<ProfessionalServicesAnimal> _animalsServices;
        private PetCareContext _context;
        private IMapper _mapper;
        private ProfessionalServicesAnimal _SAConsult;
        private ProfessionalServicesAnimal _SAHairCut;
        private RowAnimalCareService _rowAnimalCareService;
        private PetServicesService _petServicesService;
        private ProfessionalService _professionalServiceService;


        [TestInitialize]
        public void Initialize()
        {
            //Configurações
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RepositoryToDomainMappingProfile());
                mc.AddProfile(new DomainToRepositoryMappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            var mapper = new Mapper(mappingConfig);
            var optionsB = new DbContextOptionsBuilder<PetCareContext>()
            .UseSqlServer(conectionString).Options;

            //Contexto
            _context = new PetCareContext(optionsB);

            //Repository
            _rowAniamlCareRepository = new Mock<RowAnimalCareRepository>(_context, mapper);
            _petServicesRepository = new Mock<PetServicesRepository>(_context, mapper);
            _professionalServicesRepository = new Mock<ProfessionalRepository>(_context, mapper);

            //ValuesObjects
            _name = new Name("Djalma Jorge", "De Oliveira");
            _email = new Email("djalma.jorge@gmail.com");
            _document = new Document("09052751013", DocumentEnum.CPF);
            _address = new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "19033040");

            //Entidades
            _professional = new Professional(_name, _document, _email, _address, ProfessionalEnum.Veterinary);
            _professional.Id = Guid.NewGuid();
            _petServicesConsult = new PetServices("Consulta Veterinária", CategoryEnum.VeterinaryProcedure, "Examinar o animal para o diagnóstico inicial", (decimal)70.5, true);
            _petServicesConsult.Id = Guid.NewGuid();
            _petServicesHairCut = new PetServices("Banho e Tosa", CategoryEnum.AnimalEsthetics, "Examinar o animal em busca de pequenos ferimentos", (decimal)35.0, true);
            _petServicesHairCut.Id = Guid.NewGuid();
            _animal = new Animal("Greg", 2, SpeciesEnum.Canine, true);
             _SAConsult = new ProfessionalServicesAnimal(_professional, _petServicesConsult, 1, "O animal ficará em observação");
            _SAConsult.Id = Guid.NewGuid();
            _SAHairCut = new ProfessionalServicesAnimal(_professional, _petServicesHairCut, 2, "O animal apresenta pequenos ferimentos sugerindo alergia");
            _SAHairCut.Id = Guid.NewGuid();

            _animalServices = new List<ProfessionalServicesAnimal>();
            _animalServices.Add(_SAConsult);
            _animalServices.Add(_SAHairCut);


            _rowAniamlCare = new RowAnimalCare(_animal, _animalServices);

            _rowAniamlCare.Id = Guid.NewGuid();

            _rowAnimalCareService = new RowAnimalCareService(_rowAniamlCareRepository.Object, _petServicesRepository.Object);
            _petServicesService = new PetServicesService(_petServicesRepository.Object);
            _professionalServiceService = new ProfessionalService(_professionalServicesRepository.Object);

            _rowAnimalCareService.AddRowAnimalCare(_rowAniamlCare);
            _petServicesService.AddPetServices(_petServicesConsult);
            _petServicesService.AddPetServices(_petServicesHairCut);
            _professionalServiceService.AddProfessional(_professional);
        }

        [TestMethod]
        public void ReturnSuccessWhenStartDateIsOK()
        {
            var result = _rowAnimalCareService.StartPetCareServiceOnRow(_rowAniamlCare, _SAConsult.Id);

            var PetCareService = (from p in result.AnimailServices 
                                  where p.Id.Equals(_SAConsult.Id)
                                  select p).FirstOrDefault();

            Assert.IsNotNull(PetCareService, "Serviço não inicializado");
            Assert.AreEqual(PetCareService.StartDate.Value.Day, DateTime.Now.Day);
            Assert.AreEqual(PetCareService.StartDate.Value.Month, DateTime.Now.Month);
            Assert.AreEqual(PetCareService.StartDate.Value.Year, DateTime.Now.Year);
        }

        [TestMethod]
        public void ReturnErrorWhenNotFoundService()
        {
            var result = _rowAnimalCareService.StartPetCareServiceOnRow(_rowAniamlCare, Guid.Empty);
            Assert.IsNull(result, "Serviço não encontrado");
        }

        [TestMethod]
        public void ReturnSuccessWhenEndDateIsOK()
        {
            _rowAnimalCareService.StartPetCareServiceOnRow(_rowAniamlCare, _SAConsult.Id);
            var PetCareService = _rowAnimalCareService.EndPetCareServiceOnRow(_rowAniamlCare, _SAConsult.Id);

            Assert.IsNotNull(PetCareService, "Serviço não inicializado");
            Assert.AreEqual(PetCareService.EndDate.Value.Day, DateTime.Now.Day);
            Assert.AreEqual(PetCareService.EndDate.Value.Month, DateTime.Now.Month);
            Assert.AreEqual(PetCareService.EndDate.Value.Year, DateTime.Now.Year);
        }

        [TestMethod]
        public void ReturnSuccessWhenValueTotalOk()
        {
            var result = _rowAnimalCareService.calculateValueTotalOnRow(_rowAniamlCare);
            Assert.AreEqual(105.50m, result.ValueTotal);
        }

    }
}

