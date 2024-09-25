using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recall_ai.api.Migrations
{
    public partial class updateddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 1,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 2,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 3,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 4,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1579));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 5,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 6,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 7,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 8,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 9,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 10,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1585));

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 11, new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1572), "Feeling great today!", 1 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 12, new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1573), "Feeling great today!", 1 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 13, new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1575), "Had a productive day.", 2 });

            migrationBuilder.InsertData(
                table: "UserDiaries",
                columns: new[] { "DiaryId", "InsertedOn", "Note", "UserId" },
                values: new object[] { 14, new DateTime(2024, 9, 25, 13, 27, 50, 786, DateTimeKind.Local).AddTicks(1576), "Had a productive day.", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 1,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 2,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 3,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 4,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 5,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 6,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 7,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 8,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 9,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "UserDiaries",
                keyColumn: "DiaryId",
                keyValue: 10,
                column: "InsertedOn",
                value: new DateTime(2024, 9, 24, 20, 28, 46, 865, DateTimeKind.Local).AddTicks(8212));
        }
    }
}
