using Microsoft.EntityFrameworkCore.Migrations;

namespace NetDemo.Models.Migrations
{
    public partial class AddedProperties2PersonAndTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Training",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Training",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Person",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityToken",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "SecurityToken",
                table: "Person");
        }
    }
}
