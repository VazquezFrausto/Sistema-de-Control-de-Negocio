namespace EntidadesControlNegocio
{
    public class Almacenes
    {
        public Almacenes(int id, int idProducto, string producto, int cantidad)
        {
            Id = id;
            IdProducto = idProducto;
            Producto = producto;
            Cantidad = cantidad;
        }

        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
