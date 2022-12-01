using ManejadoresControlNegocio;
using System;
using System.Windows.Forms;

namespace PresentacionControlNegocio
{
    public partial class FrmAddProduct : Form
    {
        public static bool actualizar = false;
        int id;
        string nombre, descripcion, categoria, medida;
        double precio;
        ManejadorProductos manejadorProductos;

        public FrmAddProduct(int id = 0, string nombre = "", string descripcion = "", 
            double precio = 0, string medida = "", string categoria = "")
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.categoria = categoria;
            this.medida = medida;
            manejadorProductos = new ManejadorProductos();
            InitializeComponent();
        }

        void Actualizar()
        {
            manejadorProductos.CargarDatos(cmbMedida, cmbCategoria);
            if (cmbMedida.Items.Count == 0 || cmbCategoria.Items.Count == 0)
            {
                MessageBox.Show("No hay categorías o medidas existentes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            cmbCategoria.SelectedIndex = 0;
            cmbMedida.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            Actualizar();
            if (actualizar)
            {
                txtNombre.Text = nombre;
                txtDescripcion.Text = descripcion;
                txtPrecio.Text = precio.ToString();
                cmbCategoria.Text = categoria; 
                cmbMedida.Text = medida;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text)))
                {
                    if (!actualizar)
                    {
                        manejadorProductos.Guardar(txtNombre.Text, txtDescripcion.Text,
                            Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(cmbCategoria.SelectedValue.ToString()),
                            Convert.ToInt32(cmbMedida.SelectedValue.ToString()));
                    }
                    else
                    {
                        manejadorProductos.Actualizar(txtNombre.Text, txtDescripcion.Text,
                            Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(cmbCategoria.SelectedValue.ToString()),
                            Convert.ToInt32(cmbMedida.SelectedValue.ToString()), id);
                        Limpiar();
                        Close();
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Limpiar();
        }
    }
}
