using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManejadoresControlNegocio;

namespace PresentacionControlNegocio
{
    public partial class FrmSalesDetails : Form
    {
        ManejadorVentas manejadorVentas;
        ManejadorDetallesVentas manejadorDetallesVentas;

        public FrmSalesDetails()
        {
            manejadorVentas = new ManejadorVentas();
            manejadorDetallesVentas = new ManejadorDetallesVentas();
            InitializeComponent();
        }

        void Actualizar()
        {
            manejadorVentas.Consultar(dgvVentas);
        }


        private void FrmSalesDetails_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int idVenta = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["id"].Value.ToString());
                manejadorDetallesVentas.Consultar(idVenta);
            }
        }
    }
}
