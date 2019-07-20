using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Services
{
    public class ProfessionalServicesAnimalService : IProfessionalServicesAnimalService
    {
        private readonly IProfessionalServicesAnimalRepository _professionalServicesAnimalRepository;

        public ProfessionalServicesAnimalService(IProfessionalServicesAnimalRepository professionalServicesAnimalRepository) 
        {
            _professionalServicesAnimalRepository = professionalServicesAnimalRepository;
        }

        public void AddProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            _professionalServicesAnimalRepository.AddProfissionalServiceAnimal(profissionalServiceAnimal);
        }

        public bool ExistingEntity(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            return _professionalServicesAnimalRepository.ExistingEntity(profissionalServiceAnimal);
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllProfissionalServiceAnimal()
        {
            return _professionalServicesAnimalRepository.GetAllProfissionalServiceAnimal();
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional)
        {
            return _professionalServicesAnimalRepository.GetAllServicesByProfessional(profissional);
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesOfAnimal(AnimalPetCare animal)
        {
            return _professionalServicesAnimalRepository.GetAllServicesOfAnimal(animal);
        }

        public ProfessionalServicesAnimal GetEntityEqualTo(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            return _professionalServicesAnimalRepository.GetEntityEqualTo(profissionalServiceAnimal);
        }

        public ProfessionalServicesAnimal GetProfissionalServiceAnimalById(Guid id)
        {
            return _professionalServicesAnimalRepository.GetProfissionalServiceAnimalById(id);
        }

        public void RemoveProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            _professionalServicesAnimalRepository.RemoveProfissionalServiceAnimal(profissionalServiceAnimal);
        }

        public void RemoveProfissionalServiceAnimalById(Guid id)
        {
            _professionalServicesAnimalRepository.RemoveProfissionalServiceAnimalById(id);
        }

        public void UpdateProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            _professionalServicesAnimalRepository.UpdateProfissionalServiceAnimal(profissionalServiceAnimal);
        }
    }
}
