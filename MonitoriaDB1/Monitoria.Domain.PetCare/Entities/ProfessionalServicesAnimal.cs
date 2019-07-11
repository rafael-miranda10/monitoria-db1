using Flunt.Validations;
using Monitoria.Domain.Shared.Entities;
using System;

namespace Monitoria.Domain.PetCare.Entities
{
    public class ProfessionalServicesAnimal : Entity
    {

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

        }

        public Professional Professional { get; private set; }
        public PetServices PetService { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Note { get; private set; }

        public void ValidationOfEndDate(DateTime endDate)
        {
            int resultCompare = DateTime.Compare(EndDate, DateTime.Now);
            if (resultCompare == 0 || resultCompare > 0)
                EndDate = endDate;
            if (resultCompare < 0)
                AddNotifications(new Contract()
                   .Requires()
                   .IsTrue(false, "ProfessionalServicesAnimal.EndDate", "A data de finalização deve ser maior ou igual ao dia que foi iniciado o atendimento.")
                   );

        }
    }
}
