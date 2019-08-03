using AutoMapper;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.ValueObjects;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
using Monitoria.Infra.RepoModels.PetCare.Models;
using Monitoria.Infra.RepoModels.Registration.Models;

namespace Monitoria.Infra.CrossCutting.Mappings
{
    public class RepositoryToDomainMappingProfile : Profile
    {
        public RepositoryToDomainMappingProfile()
        {
            ModelRepositoryToDomainRegistration();
            ModelRepositoryToDomainPetCare();
        }

        private void ModelRepositoryToDomainRegistration()
        {
            CreateMap<AnimalRepModel, Animal>();
            CreateMap<CustomerRepModel,Customer>()
                .ForMember(d => d.Animails, m => m.MapFrom(s => s.Animails));
            CreateMap<NameRepModel,Name>();
            CreateMap<EmailRepModel,Email>();
            CreateMap<DocumentRepModel,Document>();
            CreateMap<AddressRepModel,Address>();
            CreateMap<ProfessionalRepModel, Professional>();
        }
        private void ModelRepositoryToDomainPetCare()
        {
            CreateMap<PetServicesRepModel,PetServices>();
            CreateMap<ProfessionalRepModel,Professional>();
            CreateMap<ProfessionalServicesAnimalRepModel,ProfessionalServicesAnimal>()
                .ForPath(d => d.Professional.Id, m => m.MapFrom(s => s.ProfessionalId))
                .ForPath(d => d.PetService.Id, m => m.MapFrom(s => s.PetServiceId));
            CreateMap<RowAnimalCareRepModel,RowAnimalCare>();
        }
    }
}
