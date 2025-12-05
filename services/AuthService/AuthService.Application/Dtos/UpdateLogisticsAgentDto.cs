using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Common.Shared.Validators;

namespace AuthService.Application.Dtos
{
    public class UpdateLogisticsAgentDto : IRequest<LogisticsResponseDto>
    {
       
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }

        public List<string>? RegionsCovered { get; set; }
        public List<string>? DeliverySpecializations { get; set; }

        public string? LogisticsWebsite { get; set; }
        public string? LogisticsDescription { get; set; }

        [AllowedExtensions([".pdf", ".jpg", ".png"], 204800)]
        public IFormFile? LogisticsLogoFile { get; set; }

       public string? LanguagePreference { get; set; }
    }
}
