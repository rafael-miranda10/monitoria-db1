using AutoMapper;
using Monitoria.API.ViewModels.PetCare;
using Monitoria.API.ViewModels.Registration;
using Monitoria.API.ViewModels.ValueObjects;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.ValueObjects;

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
            CreateMap<NameViewModel, Name>();
            CreateMap<EmailViewModel, Email>();
            CreateMap<AddressViewModel, Address>();
            CreateMap<DocumentViewModel, Document>();
            CreateMap<AnimalViewModel, Animal>();
            CreateMap<CustomerViewModel, Customer>()
                .ForMember(d => d.Animails, m => m.MapFrom(s => s.Animails)); 

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
