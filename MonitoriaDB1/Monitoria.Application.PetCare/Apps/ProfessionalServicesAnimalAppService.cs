using System;
using System.Collections.Generic;
using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Services;

namespace Monitoria.Application.PetCare.Apps
{
    public class ProfessionalServicesAnimalAppService : IProfessionalServicesAnimalAppService
    {
        private readonly IProfessionalServicesAnimalService _professionalServicesAnimalService;

        public ProfessionalServicesAnimalAppService(IProfessionalServicesAnimalService professionalServicesAnimalService) 
        {
            _professionalServicesAnimalService = professionalServicesAnimalService;
        }

        public void AddProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            _professionalServicesAnimalService.AddProfissionalServiceAnimal(profissionalServiceAnimal);
        }

        public bool ExistingEntity(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            return _professionalServicesAnimalService.ExistingEntity(profissionalServiceAnimal);
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllProfissionalServiceAnimal()
        {
            return _professionalServicesAnimalService.GetAllProfissionalServiceAnimal();
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional)
        {
            return _professionalServicesAnimalService.GetAllServicesByProfessional(profissional);
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesOfAnimal(AnimalPetCare animal)
        {
            return _professionalServicesAnimalService.GetAllServicesOfAnimal(animal);
        }

        public ProfessionalServicesAnimal GetEntityEqualTo(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            return _professionalServicesAnimalService.GetEntityEqualTo(profissionalServiceAnimal);
        }

        public ProfessionalServicesAnimal GetProfissionalServiceAnimalById(Guid id)
        {
            return _professionalServicesAnimalService.GetProfissionalServiceAnimalById(id);
        }

        public void RemoveProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            _professionalServicesAnimalService.RemoveProfissionalServiceAnimal(profissionalServiceAnimal);
        }

        public void RemoveProfissionalServiceAnimalById(Guid id)
        {
            _professionalServicesAnimalService.RemoveProfissionalServiceAnimalById(id);
        }

        public void UpdateProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            _professionalServicesAnimalService.UpdateProfissionalServiceAnimal(profissionalServiceAnimal);
        }
    }
}
