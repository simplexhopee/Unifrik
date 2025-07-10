using AuthService.Application.Dtos;
using FluentValidation;
using Unifrik.Common.Shared.Utils;


namespace AuthService.Application.Validators
{
    public class RegisterBuyerValidator : AbstractValidator<RegisterBuyerDto>
    {
        public RegisterBuyerValidator() 
        {
            RuleFor(b => AllCountries.GetAllCountries.Contains(b.Country));
            RuleFor(b => Languages.Get.Contains(b.LanguagePreference));
        }

    }
}
