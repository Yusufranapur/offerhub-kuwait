using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class VendorStaff : AuditableEntity
{
    public Guid VendorId { get; private set; }
    public Guid UserId { get; private set; }
    public bool IsAdmin { get; private set; }

    public Vendor? Vendor { get; private set; }
    public User? User { get; private set; }

    protected VendorStaff() { }

    public static VendorStaff Create(Guid vendorId, Guid userId, bool isAdmin)
    {
        return new VendorStaff
        {
            VendorId = vendorId,
            UserId = userId,
            IsAdmin = isAdmin
        };
    }
}
