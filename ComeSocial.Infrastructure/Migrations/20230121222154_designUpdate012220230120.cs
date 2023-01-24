using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComeSocial.Infrastructure.Migrations
{
    public partial class designUpdate012220230120 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialEventTagIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocialEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialEventTagIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialEventTagIds_SocialEvents_SocialEventId",
                        column: x => x.SocialEventId,
                        principalTable: "SocialEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialEventTagIds_SocialEventId",
                table: "SocialEventTagIds",
                column: "SocialEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialEventTagIds");
        }
    }
}
