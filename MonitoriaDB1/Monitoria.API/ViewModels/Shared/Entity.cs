using Flunt.Notifications;
using System;

namespace Monitoria.API.ViewModels.Shared
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
        }

        public Guid Id { get; private set; }

        public void NewIdEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
