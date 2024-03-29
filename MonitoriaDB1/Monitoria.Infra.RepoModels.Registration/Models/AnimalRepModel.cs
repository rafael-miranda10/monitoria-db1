﻿using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepModels.Shared.Enum;
using System;

namespace Monitoria.Infra.RepoModels.Registration.Models
{
    public class AnimalRepModel : Entity
    {
        public AnimalRepModel()
        {

        }
        public AnimalRepModel(string name, int age, SpeciesEnum specie, bool isAlive)
        {
            Name = name;
            Age = age;
            Specie = specie;
            IsAlive = isAlive;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public SpeciesEnum Specie { get; private set; }
        public bool IsAlive { get; private set; }
        public Guid CustomerId { get; private set; }
        public virtual CustomerRepModel Customer { get; private set; }
    }
}
