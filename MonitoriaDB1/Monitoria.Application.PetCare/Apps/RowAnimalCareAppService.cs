using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Application.Shared.Apps;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Services;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Apps
{
    public class RowAnimalCareAppService : AppServiceBase<RowAnimalCare>, IRowAnimalCareAppService
    {
        private readonly IRowAnimalCareService _rowAnimalCareService;

        public RowAnimalCareAppService(IRowAnimalCareService rowAnimalCareService) : base(rowAnimalCareService)
        {
            _rowAnimalCareService = rowAnimalCareService;
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesOfAnimal(AnimalPetCare animal)
        {
            return _rowAnimalCareService.GetAllServicesOfAnimal(animal);
        }
    }
}
