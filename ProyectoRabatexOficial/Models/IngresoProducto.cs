using System;
using System.Collections.Generic;

namespace ProyectoRabatexOficial.Models;

public partial class IngresoProducto
{
    public int IdIngreso { get; set; }

    public int IdProducto { get; set; }

    public int IdRelacion { get; set; }

    public virtual Ingreso IdIngresoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
