using System;
using System.Collections.Generic;

namespace ProyectoRabatexOficial.Models;

public partial class StockProducto
{
    public int IdStock { get; set; }

    public int IdProducto { get; set; }

    public int IdRelacion { get; set; }

   

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Stock IdStockNavigation { get; set; } = null!;
}
