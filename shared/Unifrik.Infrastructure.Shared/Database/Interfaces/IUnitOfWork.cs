
namespace Unifrik.Infrastructure.Shared.Database.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : class;
        Task CompleteAsync();
    }
}
