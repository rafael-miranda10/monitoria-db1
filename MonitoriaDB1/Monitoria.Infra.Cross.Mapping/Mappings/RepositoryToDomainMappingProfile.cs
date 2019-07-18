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
                //.ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
                //.ForMember(d => d.Name, m => m.MapFrom(s => s.Name))
                //.ForMember(d => d.Age, m => m.MapFrom(s => s.Age))
                //.ForMember(d => d.Specie, m => m.MapFrom(s => s.Specie))
                //.ForMember(d => d.IsAlive, m => m.MapFrom(s => s.IsAlive));
            CreateMap<CustomerRepModel,Customer>()
                .ForMember(d => d.Animails, m => m.MapFrom(s => s.Animails));
            CreateMap<NameRepModel,Name>();
            CreateMap<EmailRepModel,Email>();
            CreateMap<DocumentRepModel,Document>();
            CreateMap<AddressRepModel,Address>();
        }
    }
}
