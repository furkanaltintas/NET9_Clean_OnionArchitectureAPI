using OnionDemo.Application.Interfaces.Repositories;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Persistence.Context;
using OnionDemo.Persistence.Repositories;

namespace OnionDemo.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext) { _dbContext = dbContext; }

    public ValueTask DisposeAsync() => _dbContext.DisposeAsync();

    public int Save() => _dbContext.SaveChanges();
    public Task<int> SaveAsync() => _dbContext.SaveChangesAsync();

    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);
}