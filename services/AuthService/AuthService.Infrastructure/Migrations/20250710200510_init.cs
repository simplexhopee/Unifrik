using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    LanguagePreference = table.Column<string>(type: "text", nullable: true),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    ReferralCode = table.Column<string>(type: "text", nullable: true),
                    BusinessName = table.Column<string>(type: "text", nullable: true),
                    BusinessCategory = table.Column<string>(type: "text", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "text", nullable: true),
                    BusinessDescription = table.Column<string>(type: "text", nullable: true),
                    BusinessLogoFileName = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    RegionsCovered = table.Column<List<string>>(type: "text[]", nullable: true),
                    DeliverySpecializations = table.Column<List<string>>(type: "text[]", nullable: true),
                    LogisticsWebsite = table.Column<string>(type: "text", nullable: true),
                    LogisticsDescription = table.Column<string>(type: "text", nullable: true),
                    LogisticsLogoFileName = table.Column<string>(type: "text", nullable: true),
                    IdDocumentPath = table.Column<string>(type: "text", nullable: true),
                    LicenseDocumentPath = table.Column<string>(type: "text", nullable: true),
                    ProofOfAddressPath = table.Column<string>(type: "text", nullable: true),
                    KycStatus = table.Column<int>(type: "integer", nullable: false),
                    GovernmentIdPath = table.Column<string>(type: "text", nullable: true),
                    PassportPhotoPath = table.Column<string>(type: "text", nullable: true),
                    BusinessLicensePath = table.Column<string>(type: "text", nullable: true),
                    KycSubmittedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    KycReviewedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    KycApproved = table.Column<bool>(type: "boolean", nullable: false),
                    KycReviewerId = table.Column<string>(type: "text", nullable: true),
                    KycRejectionReason = table.Column<string>(type: "text", nullable: true),
                    HasVerifiedIdBadge = table.Column<bool>(type: "boolean", nullable: false),
                    HasVerifiedBusinessBadge = table.Column<bool>(type: "boolean", nullable: false),
                    HasTrustedTraderBadge = table.Column<bool>(type: "boolean", nullable: false),
                    HasTopLogisticsProviderBadge = table.Column<bool>(type: "boolean", nullable: false),
                    VerifiedIdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VerifiedBusinessAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TrustedTraderAssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TopLogisticsAssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
