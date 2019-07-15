using Microsoft.EntityFrameworkCore.Storage;

namespace Monitoria.Domain.Shared.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}
