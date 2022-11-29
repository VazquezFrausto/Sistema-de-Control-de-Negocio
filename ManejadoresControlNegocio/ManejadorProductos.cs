using AccesoDatosControlNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Consultar(DataGridView dgvProductos)
        {
            dgvProductos.DataSource = conexionProductos.Consultar();
            dgvProductos.Columns[0].HeaderText = "ID";
            dgvProductos.Columns[1].HeaderText = "Nombre";
            dgvProductos.Columns[2].HeaderText = "Descripción";
            dgvProductos.Columns[3].HeaderText = "Precio";
            dgvProductos.Columns[4].HeaderText = "Medida";
            dgvProductos.Columns[5].HeaderText = "Categoria";
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
