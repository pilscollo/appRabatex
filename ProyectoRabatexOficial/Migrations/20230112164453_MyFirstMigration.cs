using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoRabatexOficial.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Localidad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Egreso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egreso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingreso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Detalle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingreso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Unidad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    stock = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoCliente",
                columns: table => new
                {
                    IdRelacion = table.Column<int>(type: "int", nullable: false),
                    IdIngreso = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoCliente", x => x.IdRelacion);
                    table.ForeignKey(
                        name: "FK_ProductoCliente_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoCliente_Producto",
                        column: x => x.IdIngreso,
                        principalTable: "Ingreso",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngresoProducto",
                columns: table => new
                {
                    IdRelacion = table.Column<int>(type: "int", nullable: false),
                    IdIngreso = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngresoProducto", x => x.IdRelacion);
                    table.ForeignKey(
                        name: "FK_IngresoProducto_Ingreso",
                        column: x => x.IdIngreso,
                        principalTable: "Ingreso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IngresoProducto_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StockProducto",
                columns: table => new
                {
                    IdRelacion = table.Column<int>(type: "int", nullable: false),
                    IdStock = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProducto", x => x.IdRelacion);
                    table.ForeignKey(
                        name: "FK_StockProducto_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockProducto_Stock",
                        column: x => x.IdStock,
                        principalTable: "Stock",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngresoProducto_IdIngreso",
                table: "IngresoProducto",
                column: "IdIngreso");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoProducto_IdProducto",
                table: "IngresoProducto",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCliente_IdCliente",
                table: "ProductoCliente",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoCliente_IdIngreso",
                table: "ProductoCliente",
                column: "IdIngreso");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducto_IdProducto",
                table: "StockProducto",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducto_IdStock",
                table: "StockProducto",
                column: "IdStock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caja");

            migrationBuilder.DropTable(
                name: "Egreso");

            migrationBuilder.DropTable(
                name: "IngresoProducto");

            migrationBuilder.DropTable(
                name: "ProductoCliente");

            migrationBuilder.DropTable(
                name: "StockProducto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Ingreso");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
