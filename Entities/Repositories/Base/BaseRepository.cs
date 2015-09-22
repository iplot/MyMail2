using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Entities.Interfaces;

namespace Entities.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private DbContext _context;

//        protected BaseRepository(DbContext context)
//        {
//            _context = context;
//        }

        public DbContext Context { set { _context = value; } }

        public T Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }
    }
}