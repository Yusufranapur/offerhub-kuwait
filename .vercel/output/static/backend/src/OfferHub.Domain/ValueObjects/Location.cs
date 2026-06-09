using OfferHub.Domain.Common;
using OfferHub.Domain.Exceptions;

namespace OfferHub.Domain.ValueObjects;

public class Location : ValueObject
{
    public double Latitude { get; }
    public double Longitude { get; }

    private Location() { }

    private Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(double latitude, double longitude)
    {
        if (latitude < -90 || latitude > 90)
        {
            throw new BusinessRuleException("Latitude must be between -90 and 90.");
        }

        if (longitude < -180 || longitude > 180)
        {
            throw new BusinessRuleException("Longitude must be between -180 and 180.");
        }

        return new Location(latitude, longitude);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Latitude;
        yield return Longitude;
    }
}
