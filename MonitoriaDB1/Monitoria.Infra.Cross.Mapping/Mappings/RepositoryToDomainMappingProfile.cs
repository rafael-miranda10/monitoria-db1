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
            ModelRepositoryToDomain();
        }

        private void ModelRepositoryToDomain()
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
    }
}
