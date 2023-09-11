using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Bartender_Application.Migrations
{
    /// <inheritdoc />
    public partial class OrderToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Cocktails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_OrderId",
                table: "Cocktails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cocktails_Order_OrderId",
                table: "Cocktails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cocktails_Order_OrderId",
                table: "Cocktails");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Cocktails_OrderId",
                table: "Cocktails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Cocktails");
        }
    }
}
