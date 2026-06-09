using System;
using System.Threading;
using System.Threading.Tasks;

namespace OfferHub.Application.Common.Interfaces;

public interface IPaymentService
{
    Task<string> InitiatePaymentAsync(Guid userId, decimal amount, string currency, string description, CancellationToken cancellationToken = default);
    Task<bool> VerifyPaymentAsync(string paymentId, CancellationToken cancellationToken = default);
}
