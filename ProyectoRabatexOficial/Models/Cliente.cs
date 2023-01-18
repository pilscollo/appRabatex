using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRabatexOficial.Models;

public partial class Cliente
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Localidad { get; set; } = null!;

    public int Estado { get; set; }

    public virtual ICollection<IngresoCliente> IngresoClientes { get; } = new List<IngresoCliente>();
}
