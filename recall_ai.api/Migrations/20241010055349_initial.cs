using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recall_ai.api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDiaries",
                columns: table => new
                {
                    DiaryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    NoteDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Mood = table.Column<int>(type: "INTEGER", nullable: false),
                    InsertedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiaries", x => x.DiaryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 1, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5465), 0, "Feeling great today!", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5465), 1 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 2, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5473), 0, "Had a productive day.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5473), 2 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 3, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5479), 0, "Feeling a bit tired.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5480), 3 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 4, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5481), 0, "Excited about the upcoming event!", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5482), 4 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 5, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5484), 2, "Feeling stressed about work.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5485), 5 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 6, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5487), 0, "Enjoyed a nice walk.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5487), 6 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 7, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5489), 1, "Feeling anxious.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5490), 7 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 8, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5492), 0, "Had a fun day out.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5492), 8 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 9, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5494), 0, "Feeling motivated to start new projects.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5495), 9 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 10, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5497), 0, "Enjoying some quiet time.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5497), 10 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 11, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5468), 1, "Feeling great today!", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5469), 1 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 12, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5470), 2, "Feeling great today!", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5471), 1 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 13, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5475), 0, "Had a productive day.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5475), 2 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Mood", "Note", "NoteDate", "UserId" },
                values: new object[] { 14, new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5477), 1, "Had a productive day.", new DateTime(2024, 10, 10, 11, 23, 49, 169, DateTimeKind.Local).AddTicks(5477), 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "john.doe@example.com", "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 2, "jane.smith@example.com", "Jane", "Smith" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 3, "bob.johnson@example.com", "Bob", "Johnson" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 4, "alice.brown@example.com", "Alice", "Brown" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 5, "charlie.davis@example.com", "Charlie", "Davis" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 6, "emily.miller@example.com", "Emily", "Miller" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 7, "frank.wilson@example.com", "Frank", "Wilson" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 8, "grace.moore@example.com", "Grace", "Moore" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 9, "henry.taylor@example.com", "Henry", "Taylor" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 10, "isabella.anderson@example.com", "Isabella", "Anderson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDiaries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
