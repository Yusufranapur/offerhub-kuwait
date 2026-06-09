using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class Category : AuditableEntity
{
    public string Name { get; private set; } = null!;
    public string NameAr { get; private set; } = null!;
    public string? IconUrl { get; private set; }
    public int DisplayOrder { get; private set; }
    public bool IsActive { get; private set; }

    private readonly List<Offer> _offers = new();
    public IReadOnlyCollection<Offer> Offers => _offers.AsReadOnly();

    protected Category() { }

    public static Category Create(string name, string nameAr, string? iconUrl, int displayOrder)
    {
        return new Category
        {
            Name = name,
            NameAr = nameAr,
            IconUrl = iconUrl,
            DisplayOrder = displayOrder,
            IsActive = true
        };
    }
}
