using BuildingBlocks.EFCore;
using OrderService.Persistence;

namespace OrderService.Persistence;

public sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly CatalogDbContext _context;
    private bool _disposed;

    public UnitOfWork(CatalogDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var affectedRows = await _context
            .SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return affectedRows;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }
}