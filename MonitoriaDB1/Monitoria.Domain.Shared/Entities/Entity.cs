﻿using Flunt.Notifications;
using System;

namespace Monitoria.Domain.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
           // Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
