using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class ProfessionalServicesAnimalRepository : RepositoryBase<ProfessionalServicesAnimal, PetCareContext>, IProfessionalServicesAnimalRepository
    {
        private readonly PetCareContext _context;

        public ProfessionalServicesAnimalRepository(PetCareContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional)
        {
            return _context.Set<ProfessionalServicesAnimal>().Where(x => x.Professional.Equals(profissional)).AsEnumerable();
        }
    }
}
