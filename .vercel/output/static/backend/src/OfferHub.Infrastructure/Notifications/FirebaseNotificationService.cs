using System.Threading.Tasks;

namespace OfferHub.Infrastructure.Notifications;

public class FirebaseNotificationService
{
    public async Task SendNotificationAsync(string deviceToken, string title, string body)
    {
        // Firebase Admin SDK logic to send push notification
        await Task.CompletedTask;
    }
}