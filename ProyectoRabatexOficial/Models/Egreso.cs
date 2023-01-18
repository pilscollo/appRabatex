using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRabatexOficial.Models;

public partial class Egreso
{
    public DateTime Fecha { get; set; }

    public double Monto { get; set; }

    public string Tipo { get; set; } = null!;
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int Estado { get; set; }
}
