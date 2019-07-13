using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Shared.Services;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Services
{
    public class ProfessionalServicesAnimalService : ServiceBase<ProfessionalServicesAnimal>, IProfessionalServicesAnimalService
    {
        private readonly IProfessionalServicesAnimalRepository _professionalServicesAnimalRepository;

        public ProfessionalServicesAnimalService(IProfessionalServicesAnimalRepository professionalServicesAnimalRepository) : base(professionalServicesAnimalRepository)
        {
            _professionalServicesAnimalRepository = professionalServicesAnimalRepository;
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional)
        {
            return _professionalServicesAnimalRepository.GetAllServicesByProfessional(profissional);
        }
    }
}
