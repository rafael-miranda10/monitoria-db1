using System;
using System.Collections.Generic;

namespace Monitoria.Domain.Shared.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void RemoveById(Guid id);
        bool ExistingEntity(TEntity obj);
        TEntity GetEntityEqualTo(TEntity obj);
    }
}
