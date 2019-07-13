using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Shared.Interfaces.Repositories;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Repositories
{
    public interface IRowAnimalCareRepository: IRepositoryBase<RowAnimalCare>
    {
        IEnumerable<ProfessionalServicesAnimal> GetAllServicesOfAnimal(AnimalPetCare animal);
    }
}
