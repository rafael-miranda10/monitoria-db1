using Microsoft.Extensions.DependencyInjection;
using Monitoria.Application.Registration.Apps;
using Monitoria.Application.Registration.Interfaces;
using Monitoria.Application.Shared.Apps;
using Monitoria.Application.Shared.Interfaces;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Domain.Registration.Interfaces.Services;
using Monitoria.Domain.Registration.Services;
using Monitoria.Domain.Shared.Interfaces.Repositories;
using Monitoria.Domain.Shared.Interfaces.Services;
using Monitoria.Domain.Shared.Interfaces.UoW;
using Monitoria.Domain.Shared.Services;
using Monitoria.Infra.Data.Repositories;
using Monitoria.Infra.Data.Repositories.Registration;
using Monitoria.Infra.Data.UoW;

namespace Monitoria.Infra.IoC.Registration
{
    public class DependencyInjectorRegistration
    {

        public static void Registrar(IServiceCollection svcCollection)
        {
            //Aplicação
            svcCollection.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            svcCollection.AddScoped<IAnimalAppService, AnimalAppService>();
            svcCollection.AddScoped<ICustomerAppService, CustomerAppService>();

            //Domínio
            svcCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            svcCollection.AddScoped<IAnimalService, AnimalService>();
            svcCollection.AddScoped<ICustomerService, CustomerService>();

            //Repositorio
            svcCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<,>));
            svcCollection.AddScoped<IAnimalRepository, AnimalRepository>();
            svcCollection.AddScoped<ICustomerRepository, CustomerRepository>();

            //UoW
            svcCollection.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<>));

        }
    }
}
