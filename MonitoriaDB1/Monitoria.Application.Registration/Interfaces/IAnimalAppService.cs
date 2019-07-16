using Monitoria.Application.Shared.Interfaces;
using Monitoria.Domain.Registration.Entities;
using System.Collections.Generic;

namespace Monitoria.Application.Registration.Interfaces
{
    public interface IAnimalAppService : IAppServiceBase<Animal>
    {
        IEnumerable<Animal> GetByAnimalName(string name);
    }
}
