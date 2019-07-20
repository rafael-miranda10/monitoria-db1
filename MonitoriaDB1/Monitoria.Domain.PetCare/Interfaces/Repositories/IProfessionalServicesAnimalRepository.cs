using Monitoria.Domain.PetCare.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Repositories
{
    public interface IProfessionalServicesAnimalRepository 
    {
        void AddProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal);
        void UpdateProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal);
        void RemoveProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal);
        void RemoveProfissionalServiceAnimalById(Guid id);
        IEnumerable<ProfessionalServicesAnimal> GetAllProfissionalServiceAnimal();
        IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional);
        IEnumerable<ProfessionalServicesAnimal> GetAllServicesOfAnimal(AnimalPetCare animal);
        ProfessionalServicesAnimal GetProfissionalServiceAnimalById(Guid id);
        ProfessionalServicesAnimal GetEntityEqualTo(ProfessionalServicesAnimal profissionalServiceAnimal);
        bool ExistingEntity(ProfessionalServicesAnimal profissionalServiceAnimal);
    }
}
