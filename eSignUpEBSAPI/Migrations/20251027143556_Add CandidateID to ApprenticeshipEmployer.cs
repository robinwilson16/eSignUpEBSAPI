using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSignUpEBSAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCandidateIDtoApprenticeshipEmployer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateID",
                table: "ApprenticeshipEmployer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApprenticeshipEmployer_CandidateID",
                table: "ApprenticeshipEmployer",
                column: "CandidateID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprenticeshipEmployer_Candidate_CandidateID",
                table: "ApprenticeshipEmployer",
                column: "CandidateID",
                principalTable: "Candidate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprenticeshipEmployer_Candidate_CandidateID",
                table: "ApprenticeshipEmployer");

            migrationBuilder.DropIndex(
                name: "IX_ApprenticeshipEmployer_CandidateID",
                table: "ApprenticeshipEmployer");

            migrationBuilder.DropColumn(
                name: "CandidateID",
                table: "ApprenticeshipEmployer");
        }
    }
}
