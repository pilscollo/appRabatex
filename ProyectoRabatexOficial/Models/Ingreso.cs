using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRabatexOficial.Models;

public partial class Ingreso
{
    public DateTime Fecha { get; set; }

    public double Monto { get; set; }

    public int IdProducto { get; set; }

    public string Detalle { get; set; } = null!;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<IngresoProducto> IngresoProductos { get; } = new List<IngresoProducto>();
    public virtual ICollection<IngresoCliente> IngresoClientes { get; } = new List<IngresoCliente>();
}
