using AutoMapper;
using Monitoria.API.ViewModels.PetCare;
using Monitoria.API.ViewModels.Registration;
using Monitoria.API.ViewModels.ValueObjects;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.ValueObjects;

namespace Monitoria.API.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            DomainToViewRegistration();
            DomainToViewPetCare();
        }

        private void DomainToViewRegistration()
        {
            CreateMap<Name, NameViewModel>();
            CreateMap<Email, EmailViewModel>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Document, DocumentViewModel>();
            CreateMap<Animal,AnimalViewModel>()
            .ForMember(d => d.Id, m => m.MapFrom(s =>  s.Id));
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
                .ForMember(d => d.Animails, m => m.MapFrom(s => s.Animails)); 

        }
        private void DomainToViewPetCare()
        {
            CreateMap<AnimalPetCare,AnimalPetCareViewModel>();
            CreateMap<PetServices, PetServicesViewModel>();
            CreateMap<Professional, ProfessionalViewModel>();
            CreateMap<ProfessionalServicesAnimal, ProfessionalServicesAnimalViewModel>();
            CreateMap<RowAnimalCare, RowAnimalCareViewModel>();
        }
    }
}
