using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Domain.Shared.Enums;

namespace AuthService.Application.Dtos
{
    public class BuyerResponseDto : UserDto
    {
       

        public string? ReferralCode { get; set; }

        public bool HasVerifiedIdBadge { get; set; }
        public KycStatus KycStatus { get; set; }

        public string? PassportPhotoPath { get; set; }
        public string? GovernmentIdPath { get; set; }

        public DateTime? CreatedAt { get; set; }
    }

}
