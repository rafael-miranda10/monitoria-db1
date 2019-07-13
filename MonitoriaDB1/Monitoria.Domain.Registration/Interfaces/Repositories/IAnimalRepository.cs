using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Interfaces.Repositories;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Interfaces.Repositories
{
    public interface IAnimalRepository: IRepositoryBase<Animal>
    {
        IEnumerable<Animal> GetByAnimalName(string name);
    }
}
