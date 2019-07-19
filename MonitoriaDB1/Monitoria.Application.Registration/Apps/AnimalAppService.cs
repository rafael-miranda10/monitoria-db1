using Monitoria.Application.Registration.Interfaces;
using Monitoria.Application.Shared.Apps;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Services;
using System.Collections.Generic;

namespace Monitoria.Application.Registration.Apps
{
    public class AnimalAppService :  IAnimalAppService
    {
        private readonly IAnimalService _animalService;

        public AnimalAppService(IAnimalService animalService) 
        {
            _animalService = animalService;
        }

        public IEnumerable<Animal> GetByAnimalName(string name)
        {
            return _animalService.GetByAnimalName(name);
        }
    }
}
