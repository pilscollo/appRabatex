using System;
using System.Collections.Generic;

namespace ProyectoRabatexOficial.Models;

public partial class Stock
{
    public int Id { get; set; }

    public int Cantidad { get; set; }

    public double Costo { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<StockProducto> StockProductos { get; } = new List<StockProducto>();
}
