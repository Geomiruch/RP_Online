using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RP_Server.Migrations
{
    public partial class TestingDiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e49d965f-3f62-4ca1-a4c1-7f6fcba3260b", "AQAAAAEAACcQAAAAEMHBUJE3OoKTwIj79Y3w3OSMf5CpYsd+xr9LhohvggjqxH5iFGGIDkvT2TJGn4HnMg==", "6e13e192-4860-44b5-af6d-53feaf62d832" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d53bfa94-7969-4f03-a79a-6c754237e688", "AQAAAAEAACcQAAAAEKJSDhZyATJFi/dvjWluATUd/6TliWCfjqMe79pEm35QtoJqfWw6tM+FhqBLPk1+ww==", "5145bb5e-f0df-415f-9183-b2af6aaee3e8" });
        }
    }
}
