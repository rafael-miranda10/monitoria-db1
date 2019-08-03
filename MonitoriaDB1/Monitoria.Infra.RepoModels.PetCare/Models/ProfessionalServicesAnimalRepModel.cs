using Monitoria.Infra.RepModels.Shared.Entity;
using System;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class ProfessionalServicesAnimalRepModel : Entity
    {
        public ProfessionalServicesAnimalRepModel()
        {
        }
        public ProfessionalServicesAnimalRepModel(Guid professionalId, Guid petServiceId, string note)
        {
            ProfessionalId = professionalId;
            PetServiceId = petServiceId;
            Note = note;
        }

        public Guid ProfessionalId { get; private set; }
        public Guid PetServiceId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string Note { get; private set; }
        public int ExecutionOrder { get; private set; }
        public Guid RowAnimalCareId { get; private set; }
        public RowAnimalCareRepModel RowAnimalCare { get; private set; }
    }
}
