using System;
using System.Collections.Generic;

namespace ProyectoRabatexOficial.Models;

public partial class Egreso
{
    public DateTime Fecha { get; set; }

    public double Monto { get; set; }

    public string Tipo { get; set; } = null!;

    public int Id { get; set; }

    public int Estado { get; set; }
}
