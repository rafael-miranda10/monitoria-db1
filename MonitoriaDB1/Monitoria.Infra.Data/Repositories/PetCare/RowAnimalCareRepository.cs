using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class RowAnimalCareRepository : RepositoryBase<RowAnimalCare, PetCareContext>, IRowAnimalCareRepository
    {
        private readonly PetCareContext _context;

        public RowAnimalCareRepository(PetCareContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesOfAnimal(AnimalPetCare animal)
        {
            return _context.Set<ProfessionalServicesAnimal>().Where(x => x.RowAnimalCare.AnimalPetCare.Equals(animal)).AsEnumerable();
        }
    }
}
