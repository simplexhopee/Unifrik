using AuthService.Application.Dtos;
using FluentValidation;
using Unifrik.Common.Shared.Utils;

namespace AuthService.Application.Validators
{
    public class RegisterSellerValidator : AbstractValidator<RegisterSellerDto>
    {
        public RegisterSellerValidator() 
        {
            RuleFor(s => BusinessCategories.Get.Contains(s.BusinessCategory));
            RuleFor(s => AllCountries.GetAllCountries.Contains(s.Country));
            RuleFor(s => Languages.Get.Contains(s.LanguagePreference));
        }
    }
}
