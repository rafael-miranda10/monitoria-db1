﻿using Flunt.Notifications;
using Flunt.Validations;
using Monitoria.Domain.Shared.Entities;
using System;
using System.Linq;

namespace Monitoria.Domain.PetCare.Entities
{
    public class ProfessionalServicesAnimal : Entity
    {
        public ProfessionalServicesAnimal()
        {

        }
        public ProfessionalServicesAnimal(Professional prof, PetServices pService, int Order,string note)
        {
            Professional = prof;
            PetService = pService;
            ExecutionOrder = Order;
            Note = note;

            AddNotifications(new Contract()
                   .Requires()
                    .HasMaxLen(Note, 150, "ProfessionalServicesAnimal.Note", "O campo descrição deve ter no maximo 150 caracteres")
                    .IsGreaterThan(ExecutionOrder,0, "ProfessionalServicesAnimal.ExecuteOrder","O campo de ordem de execução deve ser maior que zero")
                   );

            AddNotifications(prof, pService);
        }

        public Professional Professional { get; private set; }
        public PetServices PetService { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string Note { get; private set; }
        public int ExecutionOrder { get; private set; }
        public RowAnimalCare RowAnimalCare { get; private set; }

        private bool ValidationOfEndDate(DateTime dateToVerify)
        {
            int resultCompare = DateTime.Compare(dateToVerify, StartDate.Value);
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

        public void StartThePetService()
        {
            StartDate = DateTime.Now;
        }

        public bool ExistInOrderExecution(int Order)
        {
            var result = RowAnimalCare.AnimailServices.Where(x => x.ExecutionOrder == Order).FirstOrDefault();
            if (result != null)
                return true;

            return false;
        }

        public void AlterProfessional(Professional newProfessional)
        {
            Professional = newProfessional;
        }
    }
}
