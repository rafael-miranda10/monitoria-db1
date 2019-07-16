using Monitoria.Application.Shared.Interfaces;
using Monitoria.Domain.PetCare.Entities;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Interfaces
{
    public interface IProfessionalServicesAnimalAppService : IAppServiceBase<ProfessionalServicesAnimal>
    {
        IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional);
    }
}
