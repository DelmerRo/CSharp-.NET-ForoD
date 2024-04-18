using Microsoft.EntityFrameworkCore.Migrations;

namespace FORO_D.Migrations
{
    public partial class Nombre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuarios");

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "MiembrosHabilitados",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "MiembrosHabilitados");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
