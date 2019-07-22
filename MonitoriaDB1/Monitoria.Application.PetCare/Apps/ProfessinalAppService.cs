using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.PetCare.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Apps
{
    public class ProfessinalAppService : IProfessinalAppService
    {
        private readonly IProfessionalService _professionalService;

        public ProfessinalAppService(IProfessionalService professionalService) 
        {
            _professionalService = professionalService;
        }

        public void AddProfessional(Professional professional)
        {
            _professionalService.AddProfessional(professional);
        }

        public bool ExistingEntity(Professional professional)
        {
            return _professionalService.ExistingEntity(professional);
        }

        public IEnumerable<Professional> GetAllProfessional()
        {
            return _professionalService.GetAllProfessional();
        }

        public IEnumerable<Professional> GetAllProfessionalByEnum(int type)
        {
            return _professionalService.GetAllProfessionalByEnum((ProfessionalEnum)type);
        }

        public IEnumerable<Professional> GetByProfessionalName(string name)
        {
            return _professionalService.GetByProfessionalName(name);
        }

        public Professional GetEntityEqualTo(Professional professional)
        {
            return _professionalService.GetEntityEqualTo(professional);
        }

        public Professional GetProfessionalById(Guid id)
        {
            return _professionalService.GetProfessionalById(id);
        }

        public void RemoveProfessional(Professional professional)
        {
            _professionalService.RemoveProfessional(professional);
        }

        public void RemoveProfessionalById(Guid id)
        {
            _professionalService.RemoveProfessionalById(id);
        }

        public void UpdateProfessional(Professional professional)
        {
            _professionalService.UpdateProfessional(professional);
        }
    }
}
