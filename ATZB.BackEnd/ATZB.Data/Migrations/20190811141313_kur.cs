using Microsoft.EntityFrameworkCore.Migrations;

namespace ATZB.Data.Migrations
{
    public partial class kur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TypeOfOrder_TypeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "TypeOfOrder");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Users",
                newName: "Mol");

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeForOrder",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ImageLink = table.Column<string>(nullable: true),
                    ATZBUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Users_ATZBUserId",
                        column: x => x.ATZBUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfSpecials",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TypeOfSpecial = table.Column<int>(nullable: false),
                    ATZBUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfSpecials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeOfSpecials_Users_ATZBUserId",
                        column: x => x.ATZBUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ATZBUserId",
                table: "Images",
                column: "ATZBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfSpecials_ATZBUserId",
                table: "TypeOfSpecials",
                column: "ATZBUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "TypeOfSpecials");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeForOrder",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Mol",
                table: "Users",
                newName: "StreetAddress");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Orders",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TypeId",
                table: "Orders",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TypeOfOrder_TypeId",
                table: "Orders",
                column: "TypeId",
                principalTable: "TypeOfOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
