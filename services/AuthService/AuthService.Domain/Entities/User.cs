using Microsoft.AspNetCore.Identity;
using Unifrik.Domain.Shared.Entities;
using Unifrik.Domain.Shared.Enums;

namespace AuthService.Domain.Entities
{
    public class User : IdentityUser, IAuditable
    {
        // Common Fields
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string? LanguagePreference { get; set; }
       
        public UserTypeEnum UserType { get; set; }

        // Buyer-Specific
        public string? ReferralCode { get; set; }

        // Seller-Specific
        public string? BusinessName { get; set; }
        public string? BusinessCategory { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? BusinessDescription { get; set; }
        public string? BusinessLogoFileName { get; set; }

        // Logistics-Specific
        public string? CompanyName { get; set; }
        public List<string>? RegionsCovered { get; set; }
        public List<string>? DeliverySpecializations { get; set; }
        public string? LogisticsWebsite { get; set; }
        public string? LogisticsDescription { get; set; }
        public string? LogisticsLogoFileName { get; set; }

        // Uploads
        public string? IdDocumentPath { get; set; }
        public string? LicenseDocumentPath { get; set; }
        public string? ProofOfAddressPath { get; set; }

        public KycStatus KycStatus { get; set; } = KycStatus.Pending;

        // Upload paths or blob keys
        public string? GovernmentIdPath { get; set; }         // All users
        public string? PassportPhotoPath { get; set; }        // All users
        public string? BusinessLicensePath { get; set; }      // Seller/Logistics only

        public DateTime? KycSubmittedAt { get; set; }
        public DateTime? KycReviewedAt { get; set; }

        public bool KycApproved { get; set; } = false;
        public string? KycReviewerId { get; set; }            // For audit trail
        public string? KycRejectionReason { get; set; }

        // ===== Badge Logic =====

        public bool HasVerifiedIdBadge { get; set; } = false;
        public bool HasVerifiedBusinessBadge { get; set; } = false;
        public bool HasTrustedTraderBadge { get; set; } = false;
        public bool HasTopLogisticsProviderBadge { get; set; } = false;

        public DateTime? VerifiedIdAt { get; set; }
        public DateTime? VerifiedBusinessAt { get; set; }
        public DateTime? TrustedTraderAssignedAt { get; set; }
        public DateTime? TopLogisticsAssignedAt { get; set; }

        // Metadata
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
    }

}
