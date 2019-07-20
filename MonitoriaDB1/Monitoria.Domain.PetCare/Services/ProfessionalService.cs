using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Services
{
    public class ProfessionalService : IProfessionalService
    {
        private readonly IProfessionalRepository _professionalRepository;

        public ProfessionalService(IProfessionalRepository professionalRepository)
        {
            _professionalRepository = professionalRepository;
        }

        public void AddProfessional(Professional professional)
        {
            _professionalRepository.AddProfessional(professional);
        }

        public bool ExistingEntity(Professional professional)
        {
            return _professionalRepository.ExistingEntity(professional);
        }

        public IEnumerable<Professional> GetAllProfessional()
        {
            return _professionalRepository.GetAllProfessional();
        }

        public IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type)
        {
            return _professionalRepository.GetAllProfessionalByEnum(type);
        }

        public IEnumerable<Professional> GetByProfessionalName(string name)
        {
            return _professionalRepository.GetByProfessionalName(name);
        }

        public Professional GetEntityEqualTo(Professional professional)
        {
            return _professionalRepository.GetEntityEqualTo(professional);
        }

        public Professional GetProfessionalById(Guid id)
        {
            return _professionalRepository.GetProfessionalById(id);
        }

        public void RemoveProfessional(Professional professional)
        {
            _professionalRepository.RemoveProfessional(professional);
        }

        public void RemoveProfessionalById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProfessional(Professional professional)
        {
            throw new NotImplementedException();
        }
    }
}
