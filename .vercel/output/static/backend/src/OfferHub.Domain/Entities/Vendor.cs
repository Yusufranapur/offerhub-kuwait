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
    
    // Merchant Details
    public Guid? BusinessCategoryId { get; private set; }
    public Category? BusinessCategory { get; private set; }
    public string? BusinessType { get; private set; }
    public string? CivilIdNumber { get; private set; }

    // Legal Documents
    public string? CommercialRegistrationNo { get; private set; }
    public string? AuthPersonCivilIdFrontUrl { get; private set; }
    public string? AuthPersonCivilIdBackUrl { get; private set; }
    public string? MemorandumOfAssociationUrl { get; private set; }
    public string? CommercialLicenseUrl { get; private set; }
    public DateTime? LicenseExpiryDate { get; private set; }
    public string? ExtractCommercialRegistryUrl { get; private set; }
    public string? AuthSignatoryCertificateUrl { get; private set; }
    public string? SignedTermsAndConditionsUrl { get; private set; }

    // Bank Details
    public string? BeneficiaryNameEn { get; private set; }
    public string? BeneficiaryNameAr { get; private set; }
    public string? BankName { get; private set; }
    public string? IbanNumber { get; private set; }
    public string? BankAccountNumberPdfUrl { get; private set; }

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

    public static Vendor Create(string name, string nameAr, string description, string descriptionAr, Email contactEmail, string contactPhone)
    {
        var vendor = new Vendor
        {
            Name = name,
            NameAr = nameAr,
            Description = description,
            DescriptionAr = descriptionAr,
            ContactEmail = contactEmail,
            ContactPhone = contactPhone,
            Status = VendorStatus.Pending
        };

        vendor.AddDomainEvent(new VendorRegisteredEvent(vendor.Id));

        return vendor;
    }

    public void UpdateMerchantDetails(Guid? categoryId, string? businessType, string? civilId, string? commercialRegNo, DateTime? licenseExpiry)
    {
        BusinessCategoryId = categoryId;
        BusinessType = businessType;
        CivilIdNumber = civilId;
        CommercialRegistrationNo = commercialRegNo;
        LicenseExpiryDate = licenseExpiry;
    }

    public void UpdateBankDetails(string? beneficiaryEn, string? beneficiaryAr, string? bankName, string? iban)
    {
        BeneficiaryNameEn = beneficiaryEn;
        BeneficiaryNameAr = beneficiaryAr;
        BankName = bankName;
        IbanNumber = iban;
    }

    public void UpdateDocumentUrl(string documentType, string url)
    {
        switch (documentType)
        {
            case "Logo": LogoUrl = url; break;
            case "AuthPersonCivilIdFront": AuthPersonCivilIdFrontUrl = url; break;
            case "AuthPersonCivilIdBack": AuthPersonCivilIdBackUrl = url; break;
            case "MemorandumOfAssociation": MemorandumOfAssociationUrl = url; break;
            case "CommercialLicense": CommercialLicenseUrl = url; break;
            case "ExtractCommercialRegistry": ExtractCommercialRegistryUrl = url; break;
            case "AuthSignatoryCertificate": AuthSignatoryCertificateUrl = url; break;
            case "SignedTermsAndConditions": SignedTermsAndConditionsUrl = url; break;
            case "BankAccountNumberPdf": BankAccountNumberPdfUrl = url; break;
        }
    }

    public void Approve()
    {
        if (Status != VendorStatus.Pending) return;

        Status = VendorStatus.Active;
        AddDomainEvent(new VendorApprovedEvent(Id));
    }
}
