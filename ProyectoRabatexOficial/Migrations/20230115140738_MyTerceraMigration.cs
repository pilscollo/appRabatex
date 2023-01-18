using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRabatexOficial.Migrations
{
    /// <inheritdoc />
    public partial class MyTerceraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductoCliente",
                table: "ProductoCliente");

            migrationBuilder.RenameTable(
                name: "ProductoCliente",
                newName: "IngresoCliente");

            migrationBuilder.RenameIndex(
                name: "IX_ProductoCliente_IdIngreso",
                table: "IngresoCliente",
                newName: "IX_IngresoCliente_IdIngreso");

            migrationBuilder.RenameIndex(
                name: "IX_ProductoCliente_IdCliente",
                table: "IngresoCliente",
                newName: "IX_IngresoCliente_IdCliente");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ingreso",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngresoCliente",
                table: "IngresoCliente",
                column: "IdRelacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngresoCliente",
                table: "IngresoCliente");

            migrationBuilder.RenameTable(
                name: "IngresoCliente",
                newName: "ProductoCliente");

            migrationBuilder.RenameIndex(
                name: "IX_IngresoCliente_IdIngreso",
                table: "ProductoCliente",
                newName: "IX_ProductoCliente_IdIngreso");

            migrationBuilder.RenameIndex(
                name: "IX_IngresoCliente_IdCliente",
                table: "ProductoCliente",
                newName: "IX_ProductoCliente_IdCliente");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ingreso",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductoCliente",
                table: "ProductoCliente",
                column: "IdRelacion");
        }
    }
}
