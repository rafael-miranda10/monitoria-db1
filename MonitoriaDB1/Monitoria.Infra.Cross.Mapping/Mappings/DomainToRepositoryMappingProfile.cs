using AutoMapper;
using Monitoria.Infra.RepoModels.Registration.Models;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
using Monitoria.Domain.Shared.ValueObjects;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Infra.RepoModels.PetCare.Models;

namespace Monitoria.Infra.CrossCutting.Mappings
{
    public class DomainToRepositoryMappingProfile : Profile
    {
        public DomainToRepositoryMappingProfile()
        {
            DomainToModelRepositoryRegistration();
            DomainToModelRepositoryPetCare();
        }

        private void DomainToModelRepositoryRegistration()
        {
            CreateMap<Animal, AnimalRepModel>();
            CreateMap<Customer, CustomerRepModel>();
            CreateMap<Name, NameRepModel>();
            CreateMap<Email, EmailRepModel>();
            CreateMap<Document, DocumentRepModel>();
            CreateMap<Address, AddressRepModel>();           
        }
        private void DomainToModelRepositoryPetCare()
        {
            CreateMap<AnimalPetCare, AnimalPetCareRepModel>();
            CreateMap<PetServices, PetServicesRepModel>();
            CreateMap<Professional, ProfessionalRepModel>();
            CreateMap<ProfessionalServicesAnimal, ProfessionalServicesAnimalRepModel>();
            CreateMap<RowAnimalCare, RowAnimalCareRepModel>()
                .ForMember(d => d.AnimalPetCare, m => m.MapFrom(s => s.AnimalPetCare))
                .ForMember(d => d.AnimailServices, m => m.MapFrom(s => s.AnimailServices));
        }
    }
}
