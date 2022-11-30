namespace EntidadesControlNegocio
{
    public class ListaVenta
    {
        public ListaVenta(int id, string nombre, double precio, int cantidad, double subtotal)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
    }
}
