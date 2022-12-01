using AccesoDatosControlNegocio;
using System.Drawing;
using System.Windows.Forms;

namespace ManejadoresControlNegocio
{
    public class ManejadorVentas
    {
        ConexionVentas conexionVentas;
        public ManejadorVentas()
        {
            conexionVentas = new ConexionVentas();
        }

        public void Guardar(double total, string fecha)
        {
            conexionVentas.Guardar(total, fecha);
        }

        public void Consultar(DataGridView dgvVentas)
        {
            dgvVentas.Columns.Clear();
            dgvVentas.DataSource = conexionVentas.Consultar();
            dgvVentas.Columns[0].HeaderText = "ID";
            dgvVentas.Columns[1].HeaderText = "Total";
            dgvVentas.Columns[2].HeaderText = "Fecha";
            dgvVentas.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Ver detalles",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
            });
            dgvVentas.Columns[3].DefaultCellStyle.BackColor = Color.FromArgb(160, 64, 219);
            dgvVentas.Columns[3].DefaultCellStyle.ForeColor = Color.White;
        }
    }
}
