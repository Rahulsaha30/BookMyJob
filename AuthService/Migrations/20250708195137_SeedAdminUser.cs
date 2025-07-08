using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthService.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AadhaarNumber", "AlternateMobile", "College", "CurrentAddress", "DateOfBirth", "Email", "FathersMobile", "FathersName", "FullName", "Gender", "IsProfileComplete", "MothersMobile", "MothersName", "Nationality", "PancardNumber", "PassportNumber", "Password", "PermanentAddress", "RegulationDocumentLink", "Role", "RollNumber", "WhatsappNumber" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "", "", "", "", null, "admin@bookmyjob.com", "", "", "Admin User", "", false, "", "", "", "", "", "6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=", "", "", "Admin", 0, "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));
        }
    }
}
