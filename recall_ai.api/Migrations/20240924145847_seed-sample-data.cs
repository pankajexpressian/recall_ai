using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recall_ai.api.Migrations
{
    public partial class seedsampledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 1, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8199), "Feeling great today!", 1 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 2, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8201), "Had a productive day.", 2 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 3, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8202), "Feeling a bit tired.", 3 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 4, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8204), "Excited about the upcoming event!", 4 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 5, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8205), "Feeling stressed about work.", 5 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 6, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8207), "Enjoyed a nice walk.", 6 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 7, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8208), "Feeling anxious.", 7 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 8, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8209), "Had a fun day out.", 8 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 9, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8210), "Feeling motivated to start new projects.", 9 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 10, new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8212), "Enjoying some quiet time.", 10 });

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
            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);
        }
    }
}
