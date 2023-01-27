using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppSalesMVC.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subsidiary_State_StateId",
                table: "Subsidiary");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Subsidiary",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subsidiary_State_StateId",
                table: "Subsidiary",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subsidiary_State_StateId",
                table: "Subsidiary");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Subsidiary",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Subsidiary_State_StateId",
                table: "Subsidiary",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
