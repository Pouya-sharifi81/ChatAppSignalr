using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class IsPrivateproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "chatGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ReceiverId",
                table: "chatGroups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_chatGroups_ReceiverId",
                table: "chatGroups",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_chatGroups_userEntities_ReceiverId",
                table: "chatGroups",
                column: "ReceiverId",
                principalTable: "userEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatGroups_userEntities_ReceiverId",
                table: "chatGroups");

            migrationBuilder.DropIndex(
                name: "IX_chatGroups_ReceiverId",
                table: "chatGroups");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "chatGroups");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "chatGroups");
        }
    }
}
