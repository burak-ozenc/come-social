using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComeSocial.Infrastructure.Migrations
{
    public partial class _0123231839 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComeSocialEventTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComeSocialEventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialEventTypeIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialEventTypeIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialEventTypeIds_SocialEvents_SocialEventId",
                        column: x => x.SocialEventId,
                        principalTable: "SocialEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialEventTypeIds_SocialEventId",
                table: "SocialEventTypeIds",
                column: "SocialEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComeSocialEventTypes");

            migrationBuilder.DropTable(
                name: "SocialEventTypeIds");
        }
    }
}
