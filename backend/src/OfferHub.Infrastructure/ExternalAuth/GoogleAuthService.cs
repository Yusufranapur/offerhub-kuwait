using System.Threading.Tasks;

namespace OfferHub.Infrastructure.ExternalAuth;

public class GoogleAuthService
{
    public async Task<bool> VerifyGoogleTokenAsync(string token)
    {
        // Verify Google token logic
        await Task.CompletedTask;
        return true;
    }
}