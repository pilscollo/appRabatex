using System;
using System.Collections.Generic;

namespace ProyectoRabatexOficial.Models;

public partial class IngresoCliente
{
    public int IdIngreso { get; set; }

    public int IdCliente { get; set; }

    public int IdRelacion { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Ingreso IdIngresoNavigation { get; set; } = null!;
}
