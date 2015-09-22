using System.Data.Entity;

namespace Entities.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(IDbContextFactory contextFactory)
        {
            _context = contextFactory.Context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}