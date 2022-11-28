using System.Windows.Forms;
using AccesoDatosControlNegocio;
using EntidadesControlNegocio;

namespace ManejadoresControlNegocio
{
    public class ManejadorCategorias
    {
        ConexionCategorias conexionCategorias;
        public ManejadorCategorias()
        {
            conexionCategorias = new ConexionCategorias();
        }

        public void Guardar(string nombre)
        {
            conexionCategorias.Guardar(nombre);
        }

        public void Consultar(DataGridView dgvCategorias)
        {
            dgvCategorias.DataSource = conexionCategorias.Consultar();
            dgvCategorias.Columns[0].HeaderText = "ID";
            dgvCategorias.Columns[1].HeaderText = "Nombre";
            //dgvCategorias.Columns.Add(new DataGridViewButtonColumn()
            //{
            //    Text = "Editar",
            //    UseColumnTextForButtonValue = true,
            //    FlatStyle= FlatStyle.Flat,
            //});
            //dgvCategorias.Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(5, 110, 156);
        }
    }
}
