using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_tech_culture
{
    public partial class Panel_Cajero : Form
    {
        public Panel_Cajero()
        {
            //Cargar el nombre del empleado en el Form
            InitializeComponent();
            lbEmpleado.Text = $"{SesionUsuario.EmpleadoActual.NombreYApellido}";

            //Cargar el DGV
            ConexionDB.ActualizarDGV("Laptops", dgvLaptops, false);
        }

        private void Panel_Cajero_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Se busca el código
            int codigo = ConexionDB.BuscarRegistro("Laptops", dgvLaptops);
            txtCodigo.Text = Convert.ToString(codigo);

            //Si encontró un código válido y hay filas en el DataGridView
            if (codigo > 0 && dgvLaptops.Rows.Count > 0)
            {
                //Se toma la fila encontrada
                DataGridViewRow fila = dgvLaptops.Rows[0];

                //Se llenan los textboxes con el DGV
                txtCodigo.Text = codigo.ToString();
                txtProducto.Text = $"{fila.Cells["Marca"].Value} {fila.Cells["Modelo"].Value}";
                txtStock.Text = fila.Cells["Stock"].Value.ToString();
                txtPrecio.Text = Convert.ToDecimal(fila.Cells["Precio"].Value).ToString("N2");  //Precio con dos decimales

                //Se limpia el monto total de la búsqueda anterior
                txtTotal.Clear();

                //Se desbloquea el botón de calcular total
                btnCalcularTotal.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontró el producto.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad a vender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int stock = Convert.ToInt32(txtStock.Text);

                if (cantidad > Convert.ToInt32(stock))
                {
                    MessageBox.Show($"Stock insuficiente. Solo quedan {stock} en inventario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Se calcula y muestra el total de la venta
                Venta v = new Venta();
                v.PrecioLaptop = Convert.ToDecimal(txtPrecio.Text);
                v.Cantidad = cantidad;

                txtTotal.Text = v.CalcularTotal().ToString("N2");

                //Se desbloquea el botón de completar la venta
                btnCompletarVenta.Enabled = true;
            }
        }

        private void btnCompletarVenta_Click(object sender, EventArgs e)
        {
            Venta nuevaVenta = new Venta();
            nuevaVenta.CodigoEmpleado = SesionUsuario.EmpleadoActual.Codigo; // ID del login
            nuevaVenta.CodigoLaptop = Convert.ToInt32(txtCodigo.Text);
            nuevaVenta.Cantidad = Convert.ToInt32(txtCantidad.Text);
            nuevaVenta.PrecioLaptop = Convert.ToDecimal(txtPrecio.Text);
            nuevaVenta.Total = Convert.ToDecimal(txtTotal.Text);

            //Se registra la venta si es exitosa
            if (nuevaVenta.RegistrarVenta())
            {
                MessageBox.Show("¡Venta registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Actualizar el DGV de las Laptops
                ConexionDB.ActualizarDGV("Laptops", dgvLaptops, false);

                //Se limpian los campos
                txtCodigo.Clear();
                txtProducto.Clear();
                txtStock.Clear();
                txtPrecio.Clear();
                txtCantidad.Clear();
                txtTotal.Clear();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al procesar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            SesionUsuario.MostrarLogin();
        }
    }
}
