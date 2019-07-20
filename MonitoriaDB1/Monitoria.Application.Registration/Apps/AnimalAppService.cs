using Monitoria.Application.Registration.Interfaces;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Services;
using System;
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

        public IEnumerable<Animal> GetAllAnimal()
        {
            return _animalService.GetAllAnimal();
        }

        public Animal GetAnimalById(Guid id)
        {
            return _animalService.GetAnimalById(id);
        }

        public IEnumerable<Animal> GetByAnimalName(string name)
        {
            return _animalService.GetByAnimalName(name);
        }

        public IEnumerable<Animal> GetByCustomerId(Guid customerId)
        {
            return _animalService.GetByCustomerId(customerId);
        }
    }
}
