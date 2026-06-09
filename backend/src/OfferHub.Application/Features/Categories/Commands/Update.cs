using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Categories.Commands;

public record UpdateCategoryCommand(Guid Id, string Name, string NameAr, string IconUrl) : IRequest<Result>;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
        RuleFor(v => v.Name).NotEmpty();
    }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
{
    public Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
