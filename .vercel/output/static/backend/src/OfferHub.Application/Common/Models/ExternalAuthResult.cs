namespace OfferHub.Application.Common.Models;

public class ExternalAuthResult
{
    public bool IsValid { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ExternalId { get; set; }
    public string? ErrorMessage { get; set; }
}
