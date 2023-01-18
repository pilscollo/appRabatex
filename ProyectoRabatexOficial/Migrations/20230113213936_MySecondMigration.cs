using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRabatexOficial.Migrations
{
    /// <inheritdoc />
    public partial class MySecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "cantidad",
                table: "IngresoProducto",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "IngresoProducto");
        }
    }
}
