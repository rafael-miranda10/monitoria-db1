using AutoMapper;

namespace Monitoria.Infra.CrossCutting.Mappings
{
    public static class AutoMapperConfig 
    {
        public static MapperConfiguration RegisterMappings()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ViewModelToDomainMappingProfile());
                mc.AddProfile(new RepositoryToDomainMappingProfile());
                mc.AddProfile(new DomainToRepositoryMappingProfile());
                mc.AddProfile(new DomainToViewModelMappingProfile());
            });

            return mappingConfig;
        }
    }
}
