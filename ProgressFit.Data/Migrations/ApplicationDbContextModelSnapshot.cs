﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgressFit.Data;

#nullable disable

namespace ProgressFit.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProgressFit.Shared.Entities.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FunctionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Function", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Muscle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FunctionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.ToTable("Muscles");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.MuscleWorkRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MuscleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkRateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("MuscleId");

                    b.HasIndex("WorkRateId");

                    b.ToTable("MuscleWorkRates");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Routine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Routines");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.WorkRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("WorkRates");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoutineId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoutineId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Exercise", b =>
                {
                    b.HasOne("ProgressFit.Shared.Entities.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgressFit.Shared.Entities.Workout", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId");

                    b.Navigation("Function");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Muscle", b =>
                {
                    b.HasOne("ProgressFit.Shared.Entities.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.MuscleWorkRate", b =>
                {
                    b.HasOne("ProgressFit.Shared.Entities.Exercise", null)
                        .WithMany("MuscleWorkRates")
                        .HasForeignKey("ExerciseId");

                    b.HasOne("ProgressFit.Shared.Entities.Muscle", "Muscle")
                        .WithMany()
                        .HasForeignKey("MuscleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgressFit.Shared.Entities.WorkRate", "WorkRate")
                        .WithMany()
                        .HasForeignKey("WorkRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Muscle");

                    b.Navigation("WorkRate");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Set", b =>
                {
                    b.HasOne("ProgressFit.Shared.Entities.Exercise", null)
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Workout", b =>
                {
                    b.HasOne("ProgressFit.Shared.Entities.Routine", null)
                        .WithMany("Workouts")
                        .HasForeignKey("RoutineId");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Exercise", b =>
                {
                    b.Navigation("MuscleWorkRates");

                    b.Navigation("Sets");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Routine", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("ProgressFit.Shared.Entities.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
