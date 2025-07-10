
using Unifrik.Domain.Shared.Enums;

namespace AuthService.Application.Dtos
{
    public class LogisticsResponseDto : UserDto
    {
        public string? CompanyName { get; set; }
        public List<string>? RegionsCovered { get; set; }
        public List<string>? DeliverySpecializations { get; set; }
        public string? LogisticsWebsite { get; set; }
        public string? LogisticsDescription { get; set; }
        public string? LogisticsLogoFileName { get; set; }

        public bool HasVerifiedIdBadge { get; set; }
        public bool HasVerifiedBusinessBadge { get; set; }
        public bool HasTopLogisticsProviderBadge { get; set; }
        public KycStatus KycStatus { get; set; }

        public string? PassportPhotoPath { get; set; }
        public string? GovernmentIdPath { get; set; }
        public string? BusinessLicensePath { get; set; }

        public DateTime? CreatedAt { get; set; }
    }

}
