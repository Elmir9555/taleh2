using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendLahiye.Migrations
{
    public partial class SaleOfFCommnetSaleOffDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Blogs_BlogId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BlogId",
                table: "Comments",
                newName: "IX_Comments_BlogId");

            migrationBuilder.AddColumn<int>(
                name: "SaleOffId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SaleOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleOffDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    StarCount = table.Column<int>(type: "int", nullable: false),
                    SaleOffId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOffDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOffDetails_SaleOffs_SaleOffId",
                        column: x => x.SaleOffId,
                        principalTable: "SaleOffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SaleOffId",
                table: "Comments",
                column: "SaleOffId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOffDetails_SaleOffId",
                table: "SaleOffDetails",
                column: "SaleOffId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SaleOffs_SaleOffId",
                table: "Comments",
                column: "SaleOffId",
                principalTable: "SaleOffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SaleOffs_SaleOffId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "SaleOffDetails");

            migrationBuilder.DropTable(
                name: "SaleOffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SaleOffId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SaleOffId",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogId",
                table: "Comment",
                newName: "IX_Comment_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Blogs_BlogId",
                table: "Comment",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
