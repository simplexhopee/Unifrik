using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Domain.Shared.Entities;

namespace AuthService.Domain.Entities
{
    public class RefreshToken 
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; } = DateTime.Now.AddDays(7);
        public string UserId { get; set; }

    }
}
