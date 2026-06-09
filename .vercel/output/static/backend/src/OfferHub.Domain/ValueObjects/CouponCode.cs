using OfferHub.Domain.Common;
using OfferHub.Domain.Exceptions;

namespace OfferHub.Domain.ValueObjects;

public class CouponCode : ValueObject
{
    public string Value { get; }

    private CouponCode() { Value = null!; }

    private CouponCode(string value)
    {
        Value = value;
    }

    public static CouponCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new BusinessRuleException("Coupon code cannot be empty.");
        }

        if (value.Length < 3 || value.Length > 20)
        {
            throw new BusinessRuleException("Coupon code must be between 3 and 20 characters.");
        }

        return new CouponCode(value.ToUpperInvariant());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
