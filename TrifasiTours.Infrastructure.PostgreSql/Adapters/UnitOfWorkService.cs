using TrifasiTours.Domain.Ports;
using TrifasiTours.Infrastructure.PostgreSql.Persistence;
using System.Collections.Generic;

namespace TrifasiTours.Infrastructure.PostgreSql.Adapters;
internal sealed class UnitOfWorkService : IUnitOfWork
{
    private readonly Dictionary<string, object> _repositories = new();

    public UnitOfWorkService(ApplicationDbContext context) => DbContext = context ?? throw new ArgumentNullException(nameof(context));

    public ApplicationDbContext DbContext { get; }

    public async ValueTask<int> SaveChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            Type repositoryType = typeof(RepositoryBaseService<>);

            var repositoryInstance = Activator
                .CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), DbContext);

            _repositories.Add(type, repositoryInstance!);
        }

        return (IAsyncRepository<TEntity>)_repositories[type]!;
    }
}
