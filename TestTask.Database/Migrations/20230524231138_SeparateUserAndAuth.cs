using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeparateUserAndAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Roles",
                schema: "User",
                table: "User");

            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "User",
                table: "User",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Auth",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Salt = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auth_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Auth",
                columns: new[] { "Id", "Login", "PasswordHash", "Roles", "Salt", "UserId" },
                values: new object[] { 1L, "admin", "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK+u88gtSXAyPDkW+hVS+dW4AmxrnaNFZks0Zzcd5xlb12wcF/q96cc4htHFzvOH9jtN98N5EBIXSvdUVnFc9kBuRTVytATZA7gITbs//hkxvNQ3eody5U9hjdH6D+AP0vVt5unZlTZ+gInn8Ze7AC5o6mn0Y3ylGO1CBJSHU9c/BcFY9oknn+XYk9ySCoDGctMqDbvOBcvSTBkKcrCzev2KnX7xYmC3yNz1Q5oPVKgnq4mc1iuldMlCxse/IDGMJB2FRdTCLV5KNS4IZ1GB+dw3tMvcEEtmXmgT2zKN5+kUkOxhlv5g1ZLgXzWjVJeKb5uZpsn3WK5kt8T+kzMoxHd5i8HxsU2uvy9GopxAnaV0WNsBPqTGkRllSxARl4ZN3hJqUla553RT49tJxbs+N03OmkYhjq+L0aKJ1AC+7G+rdjegiAQZB+3mdE7a2Pne2kYtpMoCmNMKdm9jOOVpfXJqZMQul9ltJSlAY6LPrHFUB3mw61JBNzx+sZgYN29GfDY=", 3, new Guid("79005744-e69a-4b09-996b-08fe0b70cbb9"), 1L });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Administrator");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_Login",
                schema: "Auth",
                table: "Auth",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserId",
                schema: "Auth",
                table: "Auth",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth",
                schema: "Auth");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "User",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "User",
                table: "User",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                schema: "User",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "User",
                table: "User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "PasswordHash", "Roles" },
                values: new object[] { "eR3YwtuZPO3KZjmvvpqo0OC8vcZCUpzKC9j/Us+aVOwHJWkgVX+jugi7jCeI4kCxGsB0FOP4xFZO7HIVOI5Juc78aV/ewD5auG5lt6cPaVOOGbjIDbM+0Xcfo8MkpXslgTvxzVK8EU63EWm3rJfDhsOanHANh/uQfYIoLGqwtcBcKgbzgDvaH7nGDZ4bgzEOwShp+fPKwiXZNZPuGQRsN9sEYavwDbr3fNW4AUUeVUnY66mEEFX3Lwd+n905N28YYNUG2Of+aJHQSH9x/u1hdjdwfXukB6eP0863z89x4QCSL9bq3F7CmHOAKyfxR5YSxsgKn+EWKNuBRFOFOdcbS/cumBWC0jvmwhnmLzdy7DLGGDm4ZnSXfEhzXmKMlVuP72CP+lXCvslIiiGDsjn0ZmNlP8gbw4O7Apl6X9KyPV1zJk7RlJazqRr0Yge5u7klPsocKbdLHEoOSdvR/jhLhzXKkhZunmEvvOZFYnPNnl0UX8a5G729uzdxeUghqgXhnLWFgs7nElkQ2EZVTuQv1it9uWrprpKU8YWjv+wXs7LM84EvT3oNmeBrqQUkfaSP773fwP5wULMrgIIO5NP3HzjbuKzgAOU01UMJc/Hm960gAkkBzhYjL9uolf/iJNVJ6ggEhFo+0EjvV4J52eS5fddHX5r3hQSiDK9hrb6LlHo=", 3 });
        }
    }
}
