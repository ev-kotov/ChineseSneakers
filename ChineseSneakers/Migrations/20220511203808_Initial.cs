using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseSneakers.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SneakersCategoryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SneakersCategoryModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SneakersModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Female = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SneakersCategoryModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SneakersModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SneakersModel_SneakersCategoryModel_SneakersCategoryModelId",
                        column: x => x.SneakersCategoryModelId,
                        principalTable: "SneakersCategoryModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SneakersId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SneakersModelId = table.Column<int>(type: "int", nullable: true),
                    OrderModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentModel_OrderModel_OrderModelId",
                        column: x => x.OrderModelId,
                        principalTable: "OrderModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentModel_SneakersModel_SneakersModelId",
                        column: x => x.SneakersModelId,
                        principalTable: "SneakersModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopCartItemModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SneakersModelId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ShopCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItemModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCartItemModel_SneakersModel_SneakersModelId",
                        column: x => x.SneakersModelId,
                        principalTable: "SneakersModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentModel_OrderModelId",
                table: "PaymentModel",
                column: "OrderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentModel_SneakersModelId",
                table: "PaymentModel",
                column: "SneakersModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItemModel_SneakersModelId",
                table: "ShopCartItemModel",
                column: "SneakersModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SneakersModel_SneakersCategoryModelId",
                table: "SneakersModel",
                column: "SneakersCategoryModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentModel");

            migrationBuilder.DropTable(
                name: "ShopCartItemModel");

            migrationBuilder.DropTable(
                name: "OrderModel");

            migrationBuilder.DropTable(
                name: "SneakersModel");

            migrationBuilder.DropTable(
                name: "SneakersCategoryModel");
        }
    }
}
