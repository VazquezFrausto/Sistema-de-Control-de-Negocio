namespace EntidadesControlNegocio
{
    public class DetallesVentas
    {
        public DetallesVentas(int id, int venta, string nombre, int cantidad, double precio)
        {
            Id = id;
            Venta = venta;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }

        public int Id { get; set; }
        public int Venta { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
