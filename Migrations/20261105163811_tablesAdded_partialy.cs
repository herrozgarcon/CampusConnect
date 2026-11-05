using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusConnect.Migrations
{
    /// <inheritdoc />
    public partial class tablesAdded_partialy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyHRs",
                columns: table => new
                {
                    CompanyHRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyHRs", x => x.CompanyHRId);
                    table.ForeignKey(
                        name: "FK_CompanyHRs_ApplicationUsers_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "ApplicationUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyHRs_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyHRs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlacementOfficers",
                columns: table => new
                {
                    PlacementOfficerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementOfficers", x => x.PlacementOfficerId);
                    table.ForeignKey(
                        name: "FK_PlacementOfficers_ApplicationUsers_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "ApplicationUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlacementOfficers_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlacementOfficers_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    PlacementOfficerId = table.Column<int>(type: "int", nullable: false),
                    RegisterNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: false),
                    CGPA = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    ActiveBacklogs = table.Column<int>(type: "int", nullable: false),
                    ResumeUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_PlacementOfficers_PlacementOfficerId",
                        column: x => x.PlacementOfficerId,
                        principalTable: "PlacementOfficers",
                        principalColumn: "PlacementOfficerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHRs_ApprovedBy",
                table: "CompanyHRs",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHRs_CompanyId",
                table: "CompanyHRs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyHRs_UserId",
                table: "CompanyHRs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementOfficers_ApprovedBy",
                table: "PlacementOfficers",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementOfficers_CollegeId",
                table: "PlacementOfficers",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementOfficers_UserId",
                table: "PlacementOfficers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CollegeId_RegisterNumber",
                table: "Students",
                columns: new[] { "CollegeId", "RegisterNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_PlacementOfficerId",
                table: "Students",
                column: "PlacementOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyHRs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "PlacementOfficers");
        }
    }
}
