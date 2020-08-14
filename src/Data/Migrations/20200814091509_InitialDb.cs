using Microsoft.EntityFrameworkCore.Migrations;

namespace VueClassValidation.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(maxLength: 100, nullable: true),
                    CityTown = table.Column<string>(maxLength: 50, nullable: true),
                    StateProvince = table.Column<string>(maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Sales",
                table: "Customers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "CityTown", "CompanyName", "Country", "FirstName", "LastName", "PhoneNumber", "PostalCode", "StateProvince", "UserName" },
                values: new object[] { 1, "123 Main Street", null, null, "Atlanta", null, null, "Shawn", "Wildermuth", "404-555-1212", "12345", "GA", "shawn@wildermuth.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Sales");
        }
    }
}
