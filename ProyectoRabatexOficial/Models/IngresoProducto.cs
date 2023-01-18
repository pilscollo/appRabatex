using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRabatexOficial.Models;

public partial class IngresoProducto
{
    public float cantidad { get; set; }
    public int IdIngreso { get; set; }

    public int IdProducto { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRelacion { get; set; }

    public virtual Ingreso IdIngresoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
