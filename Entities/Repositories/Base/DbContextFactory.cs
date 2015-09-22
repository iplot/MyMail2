using System.Data.Entity;

namespace Entities.Repositories
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;

        public DbContextFactory(DbContext context)
        {
            _context = context;
        }

        public DbContext Context
        {
            get { return _context ?? new MyMailDataContext(); }
        }
    }
}