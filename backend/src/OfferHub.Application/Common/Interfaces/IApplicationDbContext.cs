using System.Threading;
using System.Threading.Tasks;

namespace OfferHub.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    Microsoft.EntityFrameworkCore.DbSet<OfferHub.Domain.Entities.User> Users { get; }
    Microsoft.EntityFrameworkCore.DbSet<OfferHub.Domain.Entities.Offer> Offers { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
