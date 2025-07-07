using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unifrik.Infrastructure.Shared.Configuration.Models
{
    public class JwtSettings
    {
        public string? IssuerSigningKey { get; set; }
        public string? ValidIssuer { get; set; }
        public string? ValidAudience { get; set; }
    }
}
