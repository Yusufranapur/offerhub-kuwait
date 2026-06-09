using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OfferHub.Application.Common.Interfaces;

public interface INotificationService
{
    Task SendNotificationAsync(Guid userId, string title, string body, Dictionary<string, string>? data = null, CancellationToken cancellationToken = default);
    Task BroadcastNotificationAsync(string title, string body, Dictionary<string, string>? data = null, CancellationToken cancellationToken = default);
}
