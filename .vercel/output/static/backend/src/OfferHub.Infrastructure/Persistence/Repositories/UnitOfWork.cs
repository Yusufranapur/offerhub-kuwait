using OfferHub.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OfferHub.Infrastructure.Persistence.Repositories;

public class UnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}