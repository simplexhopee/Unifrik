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
    public class UpdateSellerDto : IRequest<SellerResponseDto>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessCategory { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? BusinessDescription { get; set; }

        [AllowedExtensions([".pdf", ".jpg", ".png"], 204800)]
        public IFormFile? BusinessLogoFile { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? LanguagePreference { get; set; }
    }

}
