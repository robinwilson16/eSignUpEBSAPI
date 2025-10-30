using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSignUpEBSAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignKeyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprenticeshipEmployer_PlacedRecruitment_VacancyID",
                table: "ApprenticeshipEmployer");

            migrationBuilder.RenameColumn(
                name: "VacancyID",
                table: "ApprenticeshipEmployer",
                newName: "PlacedRecruitmentID");

            migrationBuilder.RenameIndex(
                name: "IX_ApprenticeshipEmployer_VacancyID",
                table: "ApprenticeshipEmployer",
                newName: "IX_ApprenticeshipEmployer_PlacedRecruitmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprenticeshipEmployer_PlacedRecruitment_PlacedRecruitmentID",
                table: "ApprenticeshipEmployer",
                column: "PlacedRecruitmentID",
                principalTable: "PlacedRecruitment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprenticeshipEmployer_PlacedRecruitment_PlacedRecruitmentID",
                table: "ApprenticeshipEmployer");

            migrationBuilder.RenameColumn(
                name: "PlacedRecruitmentID",
                table: "ApprenticeshipEmployer",
                newName: "VacancyID");

            migrationBuilder.RenameIndex(
                name: "IX_ApprenticeshipEmployer_PlacedRecruitmentID",
                table: "ApprenticeshipEmployer",
                newName: "IX_ApprenticeshipEmployer_VacancyID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprenticeshipEmployer_PlacedRecruitment_VacancyID",
                table: "ApprenticeshipEmployer",
                column: "VacancyID",
                principalTable: "PlacedRecruitment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
