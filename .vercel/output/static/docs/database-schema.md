# Database Schema

OfferHub uses PostgreSQL as its primary relational database. We utilize Entity Framework Core for ORM and migrations.

## Core Entities

### Users
Stores both Admin and Vendor users.
- `Id` (UUID, PK)
- `Email` (String, Unique)
- `PasswordHash` (String)
- `Role` (Enum: Admin, Vendor)
- `CreatedAt` (DateTime)

### Vendors
Stores details about the participating businesses.
- `Id` (UUID, PK)
- `UserId` (UUID, FK -> Users.Id)
- `CompanyName` (String)
- `CommercialRegisterNumber` (String)
- `IsApproved` (Boolean)
- `CreatedAt` (DateTime)

### Offers
Stores the actual deals and discounts.
- `Id` (UUID, PK)
- `VendorId` (UUID, FK -> Vendors.Id)
- `Title` (String)
- `Description` (Text)
- `DiscountPercentage` (Decimal)
- `StartDate` (DateTime)
- `EndDate` (DateTime)
- `Status` (Enum: Draft, Active, Expired, Rejected)
- `CreatedAt` (DateTime)

### OfferImages
Stores URLs to images associated with offers (stored in S3).
- `Id` (UUID, PK)
- `OfferId` (UUID, FK -> Offers.Id)
- `ImageUrl` (String)
- `IsPrimary` (Boolean)

## Migrations

To add a new migration locally:
```bash
dotnet ef migrations add <MigrationName> --project src/OfferHub.Infrastructure --startup-project src/OfferHub.Api
```

To apply migrations locally:
```bash
dotnet ef database update --project src/OfferHub.Infrastructure --startup-project src/OfferHub.Api
```
