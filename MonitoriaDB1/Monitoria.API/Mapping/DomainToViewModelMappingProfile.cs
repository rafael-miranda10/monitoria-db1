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
            CreateMap<Animal,AnimalViewModel>();
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(d => d.Animails, m => m.MapFrom(s => s.Animails))
                .ForMember(d => d.CustomerId, m => m.MapFrom(s => s.Id)); 

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
