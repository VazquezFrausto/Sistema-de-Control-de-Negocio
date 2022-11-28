namespace EntidadesControlNegocio
{
    public class Productos
    {
        public Productos(int id, string nombre, string descripcion, double precio, int idMedida, int idCategoria)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            IdMedida = idMedida;
            IdCategoria = idCategoria;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int IdMedida { get; set; }
        public int IdCategoria { get; set; }
    }
}
