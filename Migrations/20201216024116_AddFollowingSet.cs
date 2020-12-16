using Microsoft.EntityFrameworkCore.Migrations;

namespace GigHub.Migrations
{
    public partial class AddFollowingSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_FollowedUserId",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_AspNetUsers_UserId",
                table: "Follow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follow",
                table: "Follow");

            migrationBuilder.RenameTable(
                name: "Follow",
                newName: "Followings");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_FollowedUserId",
                table: "Followings",
                newName: "IX_Followings_FollowedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followings",
                table: "Followings",
                columns: new[] { "UserId", "FollowedUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_FollowedUserId",
                table: "Followings",
                column: "FollowedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_AspNetUsers_UserId",
                table: "Followings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_FollowedUserId",
                table: "Followings");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_AspNetUsers_UserId",
                table: "Followings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followings",
                table: "Followings");

            migrationBuilder.RenameTable(
                name: "Followings",
                newName: "Follow");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_FollowedUserId",
                table: "Follow",
                newName: "IX_Follow_FollowedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follow",
                table: "Follow",
                columns: new[] { "UserId", "FollowedUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_FollowedUserId",
                table: "Follow",
                column: "FollowedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_AspNetUsers_UserId",
                table: "Follow",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
