using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressFit.Data.Migrations
{
    /// <inheritdoc />
    public partial class SessionEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Exercises_ExerciseId",
                table: "Sets");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "Sets",
                newName: "SessionExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_Sets_ExerciseId",
                table: "Sets",
                newName: "IX_Sets_SessionExerciseId");

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Sets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoutineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExercisesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionExercises_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionExercises_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionExercises_ExercisesId",
                table: "SessionExercises",
                column: "ExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionExercises_SessionId",
                table: "SessionExercises",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RoutineId",
                table: "Sessions",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_WorkoutId",
                table: "Sessions",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_SessionExercises_SessionExerciseId",
                table: "Sets",
                column: "SessionExerciseId",
                principalTable: "SessionExercises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_SessionExercises_SessionExerciseId",
                table: "Sets");

            migrationBuilder.DropTable(
                name: "SessionExercises");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Sets");

            migrationBuilder.RenameColumn(
                name: "SessionExerciseId",
                table: "Sets",
                newName: "ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_Sets_SessionExerciseId",
                table: "Sets",
                newName: "IX_Sets_ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Exercises_ExerciseId",
                table: "Sets",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
