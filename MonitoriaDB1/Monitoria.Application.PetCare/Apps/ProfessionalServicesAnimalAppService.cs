using System.Collections.Generic;
using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Application.Shared.Apps;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Services;

namespace Monitoria.Application.PetCare.Apps
{
    public class ProfessionalServicesAnimalAppService : AppServiceBase<ProfessionalServicesAnimal>, IProfessionalServicesAnimalAppService
    {
        private readonly IProfessionalServicesAnimalService _professionalServicesAnimalService;

        public ProfessionalServicesAnimalAppService(IProfessionalServicesAnimalService professionalServicesAnimalService) : base(professionalServicesAnimalService)
        {
            _professionalServicesAnimalService = professionalServicesAnimalService;
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional)
        {
            return _professionalServicesAnimalService.GetAllServicesByProfessional(profissional);
        }
    }
}
