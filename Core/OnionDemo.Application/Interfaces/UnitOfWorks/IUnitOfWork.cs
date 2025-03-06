using OnionDemo.Application.Interfaces.Repositories;
using OnionDemo.Domain.Common;

namespace OnionDemo.Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
    IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();

    Task<int> SaveAsync();
    int Save();
}