using TrifasiTours.Domain.Ports;
using TrifasiTours.Infrastructure.PostgreSql.Persistence;
<<<<<<< HEAD
using System.Collections;

namespace TrifasiTours.Infrastructure.PostgreSql.Adapters;
internal sealed record class UnitOfWorkService : IUnitOfWork {
    private Hashtable? _repositories;

    public UnitOfWorkService( ApplicationDbContext context ) => DbContext = context;

    public ApplicationDbContext DbContext { get; }

    public async ValueTask<int> SaveChangesAsync() {
           var test =  await DbContext.SaveChangesAsync(new CancellationToken());
        return test;
    }

    public void Dispose() {
        DbContext.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class {
        _repositories ??= [];
        var type = typeof( TEntity ).Name;

        if (!_repositories.ContainsKey( type )) {
            Type reporitoryType = typeof( RepositoryBaseService<> );

            var repositoryInstance = Activator
                .CreateInstance( reporitoryType.MakeGenericType( typeof( TEntity ) ), DbContext );

            _repositories.Add( type, repositoryInstance );
=======
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
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
        }

        return (IAsyncRepository<TEntity>)_repositories[type]!;
    }
}
