using AutoMapper;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.ValueObjects;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
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
            CreateMap<CustomerRepModel,Customer>();
            CreateMap<NameRepModel,Name>();
            CreateMap<EmailRepModel,Email>();
            CreateMap<DocumentRepModel,Document>();
            CreateMap<AddressRepModel,Address>();
        }
    }
}
