using OfferHub.Domain.Common;
using OfferHub.Domain.ValueObjects;

namespace OfferHub.Domain.Entities;

public class Branch : AuditableEntity
{
    public Guid VendorId { get; private set; }
    public string Name { get; private set; } = null!;
    public string NameAr { get; private set; } = null!;
    public Location Location { get; private set; } = null!;
    public string Address { get; private set; } = null!;
    public string AddressAr { get; private set; } = null!;
    public string? ContactPhone { get; private set; }

    public Vendor? Vendor { get; private set; }

    protected Branch() { }

    public static Branch Create(Guid vendorId, string name, string nameAr, Location location, string address, string addressAr, string? contactPhone)
    {
        return new Branch
        {
            VendorId = vendorId,
            Name = name,
            NameAr = nameAr,
            Location = location,
            Address = address,
            AddressAr = addressAr,
            ContactPhone = contactPhone
        };
    }
}
