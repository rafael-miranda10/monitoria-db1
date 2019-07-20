using AutoMapper;
using Monitoria.API.ViewModels.PetCare;
using Monitoria.API.ViewModels.Registration;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;

namespace Monitoria.API.Mapping
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            ViewToDomainRegistration();
            ViewToDomainPetCare();
        }

        private void ViewToDomainRegistration()
        {
            CreateMap<AnimalViewModel, Animal>();
            CreateMap<CustomerViewModel, Customer>();

        }
        private void ViewToDomainPetCare()
        {
            CreateMap<AnimalPetCareViewModel,AnimalPetCare>();
            CreateMap<PetServicesViewModel, PetServices>();
            CreateMap<ProfessionalViewModel, Professional>();
            CreateMap<ProfessionalServicesAnimalViewModel, ProfessionalServicesAnimal>();
            CreateMap<RowAnimalCareViewModel, RowAnimalCare>();
        }
    }
}
