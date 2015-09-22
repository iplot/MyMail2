using System.Linq;
using Entities.Interfaces;

namespace Entities.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        IQueryable<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}