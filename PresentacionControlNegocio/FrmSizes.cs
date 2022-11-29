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
    public partial class FrmSizes : Form
    {
        ManejadorMedidas manejadorMedidas;

        public FrmSizes()
        {
            manejadorMedidas = new ManejadorMedidas();
            InitializeComponent();
        }

        void Limpiar()
        {
            txtAbreviatura.Clear();
            txtNombre.Clear();
        }

        void Actualizar() => manejadorMedidas.Consultar(dgvMedidas);

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSizes_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtAbreviatura.Text) || string.IsNullOrEmpty(txtNombre.Text)))
            {
                manejadorMedidas.Guardar(txtNombre.Text, txtAbreviatura.Text);
            }
            Limpiar();
            Actualizar();
        }
    }
}
