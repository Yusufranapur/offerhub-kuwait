using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OfferHub.Application.Common.Interfaces;

namespace OfferHub.Infrastructure.Sms;

public class SmsAlaService : ISmsService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<SmsAlaService> _logger;

    public SmsAlaService(HttpClient httpClient, IConfiguration configuration, ILogger<SmsAlaService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task SendSmsAsync(string phoneNumber, string message, CancellationToken cancellationToken = default)
    {
        var endpoint = _configuration["SmsAla:Endpoint"];
        var apiId = _configuration["SmsAla:ApiId"];
        var apiToken = _configuration["SmsAla:ApiToken"];
        var senderId = _configuration["SmsAla:SenderId"];

        if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiToken))
        {
            _logger.LogWarning("SMSALA configuration is missing. SMS not sent.");
            return;
        }

        var payload = new
        {
            api_id = apiId,
            api_password = apiToken,
            sms_type = "T",
            encoding = "T",
            sender_id = senderId,
            phonenumber = phoneNumber,
            textmessage = message
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, payload, cancellationToken);
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
            
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("SMSALA sent successfully to {PhoneNumber}. Response: {Response}", phoneNumber, responseString);
            }
            else
            {
                _logger.LogError("SMSALA failed to send SMS to {PhoneNumber}. Status Code: {StatusCode}. Response: {Response}", phoneNumber, response.StatusCode, responseString);
            }
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Exception occurred while sending SMS via SMSALA to {PhoneNumber}", phoneNumber);
            throw;
        }
    }
}