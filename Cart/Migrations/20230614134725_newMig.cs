using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cart.Migrations
{
    /// <inheritdoc />
    public partial class newMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userCart",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCart", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "int", nullable: false),
                    itemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    itemDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    itemPrice = table.Column<int>(type: "int", nullable: false),
                    userCartuserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_item_userCart_userCartuserID",
                        column: x => x.userCartuserID,
                        principalTable: "userCart",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_userCartuserID",
                table: "item",
                column: "userCartuserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "userCart");
        }
    }
}
