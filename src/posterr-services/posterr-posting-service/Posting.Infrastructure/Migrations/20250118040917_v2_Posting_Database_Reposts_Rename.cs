using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Posting.Infrastructure.Migrations
{
    public partial class v2_Posting_Database_Reposts_Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reposts_Posts_OriginalPostId",
                table: "Reposts");

            migrationBuilder.RenameColumn(
                name: "OriginalRepostId",
                table: "Reposts",
                newName: "ParentRepostId");

            migrationBuilder.RenameColumn(
                name: "OriginalPostId",
                table: "Reposts",
                newName: "ParentPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Reposts_RepostUserId_OriginalPostId",
                table: "Reposts",
                newName: "IX_Reposts_RepostUserId_ParentPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Reposts_OriginalPostId",
                table: "Reposts",
                newName: "IX_Reposts_ParentPostId");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 1, 16, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 1, 13, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 1, 17, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "Reposts",
                keyColumn: "RepostId",
                keyValue: 1,
                column: "RepostDate",
                value: new DateTime(2025, 1, 15, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "Reposts",
                keyColumn: "RepostId",
                keyValue: 2,
                column: "RepostDate",
                value: new DateTime(2025, 1, 17, 3, 9, 16, 880, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Reposts",
                keyColumn: "RepostId",
                keyValue: 3,
                column: "RepostDate",
                value: new DateTime(2025, 1, 17, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5199));

            migrationBuilder.AddForeignKey(
                name: "FK_Reposts_Posts_ParentPostId",
                table: "Reposts",
                column: "ParentPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reposts_Posts_ParentPostId",
                table: "Reposts");

            migrationBuilder.RenameColumn(
                name: "ParentRepostId",
                table: "Reposts",
                newName: "OriginalRepostId");

            migrationBuilder.RenameColumn(
                name: "ParentPostId",
                table: "Reposts",
                newName: "OriginalPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Reposts_RepostUserId_ParentPostId",
                table: "Reposts",
                newName: "IX_Reposts_RepostUserId_OriginalPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Reposts_ParentPostId",
                table: "Reposts",
                newName: "IX_Reposts_OriginalPostId");

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

            migrationBuilder.UpdateData(
                table: "Reposts",
                keyColumn: "RepostId",
                keyValue: 3,
                column: "RepostDate",
                value: new DateTime(2025, 1, 17, 3, 43, 22, 526, DateTimeKind.Utc).AddTicks(8175));

            migrationBuilder.AddForeignKey(
                name: "FK_Reposts_Posts_OriginalPostId",
                table: "Reposts",
                column: "OriginalPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
