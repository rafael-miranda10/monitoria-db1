using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Interfaces
{
    public interface IProfessionalServicesAnimalAppService 
    {
        void AddProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal);
        void UpdateProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal);
        void RemoveProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal);
        void RemoveProfissionalServiceAnimalById(Guid id);
        IEnumerable<ProfessionalServicesAnimal> GetAllProfissionalServiceAnimal();
        IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional);
        IEnumerable<ProfessionalServicesAnimal> GetAllServicesOfAnimal(Animal animal);
        ProfessionalServicesAnimal GetProfissionalServiceAnimalById(Guid id);
        ProfessionalServicesAnimal GetEntityEqualTo(ProfessionalServicesAnimal profissionalServiceAnimal);
        bool ExistingEntity(ProfessionalServicesAnimal profissionalServiceAnimal);
    }
}
