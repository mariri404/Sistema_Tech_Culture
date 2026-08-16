using Microsoft.VisualBasic;
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
    public partial class Panel_AnalistaNomina : Form
    {
        public Panel_AnalistaNomina()
        {
            InitializeComponent();
        }

        private void Panel_AnalistaNomina_Load(object sender, EventArgs e)
        {

        }

        private void btnCalcularSueldo_Click(object sender, EventArgs e)
        {
            //Verificar si el campo está vacío
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor ingrese el código del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Conexión a la DB
            string query = "SELECT NombreYApellido, SueldoBase, FechaIngreso FROM Empleados WHERE Codigo = @codigo";
            using (SqlConnection conx = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conx);
                cmd.Parameters.AddWithValue("@codigo", Convert.ToInt32(txtCodigo.Text));

                //Leer los datos de la DB según el código
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) //True si el código existe
                    {
                        //Cargar los datos de la DB en el Form
                        txtNombre.Text = reader["NombreYApellido"].ToString();
                        txtSueldoBase.Text = reader["SueldoBase"].ToString();
                        txtFechaIngreso.Text = reader["FechaIngreso"].ToString();

                        //Validar que el campo de horas trabajadas no esté vacío
                        if (string.IsNullOrWhiteSpace(txtHorasTrabajadas.Text))
                        {
                            MessageBox.Show("Por favor ingrese las horas trabajadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            //Definir las variables necesarias usando un objeto Empleado
                            Empleado emp = new Empleado();
                            emp.SueldoBase = Convert.ToDecimal(txtSueldoBase.Text);
                            emp.FechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text);
                            int ht = Convert.ToInt32(txtHorasTrabajadas.Text);

                            //Calcular los valores y mostrarlos en el Form
                            txtHorasExtras.Text = emp.CalcularHorasExtras(ht).ToString("N2");
                            txtARS.Text = emp.CalcularARS().ToString("N2");
                            txtAFP.Text = emp.CalcularAFP().ToString("N2");
                            txtISR.Text = emp.CalcularISR().ToString("N2");
                            txtBonificacion.Text = emp.CalcularBonificacion().ToString("N2");
                            txtTotalGeneral.Text = emp.CalcularSueldoTotal(ht).ToString("N2");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El código ingresado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtSueldoBase.Clear();
            txtFechaIngreso.Clear();
            txtHorasTrabajadas.Clear();
            txtHorasExtras.Clear();
            txtARS.Clear();
            txtAFP.Clear();
            txtISR.Clear();
            txtBonificacion.Clear();
            txtTotalGeneral.Clear();
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
