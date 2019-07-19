using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Repositories
{
    public interface IProfessionalRepository
    {
        void AddProfessional(Professional professional);
        void UpdateProfessional(Professional professional);
        void RemoveProfessional(Professional professional);
        void RemoveProfessionalById(Guid id);
        IEnumerable<Professional> GetAllProfessional();
        IEnumerable<Professional> GetByProfessionalName(string name);
        IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type);
        Professional GetProfessionalById(Guid id);
        Professional GetEntityEqualTo(Professional professional);
        bool ExistingEntity(Professional professional);
    }
}
