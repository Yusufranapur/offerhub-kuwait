using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OfferHub.Application.Common.Models;

namespace OfferHub.Application.Features.Auth.Commands;

public record SendOtpCommand(string PhoneNumber) : IRequest<Result>;

public class SendOtpCommandValidator : AbstractValidator<SendOtpCommand>
{
    public SendOtpCommandValidator()
    {
        RuleFor(v => v.PhoneNumber).NotEmpty();
    }
}

public class SendOtpCommandHandler : IRequestHandler<SendOtpCommand, Result>
{
    private readonly OfferHub.Application.Common.Interfaces.ISmsService _smsService;

    public SendOtpCommandHandler(OfferHub.Application.Common.Interfaces.ISmsService smsService)
    {
        _smsService = smsService;
    }

    public async Task<Result> Handle(SendOtpCommand request, CancellationToken cancellationToken)
    {
        // Generate a 6-digit random OTP
        var otp = new Random().Next(100000, 999999).ToString();
        var message = $"Your OfferHub verification code is: {otp}";

        // Send SMS
        await _smsService.SendSmsAsync(request.PhoneNumber, message, cancellationToken);

        // In a real scenario, you'd save this OTP to the database or cache with an expiration time
        return Result.Success();
    }
}
