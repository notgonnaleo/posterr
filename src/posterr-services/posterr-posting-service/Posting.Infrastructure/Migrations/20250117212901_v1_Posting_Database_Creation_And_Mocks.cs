using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Posting.Infrastructure.Migrations
{
    public partial class v1_Posting_Database_Creation_And_Mocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PostContent = table.Column<string>(type: "character varying(777)", maxLength: 777, nullable: false),
                    TotalReposts = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reposts",
                columns: table => new
                {
                    RepostId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RepostUserId = table.Column<int>(type: "integer", nullable: false),
                    OriginalPostId = table.Column<int>(type: "integer", nullable: false),
                    RepostDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reposts", x => x.RepostId);
                    table.ForeignKey(
                        name: "FK_Reposts_Posts_OriginalPostId",
                        column: x => x.OriginalPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reposts_Users_RepostUserId",
                        column: x => x.RepostUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Username" },
                values: new object[,]
                {
                    { 1, "leonardo_bruni" },
                    { 2, "sinuhe_huidobro" },
                    { 3, "petvisor" },
                    { 4, "strider_platform" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "DateCreated", "PostContent", "TotalReposts", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 15, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5408), "Hey! I'm using Posterr, follow me for more pet care & vet posts.", 0, 3 },
                    { 2, new DateTime(2025, 1, 12, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5421), "Looking for career tips? follow us and get to know more about our ways.", 0, 4 },
                    { 3, new DateTime(2025, 1, 16, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5428), "Hello World!", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reposts",
                columns: new[] { "RepostId", "OriginalPostId", "RepostDate", "RepostUserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 14, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5436), 2 },
                    { 2, 2, new DateTime(2025, 1, 16, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5444), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reposts_OriginalPostId",
                table: "Reposts",
                column: "OriginalPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reposts_RepostUserId_OriginalPostId",
                table: "Reposts",
                columns: new[] { "RepostUserId", "OriginalPostId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reposts");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
