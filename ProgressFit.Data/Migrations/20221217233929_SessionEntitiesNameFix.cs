using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressFit.Data.Migrations
{
    /// <inheritdoc />
    public partial class SessionEntitiesNameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionExercises_Exercises_ExercisesId",
                table: "SessionExercises");

            migrationBuilder.RenameColumn(
                name: "ExercisesId",
                table: "SessionExercises",
                newName: "ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionExercises_ExercisesId",
                table: "SessionExercises",
                newName: "IX_SessionExercises_ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionExercises_Exercises_ExerciseId",
                table: "SessionExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionExercises_Exercises_ExerciseId",
                table: "SessionExercises");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "SessionExercises",
                newName: "ExercisesId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionExercises_ExerciseId",
                table: "SessionExercises",
                newName: "IX_SessionExercises_ExercisesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionExercises_Exercises_ExercisesId",
                table: "SessionExercises",
                column: "ExercisesId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
