using Microsoft.EntityFrameworkCore;
using ProgressFit.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Data.Repositories
{
    public class RefreshTokenRepository:GenericRepository<RefreshToken>
    {
        public RefreshTokenRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<RefreshToken> Get(string token)
        {
            var result = await _context.Set<RefreshToken>().FirstOrDefaultAsync(l => l.Token == token);
            return result;
        }
    }
}
