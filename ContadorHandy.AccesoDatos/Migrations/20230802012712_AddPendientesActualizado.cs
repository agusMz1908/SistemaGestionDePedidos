using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadorHandy.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AddPendientesActualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PendientesActualizados",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PendientesActualizados",
                table: "Pedidos");
        }
    }
}
