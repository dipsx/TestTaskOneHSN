using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTask.Database.Migrations {
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.EnsureSchema(
                name: "Rectangle");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.CreateTable(
                name: "Rectangle",
                schema: "Rectangle",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X1 = table.Column<int>(type: "int", nullable: false),
                    Y1 = table.Column<int>(type: "int", nullable: false),
                    X2 = table.Column<int>(type: "int", nullable: false),
                    Y2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Rectangle", x => x.Id);
                    table.CheckConstraint("CK_Rectangle_XY_Check", "X1 < X2 AND Y1 < Y2");
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "User",
                columns: table => new {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Rectangle",
                table: "Rectangle",
                columns: new[] { "Id", "X1", "X2", "Y1", "Y2" },
                values: new object[,]
                {
                    { 1L, 8, 194, 57, 110 },
                    { 2L, 23, 186, 78, 108 },
                    { 3L, 29, 48, 10, 116 },
                    { 4L, 69, 148, 81, 141 },
                    { 5L, 68, 149, 43, 115 },
                    { 6L, 91, 124, 41, 114 },
                    { 7L, 41, 192, 28, 186 },
                    { 8L, 95, 98, 9, 83 },
                    { 9L, 68, 114, 79, 132 },
                    { 10L, 1, 93, 51, 59 },
                    { 11L, 99, 137, 55, 175 },
                    { 12L, 60, 178, 18, 183 },
                    { 13L, 97, 131, 88, 187 },
                    { 14L, 18, 198, 25, 185 },
                    { 15L, 36, 121, 41, 146 },
                    { 16L, 83, 158, 33, 62 },
                    { 17L, 46, 146, 46, 120 },
                    { 18L, 66, 74, 45, 54 },
                    { 19L, 37, 164, 71, 155 },
                    { 20L, 14, 90, 71, 150 },
                    { 21L, 61, 79, 98, 166 },
                    { 22L, 39, 40, 59, 142 },
                    { 23L, 57, 180, 75, 112 },
                    { 24L, 40, 108, 68, 134 },
                    { 25L, 51, 135, 5, 187 },
                    { 26L, 41, 81, 38, 101 },
                    { 27L, 74, 116, 93, 141 },
                    { 28L, 32, 119, 8, 89 },
                    { 29L, 89, 94, 21, 123 },
                    { 30L, 8, 13, 68, 154 },
                    { 31L, 31, 148, 16, 148 },
                    { 32L, 56, 93, 70, 137 },
                    { 33L, 22, 107, 54, 184 },
                    { 34L, 29, 145, 20, 25 },
                    { 35L, 84, 184, 91, 144 },
                    { 36L, 17, 51, 56, 79 },
                    { 37L, 32, 167, 76, 152 },
                    { 38L, 96, 112, 54, 198 },
                    { 39L, 49, 147, 94, 198 },
                    { 40L, 62, 168, 99, 175 },
                    { 41L, 93, 155, 6, 142 },
                    { 42L, 26, 118, 51, 144 },
                    { 43L, 88, 180, 44, 180 },
                    { 44L, 85, 184, 23, 184 },
                    { 45L, 55, 142, 67, 78 },
                    { 46L, 22, 144, 66, 147 },
                    { 47L, 89, 161, 86, 182 },
                    { 48L, 20, 47, 13, 150 },
                    { 49L, 37, 143, 69, 196 },
                    { 50L, 87, 173, 62, 178 },
                    { 51L, 28, 176, 76, 146 },
                    { 52L, 49, 131, 53, 70 },
                    { 53L, 64, 93, 21, 148 },
                    { 54L, 76, 82, 38, 96 },
                    { 55L, 78, 160, 73, 142 },
                    { 56L, 97, 128, 12, 178 },
                    { 57L, 7, 120, 42, 175 },
                    { 58L, 1, 66, 94, 96 },
                    { 59L, 32, 162, 79, 155 },
                    { 60L, 63, 155, 48, 132 },
                    { 61L, 88, 161, 10, 98 },
                    { 62L, 25, 144, 63, 74 },
                    { 63L, 3, 27, 39, 143 },
                    { 64L, 50, 197, 82, 159 },
                    { 65L, 45, 181, 86, 184 },
                    { 66L, 14, 116, 68, 168 },
                    { 67L, 25, 95, 4, 107 },
                    { 68L, 36, 131, 89, 196 },
                    { 69L, 32, 192, 97, 126 },
                    { 70L, 14, 176, 26, 117 },
                    { 71L, 10, 135, 84, 187 },
                    { 72L, 23, 30, 94, 185 },
                    { 73L, 0, 126, 21, 114 },
                    { 74L, 38, 87, 64, 90 },
                    { 75L, 46, 56, 15, 48 },
                    { 76L, 55, 145, 97, 131 },
                    { 77L, 59, 156, 10, 154 },
                    { 78L, 51, 195, 98, 135 },
                    { 79L, 95, 110, 79, 132 },
                    { 80L, 42, 99, 56, 170 },
                    { 81L, 4, 145, 85, 193 },
                    { 82L, 21, 189, 21, 134 },
                    { 83L, 49, 95, 5, 133 },
                    { 84L, 38, 140, 92, 127 },
                    { 85L, 88, 97, 27, 103 },
                    { 86L, 64, 71, 94, 147 },
                    { 87L, 52, 71, 7, 25 },
                    { 88L, 26, 64, 15, 143 },
                    { 89L, 8, 77, 3, 153 },
                    { 90L, 54, 122, 95, 110 },
                    { 91L, 8, 154, 54, 188 },
                    { 92L, 57, 158, 28, 173 },
                    { 93L, 80, 154, 19, 62 },
                    { 94L, 52, 190, 54, 71 },
                    { 95L, 62, 79, 70, 135 },
                    { 96L, 31, 107, 88, 96 },
                    { 97L, 23, 196, 58, 117 },
                    { 98L, 70, 80, 79, 156 },
                    { 99L, 54, 167, 34, 82 },
                    { 100L, 22, 164, 43, 76 },
                    { 101L, 46, 176, 69, 148 },
                    { 102L, 97, 135, 66, 163 },
                    { 103L, 70, 114, 98, 112 },
                    { 104L, 28, 142, 15, 193 },
                    { 105L, 16, 83, 32, 99 },
                    { 106L, 90, 197, 51, 130 },
                    { 107L, 76, 145, 89, 127 },
                    { 108L, 71, 114, 41, 120 },
                    { 109L, 94, 161, 2, 96 },
                    { 110L, 27, 65, 47, 114 },
                    { 111L, 59, 172, 14, 62 },
                    { 112L, 23, 81, 48, 61 },
                    { 113L, 7, 101, 82, 145 },
                    { 114L, 94, 147, 41, 94 },
                    { 115L, 71, 192, 80, 133 },
                    { 116L, 15, 190, 64, 80 },
                    { 117L, 31, 199, 30, 154 },
                    { 118L, 1, 117, 27, 118 },
                    { 119L, 33, 175, 49, 73 },
                    { 120L, 42, 97, 28, 174 },
                    { 121L, 22, 146, 99, 138 },
                    { 122L, 69, 125, 41, 138 },
                    { 123L, 25, 171, 0, 15 },
                    { 124L, 22, 132, 5, 35 },
                    { 125L, 23, 144, 11, 43 },
                    { 126L, 2, 139, 98, 149 },
                    { 127L, 57, 113, 47, 126 },
                    { 128L, 3, 169, 90, 131 },
                    { 129L, 43, 46, 28, 135 },
                    { 130L, 44, 145, 21, 172 },
                    { 131L, 83, 124, 58, 133 },
                    { 132L, 37, 75, 66, 105 },
                    { 133L, 3, 66, 21, 72 },
                    { 134L, 32, 71, 93, 129 },
                    { 135L, 84, 175, 23, 64 },
                    { 136L, 85, 188, 71, 85 },
                    { 137L, 2, 174, 34, 95 },
                    { 138L, 50, 187, 48, 51 },
                    { 139L, 51, 87, 82, 143 },
                    { 140L, 95, 106, 21, 61 },
                    { 141L, 83, 94, 96, 129 },
                    { 142L, 78, 178, 53, 109 },
                    { 143L, 90, 97, 70, 89 },
                    { 144L, 32, 142, 41, 83 },
                    { 145L, 76, 85, 77, 148 },
                    { 146L, 41, 86, 26, 39 },
                    { 147L, 67, 76, 69, 70 },
                    { 148L, 69, 163, 30, 159 },
                    { 149L, 17, 126, 21, 106 },
                    { 150L, 19, 98, 25, 80 },
                    { 151L, 65, 165, 77, 148 },
                    { 152L, 78, 146, 85, 184 },
                    { 153L, 54, 147, 86, 171 },
                    { 154L, 90, 167, 58, 104 },
                    { 155L, 51, 147, 91, 170 },
                    { 156L, 20, 103, 40, 95 },
                    { 157L, 74, 171, 46, 71 },
                    { 158L, 93, 158, 72, 128 },
                    { 159L, 11, 196, 82, 164 },
                    { 160L, 0, 66, 82, 130 },
                    { 161L, 44, 103, 19, 196 },
                    { 162L, 51, 105, 57, 109 },
                    { 163L, 98, 120, 30, 128 },
                    { 164L, 84, 180, 26, 145 },
                    { 165L, 87, 123, 72, 180 },
                    { 166L, 93, 133, 17, 154 },
                    { 167L, 48, 55, 5, 36 },
                    { 168L, 11, 63, 50, 60 },
                    { 169L, 79, 134, 84, 98 },
                    { 170L, 31, 130, 12, 194 },
                    { 171L, 59, 113, 19, 72 },
                    { 172L, 68, 156, 27, 56 },
                    { 173L, 23, 195, 78, 167 },
                    { 174L, 98, 153, 1, 49 },
                    { 175L, 4, 30, 32, 196 },
                    { 176L, 58, 78, 87, 102 },
                    { 177L, 14, 130, 81, 107 },
                    { 178L, 17, 27, 31, 131 },
                    { 179L, 60, 197, 39, 134 },
                    { 180L, 18, 23, 92, 159 },
                    { 181L, 80, 199, 99, 113 },
                    { 182L, 66, 85, 8, 69 },
                    { 183L, 31, 35, 25, 147 },
                    { 184L, 94, 148, 76, 198 },
                    { 185L, 85, 121, 16, 69 },
                    { 186L, 96, 103, 10, 171 },
                    { 187L, 52, 86, 32, 46 },
                    { 188L, 66, 104, 86, 191 },
                    { 189L, 30, 82, 56, 164 },
                    { 190L, 71, 156, 82, 120 },
                    { 191L, 66, 138, 80, 149 },
                    { 192L, 31, 60, 64, 154 },
                    { 193L, 13, 24, 25, 65 },
                    { 194L, 52, 177, 12, 152 },
                    { 195L, 43, 109, 23, 148 },
                    { 196L, 87, 167, 73, 119 },
                    { 197L, 82, 105, 12, 105 },
                    { 198L, 72, 115, 34, 80 },
                    { 199L, 15, 137, 54, 199 },
                    { 200L, 4, 126, 57, 60 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "Roles" },
                values: new object[] { 1L, "administrator@administrator.com", "eR3YwtuZPO3KZjmvvpqo0OC8vcZCUpzKC9j/Us+aVOwHJWkgVX+jugi7jCeI4kCxGsB0FOP4xFZO7HIVOI5Juc78aV/ewD5auG5lt6cPaVOOGbjIDbM+0Xcfo8MkpXslgTvxzVK8EU63EWm3rJfDhsOanHANh/uQfYIoLGqwtcBcKgbzgDvaH7nGDZ4bgzEOwShp+fPKwiXZNZPuGQRsN9sEYavwDbr3fNW4AUUeVUnY66mEEFX3Lwd+n905N28YYNUG2Of+aJHQSH9x/u1hdjdwfXukB6eP0863z89x4QCSL9bq3F7CmHOAKyfxR5YSxsgKn+EWKNuBRFOFOdcbS/cumBWC0jvmwhnmLzdy7DLGGDm4ZnSXfEhzXmKMlVuP72CP+lXCvslIiiGDsjn0ZmNlP8gbw4O7Apl6X9KyPV1zJk7RlJazqRr0Yge5u7klPsocKbdLHEoOSdvR/jhLhzXKkhZunmEvvOZFYnPNnl0UX8a5G729uzdxeUghqgXhnLWFgs7nElkQ2EZVTuQv1it9uWrprpKU8YWjv+wXs7LM84EvT3oNmeBrqQUkfaSP773fwP5wULMrgIIO5NP3HzjbuKzgAOU01UMJc/Hm960gAkkBzhYjL9uolf/iJNVJ6ggEhFo+0EjvV4J52eS5fddHX5r3hQSiDK9hrb6LlHo=", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Rectangle_X1_Y1_X2_Y2",
                schema: "Rectangle",
                table: "Rectangle",
                columns: new[] { "X1", "Y1", "X2", "Y2" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "User",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Rectangle",
                schema: "Rectangle");

            migrationBuilder.DropTable(
                name: "User",
                schema: "User");
        }
    }
}
