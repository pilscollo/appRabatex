using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRabatexOficial.Models;

public partial class StockProducto
{
    public int IdStock { get; set; }

    public int IdProducto { get; set; }

    [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRelacion { get; set; }

   

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Stock IdStockNavigation { get; set; } = null!;
}
