using System.Threading.Tasks;

namespace OfferHub.Infrastructure.Payments;

public class UPaymentService
{
    public async Task<string> CreatePaymentLinkAsync(decimal amount, string orderId)
    {
        // UPayment integration logic
        await Task.CompletedTask;
        return $"https://upayment.example.com/pay/{orderId}";
    }
}