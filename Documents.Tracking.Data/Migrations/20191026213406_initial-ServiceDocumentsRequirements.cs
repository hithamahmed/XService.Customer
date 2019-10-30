using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Documents.Tracker.Data.Migrations
{
    public partial class initialServiceDocumentsRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    
            migrationBuilder.CreateTable(
                name: "DocRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    IsRequired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocRequirements_ServiceCategory_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocRequirements_ServiceId",
                table: "DocRequirements",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategory_ServiceCategoryId",
                table: "ServiceCategories",
                column: "ServiceCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocRequirements");

      
        }
    }
}
