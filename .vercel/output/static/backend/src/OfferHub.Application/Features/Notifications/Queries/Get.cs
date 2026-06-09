using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Notifications.Queries;

public record GetNotificationsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<Result<PaginatedList<NotificationDto>>>;

public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, Result<PaginatedList<NotificationDto>>>
{
    public Task<Result<PaginatedList<NotificationDto>>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
    {
        var list = new List<NotificationDto>();
        return Task.FromResult(Result<PaginatedList<NotificationDto>>.Success(new PaginatedList<NotificationDto>(list, 0, request.PageNumber, request.PageSize)));
    }
}
