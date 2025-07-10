

using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.Dtos
{
    public class RegisterBuyerDto : IRequest<BuyerResponseDto>
    {
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Phone]
        public string PhoneNumber { get; set; } = default!;
        [Required]
        [MinLength(12)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[0-9]).+$", ErrorMessage = "Password must contain at least one uppercase letter, one special character, and one number.")]
        public string Password { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string? ReferralCode { get; set; }
        public string? LanguagePreference { get; set; } = "English";
    }

}
