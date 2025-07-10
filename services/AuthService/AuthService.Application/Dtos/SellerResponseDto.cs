using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Domain.Shared.Enums;

namespace AuthService.Application.Dtos
{
    public class SellerResponseDto : UserDto
    {
        public string? BusinessName { get; set; }
        public string? BusinessCategory { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? BusinessDescription { get; set; }
        public string? BusinessLogoFileName { get; set; }

        public bool HasVerifiedIdBadge { get; set; }
        public bool HasVerifiedBusinessBadge { get; set; }
        public KycStatus KycStatus { get; set; }

        public string? PassportPhotoPath { get; set; }
        public string? GovernmentIdPath { get; set; }
        public string? BusinessLicensePath { get; set; }

        public DateTime? CreatedAt { get; set; }
    }

}
