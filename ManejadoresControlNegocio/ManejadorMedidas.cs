using AccesoDatosControlNegocio;
using System.Windows.Forms;

namespace ManejadoresControlNegocio
{
    public class ManejadorMedidas
    {
        ConexionMedidas conexionMedidas;
        public ManejadorMedidas()
        {
            conexionMedidas = new ConexionMedidas();
        }

        public void Guardar(string nombre, string abreviatura)
        {
            conexionMedidas.Guardar(nombre, abreviatura);
        }

        public void Consultar(DataGridView dgvMedidas)
        {
            dgvMedidas.DataSource = conexionMedidas.Consultar();
            dgvMedidas.Columns[0].Visible = false;
            dgvMedidas.Columns[0].HeaderText = "ID";
            dgvMedidas.Columns[1].HeaderText = "Nombre";
            dgvMedidas.Columns[2].HeaderText = "Abreviatura";
        }
    }
}
