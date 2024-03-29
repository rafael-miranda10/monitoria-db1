﻿using Monitoria.Infra.RepModels.Shared.Entity;
using System;
using System.Collections.Generic;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class RowAnimalCareRepModel : Entity
    {
        public RowAnimalCareRepModel()
        {
        }
        public RowAnimalCareRepModel(Guid animalId, decimal valueTotal, List<ProfessionalServicesAnimalRepModel> animailservices)
        {
            AnimalId = animalId;
            ValueTotal = valueTotal;
            AnimailServices = animailservices;
        }

        public Guid AnimalId { get; private set; }
        public decimal ValueTotal { get; private set; }
        public virtual IList<ProfessionalServicesAnimalRepModel> AnimailServices { get; private set; }
    }
}
