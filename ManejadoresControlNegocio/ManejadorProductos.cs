using AccesoDatosControlNegocio;
using System.Drawing;
using System.Windows.Forms;

namespace ManejadoresControlNegocio
{
    public class ManejadorProductos
    {
        ConexionProductos conexionProductos;
        public ManejadorProductos()
        {
            conexionProductos= new ConexionProductos();
        }

        public void Guardar(string nombre, string descripcion, double precio, int categoria, int medida)
        {
            conexionProductos.Guardar(nombre, descripcion, precio, categoria, medida);
        }

        public void Actualizar(string nombre, string descripcion, double precio, int categoria, int medida, int id)
        {
            conexionProductos.Actualizar(nombre, descripcion, precio, categoria, medida, id);
        }

        public void Eliminar(int id)
        {
            conexionProductos.Eliminar(id); 
        }

        public void Consultar(DataGridView dgvProductos, string buscar = null)
        {
            dgvProductos.Columns.Clear();
            dgvProductos.DataSource = conexionProductos.Consultar(buscar);
            dgvProductos.Columns[0].HeaderText = "ID";
            dgvProductos.Columns[1].HeaderText = "Nombre";
            dgvProductos.Columns[2].HeaderText = "Descripción";
            dgvProductos.Columns[3].HeaderText = "Precio";
            dgvProductos.Columns[4].HeaderText = "Medida";
            dgvProductos.Columns[5].HeaderText = "Categoria";

            dgvProductos.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
            });

            dgvProductos.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
            });
            dgvProductos.Columns[6].DefaultCellStyle.BackColor = Color.FromArgb(5, 110, 156);
            dgvProductos.Columns[6].DefaultCellStyle.ForeColor = Color.White;
            dgvProductos.Columns[7].DefaultCellStyle.BackColor = Color.FromArgb(240, 0, 36);
            dgvProductos.Columns[7].DefaultCellStyle.ForeColor = Color.White;
        }

        public void CargarDatos(ComboBox cmbMedidas, ComboBox cmbCategorias)
        {
            ConexionMedidas conexionMedidas = new ConexionMedidas();
            cmbMedidas.DataSource = conexionMedidas.CargarMedidas();
            cmbMedidas.DisplayMember = "nombre";
            cmbMedidas.ValueMember= "id";

            ConexionCategorias conexionCategorias = new ConexionCategorias();
            cmbCategorias.DataSource = conexionCategorias.CargarCategorias();
            cmbCategorias.DisplayMember = "nombre";
            cmbCategorias.ValueMember= "id";
        }
    }
}
