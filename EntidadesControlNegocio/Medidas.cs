namespace EntidadesControlNegocio
{
    public class Medidas
    {
        public Medidas(int id, string nombre, string abreviatura)
        {
            Id = id;
            Nombre = nombre;
            Abreviatura = abreviatura;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
}
