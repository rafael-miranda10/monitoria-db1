using Monitoria.Infra.RepModels.Shared.Entity;
using System;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class ProfessionalServicesAnimal : Entity
    {
        public ProfessionalServicesAnimal()
        {
        }
        public ProfessionalServicesAnimal(Professional prof, PetServices pService, string note)
        {
            Professional = prof;
            PetService = pService;
            StartDate = DateTime.Now;
            Note = note;
        }

        public Guid professionalId { get; private set; }
        public virtual Professional Professional { get; private set; }
        public Guid PetServiceId { get; private set; }
        public virtual PetServices PetService { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Note { get; private set; }
        public Guid RowAnimalCareId { get; private set; }
        public virtual RowAnimalCare RowAnimalCare { get; private set; }
    }
}
