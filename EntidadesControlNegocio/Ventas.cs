namespace EntidadesControlNegocio
{
    public class Ventas
    {
        public Ventas(int id, double total, string fecha)
        {
            Id = id;
            Total = total;
            Fecha = fecha;
        }

        public int Id { get; set; }
        public double Total { get; set; }
        public string Fecha { get; set; }
    }
}
