using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATZB.Data.Migrations
{
    public partial class Initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offerts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfOrder",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    EGN = table.Column<string>(nullable: true),
                    LKNummber = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ENK = table.Column<string>(nullable: true),
                    DDSNumber = table.Column<string>(nullable: true),
                    RegKSB = table.Column<string>(nullable: true),
                    AnyObligations = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PriceTo = table.Column<decimal>(type: "decimal(13, 2)", nullable: false),
                    Town = table.Column<string>(nullable: true),
                    TypeId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_TypeOfOrder_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypeOfOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserOfferts",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    OffertId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOfferts", x => new { x.OffertId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserOfferts_Offerts_OffertId",
                        column: x => x.OffertId,
                        principalTable: "Offerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOfferts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    OrderId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => new { x.UserId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_UserOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TypeId",
                table: "Orders",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOfferts_OffertId",
                table: "UserOfferts",
                column: "OffertId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserOfferts_UserId",
                table: "UserOfferts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_OrderId",
                table: "UserOrders",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOfferts");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "Offerts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TypeOfOrder");
        }
    }
}
