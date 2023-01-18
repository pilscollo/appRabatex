using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRabatexOficial.Models;

public partial class Producto
{
    [Key][DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Unidad { get; set; } = null!;

    public double Stock { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<IngresoProducto> IngresoProductos { get; } = new List<IngresoProducto>();

    

    public virtual ICollection<StockProducto> StockProductos { get; } = new List<StockProducto>();
}
