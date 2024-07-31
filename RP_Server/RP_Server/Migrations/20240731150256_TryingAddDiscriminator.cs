using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RP_Server.Migrations
{
    public partial class TryingAddDiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d53bfa94-7969-4f03-a79a-6c754237e688", "AQAAAAEAACcQAAAAEKJSDhZyATJFi/dvjWluATUd/6TliWCfjqMe79pEm35QtoJqfWw6tM+FhqBLPk1+ww==", "5145bb5e-f0df-415f-9183-b2af6aaee3e8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c8b6b1-e2b6-45e8-b044-8f2178a90111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a2f45d7-0ea3-482c-8ad3-fb1a84cd4bfb", "AQAAAAEAACcQAAAAEI/vy+KXLsmSXmrw4rmobxUyo9WX1GOLwlQUThyIZ43L7phHr4a0zPu4VZC297Yy+Q==", "0f8bc034-b82c-4096-9e97-3cb938e5727a" });
        }
    }
}
