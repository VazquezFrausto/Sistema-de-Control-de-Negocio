namespace EntidadesControlNegocio
{
    public class Categorias
    {
        public Categorias(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
