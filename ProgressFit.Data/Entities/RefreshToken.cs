using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressFit.Data.Entities
{
    public class RefreshToken
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public bool Revoked { get; set; }
    }
}
