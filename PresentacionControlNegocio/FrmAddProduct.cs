using ManejadoresControlNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionControlNegocio
{
    public partial class FrmAddProduct : Form
    {
        public static bool actualizar = false;
        ManejadorProductos manejadorProductos;

        public FrmAddProduct()
        {
            manejadorProductos = new ManejadorProductos();
            InitializeComponent();
        }

        void Actualizar()
        {
            manejadorProductos.CargarDatos(cmbMedida, cmbCategoria);
        }

        void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!actualizar)
            {
                manejadorProductos.Guardar(txtNombre.Text, txtDescripcion.Text,
                    Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(cmbCategoria.SelectedValue.ToString()),
                    Convert.ToInt32(cmbMedida.SelectedValue.ToString()));
            }
            Limpiar();
        }
    }
}
