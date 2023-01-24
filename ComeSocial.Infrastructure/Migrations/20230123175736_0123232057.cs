using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComeSocial.Infrastructure.Migrations
{
    public partial class _0123232057 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComeEventTypeIds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComeSocialEventTypes",
                table: "ComeSocialEventTypes");

            migrationBuilder.RenameTable(
                name: "ComeSocialEventTypes",
                newName: "ComeEventTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComeEventTypes",
                table: "ComeEventTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SocialEventTypeIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComeEventTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "SocialEventTypeIds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComeEventTypes",
                table: "ComeEventTypes");

            migrationBuilder.RenameTable(
                name: "ComeEventTypes",
                newName: "ComeSocialEventTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComeSocialEventTypes",
                table: "ComeSocialEventTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ComeEventTypeIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComeEventTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComeEventTypeIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComeEventTypeIds_SocialEvents_SocialEventId",
                        column: x => x.SocialEventId,
                        principalTable: "SocialEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComeEventTypeIds_SocialEventId",
                table: "ComeEventTypeIds",
                column: "SocialEventId");
        }
    }
}
