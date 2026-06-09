using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Branches.Commands;

public record DeleteBranchCommand(Guid Id) : IRequest<Result>;

public class DeleteBranchCommandValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeleteBranchCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Result>
{
    public Task<Result> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
