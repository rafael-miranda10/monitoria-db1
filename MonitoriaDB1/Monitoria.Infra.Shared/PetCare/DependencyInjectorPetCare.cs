using Microsoft.Extensions.DependencyInjection;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.PetCare.Services;
using Monitoria.Domain.Shared.Interfaces.Repositories;
using Monitoria.Domain.Shared.Interfaces.Services;
using Monitoria.Domain.Shared.Services;
using Monitoria.Infra.Data.Repositories;
using Monitoria.Infra.Data.Repositories.PetCare;

namespace Monitoria.Infra.IoC.PetCare
{
    public class DependencyInjectorPetCare
    {
        public static void Registrar(IServiceCollection svcCollection)
        {
            //Aplicação
            //svcCollection.AddScoped(typeof(IAppBase<,>), typeof(ServicoAppBase<,>));
            //svcCollection.AddScoped<IPratoApp, PratoApp>();

            //Domínio
            svcCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            svcCollection.AddScoped<IAnimalPetCareService, AnimalPetCareService>();
            svcCollection.AddScoped<IPetServicesService, PetServicesService>();
            svcCollection.AddScoped<IProfessionalService, ProfessionalService>();
            svcCollection.AddScoped<IProfessionalServicesAnimalService, ProfessionalServicesAnimalService>();
            svcCollection.AddScoped<IRowAnimalCareService, RowAnimalCareService>();

            //Repositorio
            svcCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<,>));
            svcCollection.AddScoped<IAnimalPetCareRepository, AnimalPetCareRepository>();
            svcCollection.AddScoped<IPetServicesRepository, PetServicesRepository>();
            svcCollection.AddScoped<IProfessionalRepository, ProfessionalRepository>();
            svcCollection.AddScoped<IProfessionalServicesAnimalRepository, ProfessionalServicesAnimalRepository>();
            svcCollection.AddScoped<IRowAnimalCareService, RowAnimalCareService>();

        }
    }
}
