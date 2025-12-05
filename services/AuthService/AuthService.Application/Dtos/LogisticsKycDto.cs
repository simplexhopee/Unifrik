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
    public class LogisticsKycDto : BuyerAndSellerKycDto
    {
        [Required]
        [AllowedExtensions([".pdf", ".jpg", ".png"], 204800)]
        public IFormFile BusinessLicensePath { get; set; }
    }
}
