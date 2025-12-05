using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Dtos
{
    public class UpdateBuyerDto : IRequest<BuyerResponseDto>
    {
      
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? LanguagePreference { get; set; }
        public string? ReferralCode { get; set; }
    }
}
