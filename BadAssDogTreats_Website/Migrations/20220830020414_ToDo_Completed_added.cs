using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadAssDogTreats_Website.Migrations
{
    public partial class ToDo_Completed_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "ToDo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "ToDo");
        }
    }
}
