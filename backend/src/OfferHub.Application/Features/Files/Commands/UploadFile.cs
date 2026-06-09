using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Interfaces;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Files.Commands;

public record UploadFileCommand(Stream FileStream, string FileName, string ContentType) : IRequest<Result<string>>;

public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
{
    public UploadFileCommandValidator()
    {
        RuleFor(v => v.FileStream).NotNull();
        RuleFor(v => v.FileName).NotEmpty();
        RuleFor(v => v.ContentType).NotEmpty();
    }
}

public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Result<string>>
{
    private readonly IFileStorageService _fileStorageService;

    public UploadFileCommandHandler(IFileStorageService fileStorageService)
    {
        _fileStorageService = fileStorageService;
    }

    public async Task<Result<string>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var fileUrl = await _fileStorageService.UploadFileAsync(request.FileStream, request.FileName, request.ContentType, cancellationToken);
        return Result<string>.Success(fileUrl);
    }
}
