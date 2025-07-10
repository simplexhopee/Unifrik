using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Dtos
{
    public class RegisterLogisticsAgentDto : IRequest<LogisticsResponseDto>
    {
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        public string CompanyName { get; set; } = default!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        [MinLength(12)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[0-9]).+$", ErrorMessage = "Password must contain at least one uppercase letter, one special character, and one number.")]
        public string Password { get; set; } = default!;
        [Phone]
        public string PhoneNumber { get; set; } = default!;
        public string Country { get; set; } = default!;
        public List<string> RegionsCovered { get; set; } = new();
        public List<string> DeliverySpecializations { get; set; } = new();
        public string? LogisticsWebsite { get; set; }
        public string? LogisticsDescription { get; set; }
        public IFormFile? LogisticsLogoFileName { get; set; }
        public string? LanguagePreference { get; set; }

        public IFormFile? IdDocumentPath { get; set; }
        public IFormFile? LicenseDocumentPath { get; set; }
        public IFormFile? ProofOfAddressPath { get; set; }
    }

}
