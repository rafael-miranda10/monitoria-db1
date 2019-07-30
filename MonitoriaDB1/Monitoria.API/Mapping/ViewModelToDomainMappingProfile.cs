using AutoMapper;
using Monitoria.API.ViewModels.PetCare;
using Monitoria.API.ViewModels.Registration;
using Monitoria.API.ViewModels.ValueObjects;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.ValueObjects;
using System;

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
            CreateMap<AnimalViewModel, Animal>()
                .ForMember(d => d.Id, m => m.MapFrom(s => (s.Id == Guid.Empty || s.Id == null) ? Guid.NewGuid() : s.Id));
            CreateMap<CustomerViewModel, Customer>()
                .ForMember(d => d.Animails, m => m.MapFrom(s => s.Animails))
                .ForMember(d => d.Id, m => m.MapFrom(s => (s.Id == Guid.Empty || s.Id == null)? Guid.NewGuid() : s.Id)); 

        }
        private void ViewToDomainPetCare()
        {
            CreateMap<PetServicesViewModel, PetServices>()
                .ForMember(d => d.Id, m => m.MapFrom(s => (s.Id == Guid.Empty || s.Id == null) ? Guid.NewGuid() : s.Id));
            CreateMap<ProfessionalViewModel, Professional>()
                .ForMember(d => d.Id, m => m.MapFrom(s => (s.Id == Guid.Empty || s.Id == null) ? Guid.NewGuid() : s.Id));
            CreateMap<ProfessionalServicesAnimalViewModel, ProfessionalServicesAnimal>()
                .ForMember(d => d.Id, m => m.MapFrom(s => (s.Id == Guid.Empty || s.Id == null) ? Guid.NewGuid() : s.Id));
            CreateMap<RowAnimalCareViewModel, RowAnimalCare>()
                .ForMember(d => d.Id, m => m.MapFrom(s => (s.Id == Guid.Empty || s.Id == null) ? Guid.NewGuid() : s.Id));
        }
    }
}
