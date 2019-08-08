using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Services;
using Monitoria.Infra.CrossCutting.Mappings;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.Data.Repositories.PetCare;
using Moq;
using System.Collections.Generic;

namespace Monitoria.Services.PetCare.Tests.Services
{
    [TestClass]
    public class RowAnimalServicesTests
    {
        private Mock<IRowAnimalCareRepository> _rowAniamlCareRepository;
        private Mock<IPetServicesRepository> _petServicesRepository;
        private List<ProfessionalServicesAnimal> _animalsServices;
        private RowAnimalCare _rowAniamlCare;
        private PetCareContext _context;
        private IMapper _mapper;


        [TestInitialize]
        public void Initialize()
        {
            _animalsServices = new List<ProfessionalServicesAnimal>();
            DbContextOptions<PetCareContext> options = new DbContextOptions<PetCareContext>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RepositoryToDomainMappingProfile());
                mc.AddProfile(new DomainToRepositoryMappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
            var mapper = new Mapper(mappingConfig);
            _context = new PetCareContext(options);

            _rowAniamlCareRepository = new Mock<IRowAnimalCareRepository>(_context, mapper);
            _petServicesRepository = new Mock<IPetServicesRepository>(_context, mapper);
        }
        [TestMethod]
        public void Test_Test()
        {
            var rowAnimalCareService = new RowAnimalCareService(_rowAniamlCareRepository.Object, _petServicesRepository.Object);
            
            
            
        }





    }
}

//https://www.lambda3.com.br/2012/06/testes-integrados-com-webapi/
//https://flaviohenriquedecarvalho.wordpress.com/2015/02/18/o-que-onde-quando-e-quem-testar-no-seu-codigo/