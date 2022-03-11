using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission7.Migrations
{
    public partial class removeanon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Books",
            //    columns: table => new
            //    {
            //        BookID = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Title = table.Column<string>(type: "TEXT", nullable: false),
            //        Author = table.Column<string>(type: "TEXT", nullable: false),
            //        Publisher = table.Column<string>(type: "TEXT", nullable: false),
            //        ISBN = table.Column<string>(type: "TEXT", nullable: false),
            //        Classification = table.Column<string>(type: "TEXT", nullable: false),
            //        Category = table.Column<string>(type: "TEXT", nullable: false),
            //        PageCount = table.Column<int>(type: "INTEGER", nullable: false),
            //        Price = table.Column<double>(type: "REAL", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Books", x => x.BookID);
            //    });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AddressLine1 = table.Column<string>(type: "TEXT", nullable: false),
                    AddressLine2 = table.Column<string>(type: "TEXT", nullable: true),
                    AddressLine3 = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    Zip = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    OrderShipped = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    LineID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    DonationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Donations_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "DonationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookID",
                table: "Books",
                column: "BookID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_BookId",
                table: "ShoppingCartItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_DonationId",
                table: "ShoppingCartItem",
                column: "DonationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Donations");
        }
    }
}
