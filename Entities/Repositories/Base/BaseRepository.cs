using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private DbContext _context;

        protected BaseRepository(IDbContextFactory contextFactory)
        {
            _context = contextFactory.Context;
        }

        public DbContext Context { set { _context = value; } }

        public T Get(int id)
        {
            try
            {
                return _context.Set<T>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(T item)
        {
            try
            {
                _context.Set<T>().Add(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(T item)
        {
            try
            {
                _context.Set<T>().Remove(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}