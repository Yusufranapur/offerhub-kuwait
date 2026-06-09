using System.Text.RegularExpressions;
using OfferHub.Domain.Common;
using OfferHub.Domain.Exceptions;

namespace OfferHub.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }

    private Email() { Value = null!; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new BusinessRuleException("Email cannot be empty.");
        }

        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new BusinessRuleException("Email format is invalid.");
        }

        return new Email(value.ToLowerInvariant());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
