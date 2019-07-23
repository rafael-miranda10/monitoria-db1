using Monitoria.Infra.RepModels.Shared.Entity;
using System.Collections.Generic;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class RowAnimalCareRepModel : Entity
    {
        public RowAnimalCareRepModel()
        {
        }
        public RowAnimalCareRepModel(AnimalPetCareRepModel animal,decimal valueTotal ,List<ProfessionalServicesAnimalRepModel> animailservices)
        {
            AnimalPetCare = animal;
            ValueTotal = valueTotal;
            AnimailServices = animailservices;
        }

        public AnimalPetCareRepModel AnimalPetCare { get; private set; }
        public decimal ValueTotal { get; private set; }
        public virtual IList<ProfessionalServicesAnimalRepModel> AnimailServices { get; private set; }
    }
}
