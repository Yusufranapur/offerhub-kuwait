using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VendorKycUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Categories_CategoryId",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorys");

            migrationBuilder.AddColumn<string>(
                name: "AuthPersonCivilIdBackUrl",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthPersonCivilIdFrontUrl",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthSignatoryCertificateUrl",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumberPdfUrl",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryNameAr",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryNameEn",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessCategoryId",
                table: "Vendors",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessType",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CivilIdNumber",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommercialLicenseUrl",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtractCommercialRegistryUrl",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IbanNumber",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LicenseExpiryDate",
                table: "Vendors",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemorandumOfAssociationUrl",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignedTermsAndConditionsUrl",
                table: "Vendors",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_BusinessCategoryId",
                table: "Vendors",
                column: "BusinessCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Categorys_CategoryId",
                table: "Offers",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Categorys_BusinessCategoryId",
                table: "Vendors",
                column: "BusinessCategoryId",
                principalTable: "Categorys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Categorys_CategoryId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Categorys_BusinessCategoryId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_BusinessCategoryId",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "AuthPersonCivilIdBackUrl",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "AuthPersonCivilIdFrontUrl",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "AuthSignatoryCertificateUrl",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BankAccountNumberPdfUrl",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BeneficiaryNameAr",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BeneficiaryNameEn",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BusinessCategoryId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "BusinessType",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CivilIdNumber",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CommercialLicenseUrl",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ExtractCommercialRegistryUrl",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "IbanNumber",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "LicenseExpiryDate",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "MemorandumOfAssociationUrl",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "SignedTermsAndConditionsUrl",
                table: "Vendors");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Categories_CategoryId",
                table: "Offers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
