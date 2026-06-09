using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Auth.Queries;

public record GetCurrentUserQuery() : IRequest<Result<UserDto>>;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, Result<UserDto>>
{
    public Task<Result<UserDto>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<UserDto>.Success(new UserDto(Guid.NewGuid(), "Test User", "test@test.com", null, null, null, "Local", "Active", DateTimeOffset.UtcNow)));
    }
}

