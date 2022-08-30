using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadAssDogTreats_Website.Migrations
{
    public partial class ToDo_added_CompletionNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompletionNotes",
                table: "ToDo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionNotes",
                table: "ToDo");
        }
    }
}
