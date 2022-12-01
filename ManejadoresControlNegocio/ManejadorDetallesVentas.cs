using AccesoDatosControlNegocio;
using System.Windows.Forms;

namespace ManejadoresControlNegocio
{
    public class ManejadorDetallesVentas
    {
        ConexionDetalleVentas conexionDetalle;
        public ManejadorDetallesVentas()
        {
            conexionDetalle = new ConexionDetalleVentas();
        }

        public void Guardar(int idProducto, int cantidad, double precio)
        {
            conexionDetalle.Guardar(idProducto, cantidad, precio);
        }

        public void Consultar(int idVenta)
        {
            string detalles = "";
            foreach (var item in conexionDetalle.Consultar(idVenta))
            {
                detalles += $"{item.Cantidad} {item.Nombre}\t${item.Precio}\n";
            }
            MessageBox.Show(detalles, $"Detalles de la venta #{idVenta}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
