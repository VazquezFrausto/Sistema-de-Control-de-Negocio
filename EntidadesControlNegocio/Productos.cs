namespace EntidadesControlNegocio
{
    public class Productos
    {
        public Productos(int id, string nombre, string descripcion, double precio, string medida, string categoria)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Medida = medida;
            Categoria = categoria;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Medida { get; set; }
        public string Categoria { get; set; }
    }
}
