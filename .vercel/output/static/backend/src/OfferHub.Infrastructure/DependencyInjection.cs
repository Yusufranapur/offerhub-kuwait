using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfferHub.Infrastructure.Persistence;
using OfferHub.Infrastructure.Persistence.Interceptors;
using OfferHub.Infrastructure.Persistence.Repositories;
using OfferHub.Infrastructure.Identity;
using OfferHub.Infrastructure.Caching;
using OfferHub.Infrastructure.Storage;
using OfferHub.Infrastructure.Notifications;
using OfferHub.Infrastructure.Payments;
using OfferHub.Infrastructure.Sms;
using OfferHub.Infrastructure.ExternalAuth;
using Amazon.S3;

namespace OfferHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntityInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var interceptor = sp.GetRequiredService<AuditableEntityInterceptor>();
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                   .AddInterceptors(interceptor);
        });

        services.AddScoped<UnitOfWork>();
        services.AddScoped(typeof(GenericRepository<>));

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
        });

        services.AddSingleton<RedisCacheService>();
        services.AddTransient<TokenService>();
        services.AddTransient<CurrentUserService>();
        services.AddTransient<PasswordHasher>();

        services.AddAWSService<IAmazonS3>();
        services.AddTransient<S3FileStorageService>();

        services.AddTransient<FirebaseNotificationService>();
        services.AddTransient<UPaymentService>();
        services.AddHttpClient<OfferHub.Application.Common.Interfaces.ISmsService, SmsAlaService>();
        services.AddTransient<GoogleAuthService>();
        services.AddTransient<AppleAuthService>();

        return services;
    }
}