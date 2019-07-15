using Microsoft.Extensions.DependencyInjection;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Domain.Registration.Interfaces.Services;
using Monitoria.Domain.Registration.Services;
using Monitoria.Domain.Shared.Interfaces.Repositories;
using Monitoria.Domain.Shared.Interfaces.Services;
using Monitoria.Domain.Shared.Services;
using Monitoria.Infra.Data.Repositories;
using Monitoria.Infra.Data.Repositories.Registration;

namespace Monitoria.Infra.IoC.Registration
{
    public class DependencyInjectorRegistration
    {

        public static void Registrar(IServiceCollection svcCollection)
        {
            //Aplicação
            //svcCollection.AddScoped(typeof(IAppBase<,>), typeof(ServicoAppBase<,>));
            //svcCollection.AddScoped<IPratoApp, PratoApp>();

            //Domínio
            svcCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            svcCollection.AddScoped<IAnimalService, AnimalService>();
            svcCollection.AddScoped<ICustomerService, CustomerService>();

            //Repositorio
            svcCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<,>));
            svcCollection.AddScoped<IAnimalRepository, AnimalRepository>();
            svcCollection.AddScoped<ICustomerRepository, CustomerRepository>();

        }
    }
}
