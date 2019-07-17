using Monitoria.Infra.RepModels.Shared.Entity;
using System.Collections.Generic;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class RowAnimalCare : Entity
    {
        public RowAnimalCare()
        {
        }
        public RowAnimalCare(AnimalPetCare animal, List<ProfessionalServicesAnimal> animailservices)
        {
            AnimalPetCare = animal;
            ValueTotal = 0;
            AnimailServices = animailservices;
        }

        public AnimalPetCare AnimalPetCare { get; private set; }
        public decimal ValueTotal { get; private set; }
        public virtual IList<ProfessionalServicesAnimal> AnimailServices { get; private set; }
    }
}
