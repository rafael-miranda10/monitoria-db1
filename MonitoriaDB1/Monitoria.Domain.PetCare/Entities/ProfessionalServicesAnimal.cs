using Flunt.Notifications;
using Flunt.Validations;
using Monitoria.Domain.Shared.Entities;
using System;

namespace Monitoria.Domain.PetCare.Entities
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

            AddNotifications(new Contract()
                   .Requires()
                    .HasMaxLen(Note, 150, "ProfessionalServicesAnimal.Note", "O campo descrição deve ter no maximo 150 caracteres")
                   );

            AddNotifications(prof, pService);
        }

        public Professional Professional { get; private set; }
        public PetServices PetService { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string Note { get; private set; }
        public int ExecutionOrder { get; private set; }
        public RowAnimalCare RowAnimalCare { get; private set; }

        private bool ValidationOfEndDate(DateTime dateToVerify)
        {
            int resultCompare = DateTime.Compare(dateToVerify, StartDate);
            if (resultCompare < 0)
            {
                AddNotification(new Notification("ProfessionalServicesAnimal.EndDate", "A data de finalização do atendimento deve ser maior ou igual a de início do atendimento."));
                return false;
            }

            return true;
        }

        public void FinalizeThePetService(DateTime finalizeDate)
        {
            if (ValidationOfEndDate(finalizeDate))
                EndDate = finalizeDate;
        }


    }
}
