using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClientDashboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Company = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    FormattedNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RawPhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Active", "Address", "Company", "Email", "Name" },
                values: new object[,]
                {
                    { 1, true, "123 Test Ave", "TestCo", "test@example.com", "Test Client" },
                    { 2, true, "456 Sample Blvd", "SecondCo", "second@example.com", "Second Client" },
                    { 3, true, "1 Alpha Way", "Alpha Inc", "contact@alpha.com", "Alpha Inc" },
                    { 4, false, "42 Beta St", "Beta Corporation", "info@beta.com", "Beta Corp" },
                    { 5, true, "99 Gamma Circle", "Gamma LLC", "support@gamma.com", "Gamma LLC" },
                    { 6, false, "67 Delta Rd", "Delta Co", "hello@delta.com", "Delta Co" },
                    { 7, true, "8 Epsilon Pkwy", "Epsilon Ltd", "office@epsilon.com", "Epsilon Ltd" },
                    { 8, true, "77 Zeta Ln", "Zeta Group", "zeta@group.org", "Zeta Group" },
                    { 9, false, "34 Eta Dr", "Eta Agency", "contact@etaagency.com", "Eta Agency" },
                    { 10, true, "12 Theta Ct", "Theta Enterprises", "theta@enterprises.net", "Theta Enterprises" },
                    { 11, true, "90 Iota Cres", "Iota Partners", "info@iotapartners.com", "Iota Partners" },
                    { 12, false, "4 Kappa Blvd", "Kappa Services", "admin@kappaservices.com", "Kappa Services" },
                    { 13, true, "6 Lambda St", "Lambda Systems", "lambda@systems.biz", "Lambda Systems" },
                    { 14, true, "22 Mu Rd", "Mu Logistics", "mu@logistics.org", "Mu Logistics" },
                    { 15, false, "100 Nu Tech Dr", "Nu Technologies", "team@nu.tech", "Nu Technologies" },
                    { 16, true, "59 Xi Ave", "Xi Solutions", "xi@solutions.dev", "Xi Solutions" },
                    { 17, true, "14 Omicron Way", "Omicron Industries", "omicron@industries.net", "Omicron Industries" },
                    { 18, true, "88 Pi Park", "Pi Innovations", "hello@piinnovations.com", "Pi Innovations" },
                    { 19, true, "21 Rho Dr", "Rho Labs", "rho@labs.tech", "Rho Labs" },
                    { 20, true, "5 Sigma Ln", "Sigma Ventures", "sigma@ventures.io", "Sigma Ventures" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "ClientId", "FormattedNumber", "RawPhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "(516) 913-4354", "5169134354" },
                    { 2, 1, "(810) 810-5096", "8108105096" },
                    { 3, 1, "(309) 786-8003", "3097868003" },
                    { 4, 1, "(215) 633-2089", "2156332089" },
                    { 5, 2, "(746) 731-8429", "7467318429" },
                    { 6, 2, "(238) 886-1541", "2388861541" },
                    { 7, 3, "(956) 415-9515", "9564159515" },
                    { 8, 3, "(694) 136-9631", "6941369631" },
                    { 9, 6, "(133) 313-2881", "1333132881" },
                    { 10, 6, "(192) 843-1901", "1928431901" },
                    { 11, 6, "(274) 443-6658", "2744436658" },
                    { 12, 8, "(220) 407-6727", "2204076727" },
                    { 13, 10, "(222) 575-6115", "2225756115" },
                    { 14, 11, "(530) 481-9521", "5304819521" },
                    { 15, 11, "(804) 841-3297", "8048413297" },
                    { 16, 11, "(673) 997-5545", "6739975545" },
                    { 17, 12, "(292) 796-3892", "2927963892" },
                    { 18, 12, "(831) 493-1097", "8314931097" },
                    { 19, 14, "(621) 633-6470", "6216336470" },
                    { 20, 14, "(482) 221-5583", "4822215583" },
                    { 21, 14, "(542) 877-4014", "5428774014" },
                    { 22, 15, "(430) 224-7502", "4302247502" },
                    { 23, 15, "(287) 676-4409", "2876764409" },
                    { 24, 17, "(170) 285-2523", "1702852523" },
                    { 25, 18, "(984) 522-6675", "9845226675" },
                    { 26, 20, "(132) 816-5431", "1328165431" },
                    { 27, 20, "(768) 577-3949", "7685773949" },
                    { 28, 20, "(262) 456-6803", "2624566803" },
                    { 29, 20, "(886) 379-3203", "8863793203" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ClientId",
                table: "PhoneNumbers",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
