namespace Entities.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}