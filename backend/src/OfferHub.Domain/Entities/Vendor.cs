using OfferHub.Domain.Common;
using OfferHub.Domain.Enums;
using OfferHub.Domain.ValueObjects;
using OfferHub.Domain.Events;

namespace OfferHub.Domain.Entities;

public class Vendor : AuditableEntity
{
    public string Name { get; private set; } = null!;
    public string NameAr { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string DescriptionAr { get; private set; } = null!;
    public string? LogoUrl { get; private set; }
    public string? CommercialRegistrationNo { get; private set; }
    public VendorStatus Status { get; private set; }
    public Email ContactEmail { get; private set; } = null!;
    public string ContactPhone { get; private set; } = null!;

    private readonly List<Branch> _branches = new();
    public IReadOnlyCollection<Branch> Branches => _branches.AsReadOnly();

    private readonly List<Offer> _offers = new();
    public IReadOnlyCollection<Offer> Offers => _offers.AsReadOnly();

    private readonly List<VendorStaff> _staff = new();
    public IReadOnlyCollection<VendorStaff> Staff => _staff.AsReadOnly();

    protected Vendor() { }

    public static Vendor Create(string name, string nameAr, string description, string descriptionAr, Email contactEmail, string contactPhone, string? commercialRegistrationNo)
    {
        var vendor = new Vendor
        {
            Name = name,
            NameAr = nameAr,
            Description = description,
            DescriptionAr = descriptionAr,
            ContactEmail = contactEmail,
            ContactPhone = contactPhone,
            CommercialRegistrationNo = commercialRegistrationNo,
            Status = VendorStatus.Pending
        };

        vendor.AddDomainEvent(new VendorRegisteredEvent(vendor.Id));

        return vendor;
    }

    public void Approve()
    {
        if (Status != VendorStatus.Pending) return;

        Status = VendorStatus.Active;
        AddDomainEvent(new VendorApprovedEvent(Id));
    }
}
