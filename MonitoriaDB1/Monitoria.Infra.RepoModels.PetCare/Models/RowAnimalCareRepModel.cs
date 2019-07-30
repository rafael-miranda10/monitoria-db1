using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepoModels.Registration.Models;
using System;
using System.Collections.Generic;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class RowAnimalCareRepModel : Entity
    {
        public RowAnimalCareRepModel()
        {
        }
        public RowAnimalCareRepModel(AnimalRepModel animal,decimal valueTotal ,List<ProfessionalServicesAnimalRepModel> animailservices)
        {
            Animal = animal;
            ValueTotal = valueTotal;
            AnimailServices = animailservices;
        }

        public Guid AnimalId { get; private set; }
        public virtual AnimalRepModel Animal { get; private set; }
        public decimal ValueTotal { get; private set; }
        public virtual IList<ProfessionalServicesAnimalRepModel> AnimailServices { get; private set; }
    }
}
