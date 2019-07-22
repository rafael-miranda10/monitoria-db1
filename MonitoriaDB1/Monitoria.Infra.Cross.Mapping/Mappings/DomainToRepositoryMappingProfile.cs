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
            CreateMap<Professional, ProfessionalRepModel>();
            CreateMap<Animal, AnimalPetCareRepModel>()
                .ForMember(d => d.CustomerId, m => m.MapFrom(s => s.Customer.Id));
        }
        private void DomainToModelRepositoryPetCare()
        {
            CreateMap<AnimalPetCare, AnimalPetCareRepModel>();
            CreateMap<PetServices, PetServicesRepModel>();
            CreateMap<Professional, ProfessionalRepModel>()
                .ForMember(d => d.AnimailServices, m => m.MapFrom(s => (s.AnimailServices.Count > 0) ? s.AnimailServices : null));
            CreateMap<ProfessionalServicesAnimal, ProfessionalServicesAnimalRepModel>();
            CreateMap<RowAnimalCare, RowAnimalCareRepModel>();
        }
    }
}
