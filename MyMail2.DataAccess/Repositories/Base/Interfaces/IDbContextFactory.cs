using System.Data.Entity;

namespace Entities.Repositories
{
    public interface IDbContextFactory
    {
        DbContext Context { get; }
    }
}