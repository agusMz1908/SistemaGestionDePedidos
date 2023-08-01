using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadorHandy.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class TablaPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    EquiposETH = table.Column<int>(type: "int", nullable: false),
                    Equipos3G = table.Column<int>(type: "int", nullable: false),
                    EntregadosETH = table.Column<int>(type: "int", nullable: false),
                    Entregados3G = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
