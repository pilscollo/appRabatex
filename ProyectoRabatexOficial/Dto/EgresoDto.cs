using System;
using System.Collections.Generic;

namespace ProyectoRabatexOficial.Models;

public partial class EgresoDto
{
    public DateTime Fecha { get; set; }

    public double Monto { get; set; }

    public string Tipo { get; set; } = null!;

}
