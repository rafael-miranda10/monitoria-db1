using AutoMapper;
using Monitoria.API.ViewModels.PetCare;
using Monitoria.API.ViewModels.Registration;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;

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
            CreateMap<Animal,AnimalViewModel>();
            CreateMap<Customer, CustomerViewModel>();

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
