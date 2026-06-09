using OfferHub.Domain.Common;
using OfferHub.Domain.Enums;
using OfferHub.Domain.ValueObjects;

namespace OfferHub.Domain.Entities;

public class Offer : AuditableEntity
{
    public Guid VendorId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Title { get; private set; } = null!;
    public string TitleAr { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string DescriptionAr { get; private set; } = null!;
    public DiscountType DiscountType { get; private set; }
    public decimal DiscountValue { get; private set; }
    public DateTimeOffset StartDate { get; private set; }
    public DateTimeOffset EndDate { get; private set; }
    public OfferStatus Status { get; private set; }
    public int MaxClaims { get; private set; }
    public int CurrentClaims { get; private set; }

    public Vendor? Vendor { get; private set; }
    public Category? Category { get; private set; }

    private readonly List<OfferImage> _images = new();
    public IReadOnlyCollection<OfferImage> Images => _images.AsReadOnly();

    private readonly List<OfferBranch> _offerBranches = new();
    public IReadOnlyCollection<OfferBranch> OfferBranches => _offerBranches.AsReadOnly();

    private readonly List<OfferClaim> _claims = new();
    public IReadOnlyCollection<OfferClaim> Claims => _claims.AsReadOnly();

    protected Offer() { }

    public static Offer Create(Guid vendorId, Guid categoryId, string title, string titleAr, string description, string descriptionAr, DiscountType discountType, decimal discountValue, DateTimeOffset startDate, DateTimeOffset endDate, int maxClaims)
    {
        return new Offer
        {
            VendorId = vendorId,
            CategoryId = categoryId,
            Title = title,
            TitleAr = titleAr,
            Description = description,
            DescriptionAr = descriptionAr,
            DiscountType = discountType,
            DiscountValue = discountValue,
            StartDate = startDate,
            EndDate = endDate,
            MaxClaims = maxClaims,
            CurrentClaims = 0,
            Status = OfferStatus.Draft
        };
    }
}
