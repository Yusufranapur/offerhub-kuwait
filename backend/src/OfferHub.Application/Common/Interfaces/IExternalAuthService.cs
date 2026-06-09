using System.Threading;
using System.Threading.Tasks;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Common.Interfaces;

public interface IExternalAuthService
{
    Task<ExternalAuthResult> VerifyGoogleTokenAsync(string idToken, CancellationToken cancellationToken = default);
    Task<ExternalAuthResult> VerifyAppleTokenAsync(string identityToken, CancellationToken cancellationToken = default);
}
