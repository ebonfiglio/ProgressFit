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

        public virtual DbSet<Routine> Routines { get; set; }

        public virtual DbSet<Workout> Workouts { get; set; }

        public virtual DbSet<Exercise> Exercises { get; set; }

        public virtual DbSet<Set> Sets { get; set; }

        public virtual DbSet<Muscle> Muscles { get; set; }

        public virtual DbSet<WorkRate> WorkRates { get; set; }

        public virtual DbSet<Function> Functions { get; set; }

        public virtual DbSet<MuscleWorkRate> MuscleWorkRates { get; set; }
    }
}
