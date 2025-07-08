using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobPosting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobFunction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredSkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobPosting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPostingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalQuestions_jobPosting_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "jobPosting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EligibilityCriteria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinCGPA = table.Column<double>(type: "float", nullable: false),
                    NoBacklogsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    Batch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobPostingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibilityCriteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EligibilityCriteria_jobPosting_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "jobPosting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalQuestions_JobPostingId",
                table: "AdditionalQuestions",
                column: "JobPostingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EligibilityCriteria_JobPostingId",
                table: "EligibilityCriteria",
                column: "JobPostingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalQuestions");

            migrationBuilder.DropTable(
                name: "EligibilityCriteria");

            migrationBuilder.DropTable(
                name: "jobPosting");
        }
    }
}
