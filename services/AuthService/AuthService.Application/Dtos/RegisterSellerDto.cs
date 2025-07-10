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
    public class RegisterSellerDto : IRequest<SellerResponseDto>
    {
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        public string BusinessName { get; set; } = default!;
        public string BusinessCategory { get; set; } = default!;
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
        public string? WebsiteUrl { get; set; }
        public string? BusinessDescription { get; set; }
        public IFormFile? BusinessLogoFileName { get; set; }
        public string? LanguagePreference { get; set; } = "English";
    }

}
