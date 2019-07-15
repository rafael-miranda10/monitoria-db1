using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.Shared.Interfaces.Repositories;

namespace Monitoria.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity> where TEntity : class where TContext : DbContext
    {
        private readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _context.Set<TEntity>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RemoveById(Guid id)
        {
            var result = GetById(id);

            if(result != null)
              _context.Set<TEntity>().Remove(result);
        }

        public bool ExistingEntity(TEntity obj)
        {
            var existing = GetEntityEqualTo(obj);
            return existing != null;
        }

        public TEntity ExistingReturnEntity(TEntity obj)
        {
            var existing = GetEntityEqualTo(obj);
            return existing;
        }

        private TEntity GetEntityEqualTo(TEntity obj)
        {
            var query = (from entity in _context.Set<TEntity>().AsEnumerable()
                         where entity.Equals(obj)
                         select entity).FirstOrDefault();
            return query;
        }
    }
}
