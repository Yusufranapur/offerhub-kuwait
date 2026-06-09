using OfferHub.Domain.Common;

namespace OfferHub.Domain.Entities;

public class CmsContent : AuditableEntity
{
    public string Key { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public string ContentAr { get; private set; } = null!;

    protected CmsContent() { }

    public static CmsContent Create(string key, string content, string contentAr)
    {
        return new CmsContent
        {
            Key = key,
            Content = content,
            ContentAr = contentAr
        };
    }
}
