﻿using Monitoria.Domain.PetCare.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Interfaces
{
    public interface IRowAnimalCareAppService 
    {
        void AddRowAnimalCare(RowAnimalCare rowAnimalCare);
        void UpdateRowAnimalCare(RowAnimalCare rowAnimalCare);
        void RemoveRowAnimalCare(RowAnimalCare rowAnimalCare);
        void RemoveRowAnimalCareById(Guid id);
        IEnumerable<RowAnimalCare> GetAllRowAnimalCare();
        IEnumerable<RowAnimalCare> GetAllServicesOfAnimal(AnimalPetCare animal);
        RowAnimalCare GetRowAnimalCareById(Guid id);
        RowAnimalCare GetEntityEqualTo(RowAnimalCare rowAnimalCare);
        bool ExistingEntity(RowAnimalCare rowAnimalCare);
    }
}
