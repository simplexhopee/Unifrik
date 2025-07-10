

using AuthService.Application.Dtos;
using FluentValidation;
using Unifrik.Common.Shared.Utils;

namespace AuthService.Application.Validators
{
    public class RegisterLogisticsAgentValidator : AbstractValidator<RegisterLogisticsAgentDto>
    {
        public RegisterLogisticsAgentValidator()
        {
            RuleFor(x => AllCountries.GetAllCountries.Contains(x.Country));
            RuleFor(x => Languages.Get.Contains(x.LanguagePreference));
            RuleFor(x => x.DeliverySpecializations.Select(s => DeliverySpecializations.GetAll().Contains(s)));
            RuleFor(x => x.RegionsCovered.Select(r => AllCountries.GetAllRegions));
        }
    }
}
