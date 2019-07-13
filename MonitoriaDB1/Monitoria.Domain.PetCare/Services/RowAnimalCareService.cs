using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Shared.Services;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Services
{
    public class RowAnimalCareService : ServiceBase<RowAnimalCare>, IRowAnimalCareService
    {
        private readonly IRowAnimalCareRepository _rowAnimalCareRepository;

        public RowAnimalCareService(IRowAnimalCareRepository rowAnimalCareRepository) : base(rowAnimalCareRepository)
        {
            _rowAnimalCareRepository = rowAnimalCareRepository;
        }
        
        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesOfAnimal(AnimalPetCare animal)
        {
            return _rowAnimalCareRepository.GetAllServicesOfAnimal(animal);
        }
    }
}
