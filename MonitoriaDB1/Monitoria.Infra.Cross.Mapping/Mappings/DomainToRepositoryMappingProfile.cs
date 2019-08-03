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
            CreateMap<PetServices, PetServicesRepModel>();
            CreateMap<Professional, ProfessionalRepModel>();
            CreateMap<ProfessionalServicesAnimal, ProfessionalServicesAnimalRepModel>()
                .ForMember(d => d.PetServiceId, m => m.MapFrom(s => s.PetService.Id))
                .ForMember(d => d.ProfessionalId, m => m.MapFrom(s => s.Professional.Id))
                .ForMember(d => d.RowAnimalCareId, m => m.MapFrom(s => s.RowAnimalCare.Id))
                .ForMember(d => d.StartDate, m => m.MapFrom(s => s.StartDate))
                .ForMember(d => d.EndDate, m => m.MapFrom(s => s.EndDate))
                .ForMember(d => d.Note, m => m.MapFrom(s => s.Note))
                .ForMember(d => d.ExecutionOrder, m => m.MapFrom(s => s.ExecutionOrder))
                .ForMember(d => d.RowAnimalCareId, m => m.MapFrom(s => s.RowAnimalCare.Id));
            CreateMap<RowAnimalCare, RowAnimalCareRepModel>()
                .ForMember(d => d.AnimailServices, m => m.MapFrom(s => s.AnimailServices));
        }
    }
}
