using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_tech_culture
{
    public partial class Panel_AnalistaVentas : Form
    {
        public Panel_AnalistaVentas()
        {
            InitializeComponent();

            //Se carga el DGV con todas las ventas
            ConexionDB.ActualizarDGV("HistorialVentas", dgvVentas, false);
        }

        //Procedimiento para mostrar el reporte de ventas
        private void CalcularTotales(DataTable dt)
        {
            int totalUnidades = 0;
            decimal totalMonto = 0;

            //Se busca la cantidad y total de venta entre todas las ventas (que cunplen
            //con los requisitos)
            foreach (DataRow fila in dt.Rows)
            {
                totalUnidades += Convert.ToInt32(fila["Cantidad"]);
                totalMonto += Convert.ToDecimal(fila["Total"]);
            }
            lbCantidadVendida.Text = totalUnidades.ToString();
            lbTotalVentas.Text = totalMonto.ToString("N2");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            SesionUsuario.MostrarLogin();
        }

        //Para manipular las ventas vistas en el DGV:
        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            //Query base
            string query = "SELECT * FROM HistorialVentas WHERE Fecha >= @Desde AND Fecha <= @Hasta";

            string criterioBusqueda = cboBuscarPor.Text; 
            string valorTexto = txtCodigo.Text.Trim();

            // Si el usuario escribió un código/valor para buscar
            try
            {
                if (!string.IsNullOrEmpty(valorTexto) && int.TryParse(valorTexto, out int codigoIngresado))
                {
                    switch (criterioBusqueda)
                    {
                        case "Código de Venta":
                            query += " AND Codigo = @Codigo";
                            break;

                        case "Código de Empleado":
                            query += " AND CodigoEmpleado = @Codigo";
                            break;

                        case "Código de Laptop":
                            query += " AND CodigoLaptop = @Codigo";
                            break;

                        case "Mostrar todo":
                            txtCodigo.Text = "-";
                            break;

                        default:
                            MessageBox.Show("Seleccione un modo de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("El código introducido no existe.", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            using (SqlConnection conx = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conx);

                //Filtros de fecha (Ajustamos horas para incluir todo el día de inicio y fin)
                cmd.Parameters.AddWithValue("@Desde", dtpDesde.Value.Date);
                cmd.Parameters.AddWithValue("@Hasta", dtpHasta.Value.Date.AddDays(1).AddTicks(-1));

                if (!string.IsNullOrEmpty(valorTexto) && int.TryParse(valorTexto, out int valor))
                {
                    cmd.Parameters.AddWithValue("@Codigo", valor);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                //Asignamos la tabla al DataGridView
                dgvVentas.DataSource = dt;

                //Se calculan los totales de la parte inferior
                CalcularTotales(dt);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbFechaImporta_CheckedChanged(object sender, EventArgs e)
        {
            //Si no se toma en cuenta la fecha, se asigna una fecha para incluir todas las ventas
            if (!cbFechaImporta.Checked)
            {
                dtpDesde.Value = new DateTime(2015, 1, 1);
                dtpDesde.Enabled = false;
                dtpHasta.Value = DateTime.Now;
                dtpHasta.Enabled = false;
            }
        }
    }
}
