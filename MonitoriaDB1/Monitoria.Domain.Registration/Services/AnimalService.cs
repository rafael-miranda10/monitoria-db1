using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Domain.Registration.Interfaces.Services;
using Monitoria.Domain.Shared.Services;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Services
{
    public class AnimalService : ServiceBase<Animal>, IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository): base(animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IEnumerable<Animal> GetByAnimalName(string name)
        {
            return _animalRepository.GetByAnimalName(name);
        }
    }
}
