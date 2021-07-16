using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Angular3_Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Stock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    OpeningHours = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Pickup = table.Column<bool>(type: "boolean", nullable: false),
                    StoreId = table.Column<long>(type: "bigint", nullable: true),
                    ShippingAddress = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailsOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailsOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsOrder_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "City", "Date", "Name", "Pickup", "ShippingAddress", "StoreId", "Total" },
                values: new object[] { 1L, "Barcelona", "01/12/1995", "Dominicode", false, "Av. de la Granvia de Hospitalet, 115", null, 20.40m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1L, "Learn the essentials and more of TypeScript, a popular superset of the JavaScript language that adds support for static typing. TypeScript combines the typing features of C# or Java.", "Essential TypeScript 4: From Beginner to Pro", 45m, 0 },
                    { 2L, "En Hackeando del cerebro de tus compradores, Corti nos revela cómo muchas compañías crean productos digitales o procesos de venta capaces de conectar con la psicología del comprador.", "Hackeando el cerebro de tus compradores: PsychoGrowth", 5m, 10 },
                    { 3L, "In this book, the reader will be able to focus on one concept of Angular in deep.", "Angular Routing: Learn To Create client-side and SPA with Routing and Navigation", 17m, 10 },
                    { 4L, "Ideal for Android smartphones and tablets, and MIL cameras. SanDisk Memory Zone app for easy file management (Download and Installation Required).", "SanDisk 128GB Ultra MicroSDXC UHS-I Memory Card with Adapter", 19m, 10 },
                    { 5L, "5K Video - Shoot stunning video with up to 5K resolution, perfect for maintaining detail even when zooming in", "GoPro HERO9 Black - Waterproof Action Camera with Front LCD", 399m, 10 },
                    { 6L, "HDMI A Male to A Male Cable: Supports Ethernet, 3D, 4K video and Audio Return Channel (ARC)", "CL3 Rated High-Speed 4K HDMI Cable - 6 Feet", 7m, 10 },
                    { 7L, "The USB receiver is conveniently located in the box, top flap. This wireless keyboard and mouse feature Logitech Advanced 2.4GHz technology with a range of up to 10 metres.", "Logitech MK270 Wireless Keyboard and Mouse Combo", 32m, 10 },
                    { 8L, "Plug & play. Easy to use,powered by USB port. No external driver and Power needed. Just plug it into your USB port and the DVD driver will be detected", "External CD Drive USB 3.0 Portable CD DVD +/-RW Drive DVD/CD ROM", 20m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "City", "Name", "OpeningHours" },
                values: new object[,]
                {
                    { 1L, "38 Park Row", "New York", "Park Row at Beekman St", "10:00 - 14:00 and 17:00 - 20:30" },
                    { 2L, "Calle de Alcalá, 21", "Madrid", "Store Alcalá", "10:00 - 14:00 and 17:00 - 20:30" },
                    { 3L, "125 Chambers Street", "New York", "Chambers and West Broadway", "10:00 - 14:00 and 17:00 - 20:30" },
                    { 4L, "10 Russell Street", "London", "Covent Garden - Russell St", "10:00 - 14:00 and 17:00 - 20:30" },
                    { 5L, "11 Monmouth Street", "London", "Monmouth St", "10:00 - 14:00 and 17:00 - 20:30" }
                });

            migrationBuilder.InsertData(
                table: "DetailsOrder",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "Subtotal" },
                values: new object[] { 1L, 1L, 1L, 10, 100m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "City", "Date", "Name", "Pickup", "ShippingAddress", "StoreId", "Total" },
                values: new object[] { 2L, null, "01/12/1995", "Dominicode", true, null, 1L, 105.30m });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsOrder_OrderId",
                table: "DetailsOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsOrder_ProductId",
                table: "DetailsOrder",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreId",
                table: "Orders",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsOrder");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
