using Microsoft.EntityFrameworkCore.Migrations;

namespace ATZB.Data.Migrations
{
    public partial class splitinguserintouserandcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeOfSpecials");

            migrationBuilder.DropColumn(
                name: "DDSNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ENK",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Mol",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeForOrder",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "RegKSB",
                table: "Users",
                newName: "CompanyId");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ENK = table.Column<string>(nullable: true),
                    DDSNumber = table.Column<string>(nullable: true),
                    Mol = table.Column<string>(nullable: true),
                    RegKSB = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Users",
                newName: "RegKSB");

            migrationBuilder.AddColumn<string>(
                name: "DDSNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ENK",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mol",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeForOrder",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeOfSpecials",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ATZBUserId = table.Column<string>(nullable: true),
                    TypeOfSpecial = table.Column<int>(nullable: false)
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
                name: "IX_TypeOfSpecials_ATZBUserId",
                table: "TypeOfSpecials",
                column: "ATZBUserId");
        }
    }
}
