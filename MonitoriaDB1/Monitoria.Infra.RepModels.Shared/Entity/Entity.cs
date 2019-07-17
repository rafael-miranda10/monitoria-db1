using System;

namespace Monitoria.Infra.RepModels.Shared.Entity
{
    public abstract class Entity 
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
