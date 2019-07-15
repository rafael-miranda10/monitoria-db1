using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.Shared.Interfaces.UoW;

namespace Monitoria.Infra.Data.UoW
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}

