using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Documents.Tracker.Data.Migrations
{
    public partial class RequiredDocumentTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DocRequirements");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DocRequirements");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentFileTypeId",
                table: "DocRequirements",
                nullable: true,
                defaultValue: 0);

            //migrationBuilder.CreateTable(
            //    name: "AttachmentFilesType",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AttachmentFilesType", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Category",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedAt = table.Column<DateTime>(nullable: false),
            //        CreatedBy = table.Column<string>(nullable: true),
            //        ModifiedAt = table.Column<DateTime>(nullable: true),
            //        ModifiedBy = table.Column<string>(nullable: true),
            //        IsDeleted = table.Column<bool>(nullable: false),
            //        Name = table.Column<string>(maxLength: 50, nullable: true),
            //        NameAr = table.Column<string>(maxLength: 50, nullable: true),
            //        Description = table.Column<string>(maxLength: 250, nullable: true),
            //        ImageUrl = table.Column<string>(nullable: true),
            //        ParentCategoryId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Category", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Category_Category_ParentCategoryId",
            //            column: x => x.ParentCategoryId,
            //            principalTable: "Category",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Product",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedAt = table.Column<DateTime>(nullable: false),
            //        CreatedBy = table.Column<string>(nullable: true),
            //        ModifiedAt = table.Column<DateTime>(nullable: true),
            //        ModifiedBy = table.Column<string>(nullable: true),
            //        IsDeleted = table.Column<bool>(nullable: false),
            //        Code = table.Column<string>(maxLength: 50, nullable: true),
            //        UKey = table.Column<string>(maxLength: 200, nullable: false),
            //        Name = table.Column<string>(maxLength: 50, nullable: false),
            //        NameAr = table.Column<string>(maxLength: 50, nullable: true),
            //        ShortName = table.Column<string>(maxLength: 25, nullable: false),
            //        Details = table.Column<string>(maxLength: 150, nullable: false),
            //        CategoryId = table.Column<int>(nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
            //        AvailableStock = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Product", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Product_Category_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Category",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductImages",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedAt = table.Column<DateTime>(nullable: false),
            //        CreatedBy = table.Column<string>(nullable: true),
            //        ModifiedAt = table.Column<DateTime>(nullable: true),
            //        ModifiedBy = table.Column<string>(nullable: true),
            //        IsDeleted = table.Column<bool>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        ImageUrl = table.Column<string>(nullable: false),
            //        IsPoster = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductImages", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductImages_Product_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Product",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_DocRequirements_AttachmentFileTypeId",
                table: "DocRequirements",
                column: "AttachmentFileTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DocRequirements_ProductUKey",
            //    table: "DocRequirements",
            //    column: "ProductUKey");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DocIssued_ProductUKey",
            //    table: "DocIssued",
            //    column: "ProductUKey");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Category_ParentCategoryId",
            //    table: "Category",
            //    column: "ParentCategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Product_CategoryId",
            //    table: "Product",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductImages_ProductId",
            //    table: "ProductImages",
            //    column: "ProductId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_DocIssued_Product_ProductUKey",
            //    table: "DocIssued",
            //    column: "ProductUKey",
            //    principalTable: "Product",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DocRequirements_AttachmentFilesTypes_AttachmentFileTypeId",
                table: "DocRequirements",
                column: "AttachmentFileTypeId",
                principalTable: "AttachmentFilesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_DocRequirements_Product_ProductUKey",
            //    table: "DocRequirements",
            //    column: "ProductUKey",
            //    principalTable: "Product",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_DocIssued_Product_ProductUKey",
            //    table: "DocIssued");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_DocRequirements_AttachmentFilesType_AttachmentFileTypeId",
            //    table: "DocRequirements");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_DocRequirements_Product_ProductUKey",
            //    table: "DocRequirements");

            //migrationBuilder.DropTable(
            //    name: "AttachmentFilesType");

            //migrationBuilder.DropTable(
            //    name: "ProductImages");

            //migrationBuilder.DropTable(
            //    name: "Product");

            //migrationBuilder.DropTable(
            //    name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_DocRequirements_AttachmentFileTypeId",
                table: "DocRequirements");

            //migrationBuilder.DropIndex(
            //    name: "IX_DocRequirements_ProductUKey",
            //    table: "DocRequirements");

            //migrationBuilder.DropIndex(
            //    name: "IX_DocIssued_ProductUKey",
            //    table: "DocIssued");

            migrationBuilder.DropColumn(
                name: "AttachmentFileTypeId",
                table: "DocRequirements");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DocRequirements",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DocRequirements",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
