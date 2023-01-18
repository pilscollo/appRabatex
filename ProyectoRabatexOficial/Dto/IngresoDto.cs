namespace ProyectoRabatexOficial.Dto
{
    public class IngresoDto
    {
        public DateTime Fecha { get; set; }

        public double Monto { get; set; }
        public string Detalle { get; set; } = null!;


    }
}
