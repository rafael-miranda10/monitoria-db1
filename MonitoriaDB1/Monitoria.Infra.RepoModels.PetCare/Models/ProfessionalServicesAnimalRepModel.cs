using Monitoria.Infra.RepModels.Shared.Entity;
using System;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class ProfessionalServicesAnimalRepModel : Entity
    {
        public ProfessionalServicesAnimalRepModel()
        {
        }
        //public ProfessionalServicesAnimalRepModel(ProfessionalRepModel prof, PetServicesRepModel pService, string note)
        //{
        //    Professional = prof;
        //    PetService = pService;
        //    StartDate = DateTime.Now;
        //    Note = note;
        //}

        public ProfessionalServicesAnimalRepModel(string note)
        {
            StartDate = DateTime.Now;
            Note = note;
        }

        public Guid professionalId { get; private set; }
        //public virtual ProfessionalRepModel Professional { get; private set; }
        public Guid PetServiceId { get; private set; }
        //public virtual PetServicesRepModel PetService { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string Note { get; private set; }
        public int ExecutionOrder { get; private set; }
        public Guid RowAnimalCareId { get; private set; }
        public virtual RowAnimalCareRepModel RowAnimalCare { get; private set; }
    }
}
