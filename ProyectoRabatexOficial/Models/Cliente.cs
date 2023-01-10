using System;
using System.Collections.Generic;

namespace ProyectoRabatexOficial.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Localidad { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ICollection<IngresoCliente> IngresoClientes { get; } = new List<IngresoCliente>();
}
