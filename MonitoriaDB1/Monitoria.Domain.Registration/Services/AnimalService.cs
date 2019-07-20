using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Domain.Registration.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IEnumerable<Animal> GetAllAnimal()
        {
            return _animalRepository.GetAllAnimal();
        }

        public Animal GetAnimalById(Guid id)
        {
            return _animalRepository.GetAnimalById(id);
        }

        public IEnumerable<Animal> GetByAnimalName(string name)
        {
            return _animalRepository.GetByAnimalName(name);
        }

        public IEnumerable<Animal> GetByCustomerId(Guid customerId)
        {
            return _animalRepository.GetByCustomerId(customerId);
        }
    }
}
