using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Posting.Infrastructure.Migrations
{
    public partial class v2_Posting_Database_Reposting_Reposts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalRepostId",
                table: "Reposts",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 16, 3, 43, 22, 526, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 13, 3, 43, 22, 526, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 17, 3, 43, 22, 526, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "Reposts",
                keyColumn: "RepostId",
                keyValue: 1,
                column: "RepostDate",
                value: new DateTime(2025, 1, 15, 3, 43, 22, 526, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Reposts",
                keyColumn: "RepostId",
                keyValue: 2,
                column: "RepostDate",
                value: new DateTime(2025, 1, 17, 2, 43, 22, 526, DateTimeKind.Utc).AddTicks(8165));

            migrationBuilder.InsertData(
                table: "Reposts",
                columns: new[] { "RepostId", "OriginalPostId", "OriginalRepostId", "RepostDate", "RepostUserId" },
                values: new object[] { 3, 1, 1, new DateTime(2025, 1, 17, 3, 43, 22, 526, DateTimeKind.Utc).AddTicks(8175), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reposts",
                keyColumn: "RepostId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "OriginalRepostId",
                table: "Reposts");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 15, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 12, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 16, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Reposts",
                keyColumn: "RepostId",
                keyValue: 1,
                column: "RepostDate",
                value: new DateTime(2025, 1, 14, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "Reposts",
                keyColumn: "RepostId",
                keyValue: 2,
                column: "RepostDate",
                value: new DateTime(2025, 1, 16, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5444));
        }
    }
}
