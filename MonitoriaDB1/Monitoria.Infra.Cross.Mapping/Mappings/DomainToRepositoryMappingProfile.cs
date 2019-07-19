using AutoMapper;
using Monitoria.Infra.RepoModels.Registration.Models;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
using Monitoria.Domain.Shared.ValueObjects;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Infra.RepoModels.PetCare.Models;

namespace Monitoria.Infra.CrossCutting.Mappings
{
    public class DomainToRepositoryMappingProfile : Profile
    {
        public DomainToRepositoryMappingProfile()
        {
            DomainToModelRepository();
        }

        private void DomainToModelRepository()
        {
            CreateMap<Animal, AnimalRepModel>();
            CreateMap<Customer, CustomerRepModel>();
            CreateMap<Name, NameRepModel>();
            CreateMap<Email, EmailRepModel>();
            CreateMap<Document, DocumentRepModel>();
            CreateMap<Address, AddressRepModel>();
            CreateMap<Professional, ProfessionalRepModel>();
            CreateMap<Animal, AnimalPetCareRepModel>()
                .ForMember(d => d.CustomerId, m => m.MapFrom(s => s.Customer.Id));
        }
    }
}
