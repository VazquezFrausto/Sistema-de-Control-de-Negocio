using ManejadoresControlNegocio;
using System;
using System.Windows.Forms;

namespace PresentacionControlNegocio
{
    public partial class FrmProducts : Form
    {
        ManejadorProductos manejadorProductos;

        public FrmProducts()
        {
            manejadorProductos = new ManejadorProductos();
            InitializeComponent();
        }

        void Actualizar() => manejadorProductos.Consultar(dgvProductos);


        private void FrmProducts_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAddProduct frmAddProduct = new FrmAddProduct();
            FrmAddProduct.actualizar = false;
            frmAddProduct.ShowDialog();
            Actualizar();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                FrmAddProduct frmAddProduct = new FrmAddProduct(
                    Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString()),
                    dgvProductos.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    dgvProductos.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Convert.ToDouble(dgvProductos.Rows[e.RowIndex].Cells[3].Value.ToString()),
                    dgvProductos.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    dgvProductos.Rows[e.RowIndex].Cells[5].Value.ToString());
                FrmAddProduct.actualizar = true;
                frmAddProduct.ShowDialog();
                Actualizar();
            }
            else if (e.ColumnIndex == 7)
            {
                manejadorProductos.Eliminar(Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString()));
                Actualizar();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            manejadorProductos.Consultar(dgvProductos, txtBuscar.Text);
        }
    }
}
