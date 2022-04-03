using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgressFit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ProgressFit.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Setting> AppUserSettings { get; set; }
        public virtual DbSet<DailyDiet> DailyDiets { get; set; }
        public virtual DbSet<Diet> Diets { get; set; }
        public virtual DbSet<AppUserTos> AppUserTos { get; set; }
        public virtual DbSet<Tos> Tos { get; set; }
    }
}
