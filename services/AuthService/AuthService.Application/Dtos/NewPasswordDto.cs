using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Dtos
{
    public class NewPasswordDto : IRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        [MinLength(12)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*[0-9]).+$", ErrorMessage = "Password must contain at least one uppercase letter, one special character, and one number.")]
        public string Password { get; set; } = default!;
        [Required]
        public string Token { get; set; } = default!;
    }
}
