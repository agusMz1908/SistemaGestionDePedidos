﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadorHandy.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ChangePendientesValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pendientes",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pendientes",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
