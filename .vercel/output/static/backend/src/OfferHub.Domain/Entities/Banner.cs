using OfferHub.Domain.Common;
using OfferHub.Domain.Enums;

namespace OfferHub.Domain.Entities;

public class Banner : AuditableEntity
{
    public string Title { get; private set; } = null!;
    public string TitleAr { get; private set; } = null!;
    public string ImageUrl { get; private set; } = null!;
    public string? LinkUrl { get; private set; }
    public BannerType Type { get; private set; }
    public int DisplayOrder { get; private set; }
    public bool IsActive { get; private set; }
    public DateTimeOffset? StartDate { get; private set; }
    public DateTimeOffset? EndDate { get; private set; }

    protected Banner() { }

    public static Banner Create(string title, string titleAr, string imageUrl, string? linkUrl, BannerType type, int displayOrder, DateTimeOffset? startDate, DateTimeOffset? endDate)
    {
        return new Banner
        {
            Title = title,
            TitleAr = titleAr,
            ImageUrl = imageUrl,
            LinkUrl = linkUrl,
            Type = type,
            DisplayOrder = displayOrder,
            StartDate = startDate,
            EndDate = endDate,
            IsActive = true
        };
    }
}
