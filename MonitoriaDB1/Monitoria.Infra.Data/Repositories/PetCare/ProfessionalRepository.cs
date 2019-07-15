using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class ProfessionalRepository : RepositoryBase<Professional, PetCareContext>, IProfessionalRepository
    {
        private readonly PetCareContext _context;

        public ProfessionalRepository(PetCareContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type)
        {
            return _context.Set<Professional>().Where(x => x.JobPosition.Equals(type)).AsEnumerable();
        }
    }
}
