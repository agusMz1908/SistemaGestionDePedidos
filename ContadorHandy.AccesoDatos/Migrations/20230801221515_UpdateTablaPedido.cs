using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadorHandy.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Equipos3G",
                table: "Pedidos",
                newName: "Pendientes");

            migrationBuilder.RenameColumn(
                name: "Entregados3G",
                table: "Pedidos",
                newName: "EquiposMovistar");

            migrationBuilder.AddColumn<int>(
                name: "EntregadosAntel",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EntregadosClaro",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EntregadosMovistar",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquiposAntel",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquiposClaro",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntregadosAntel",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EntregadosClaro",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EntregadosMovistar",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EquiposAntel",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EquiposClaro",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "Pendientes",
                table: "Pedidos",
                newName: "Equipos3G");

            migrationBuilder.RenameColumn(
                name: "EquiposMovistar",
                table: "Pedidos",
                newName: "Entregados3G");
        }
    }
}
