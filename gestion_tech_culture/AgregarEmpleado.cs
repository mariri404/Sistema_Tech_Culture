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
    public partial class AgregarEmpleado : Form
    {
        public AgregarEmpleado()
        {
            InitializeComponent();
        }

        private void AgregarEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void cboPuesto_SelectedIndexChanged(object sender, EventArgs e)
        { 
            //Obtener el puesto seleccionado
            string puesto = cboPuesto.SelectedItem.ToString();

            //Asignar un sueldo por defecto según el cargo
            switch (puesto)
            {
                case "DBA":
                    txtSueldoBase.Text = "110000.00";
                    break;

                case "Analista de nómina":
                    txtSueldoBase.Text = "55000.00";
                    break;

                case "Cajero":
                    txtSueldoBase.Text = "28000.00";
                    break;

                case "Analista de ventas":
                    txtSueldoBase.Text = "52000.00";
                    break;

                default:
                    txtSueldoBase.Text = "25000.00";
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Crear un objeto Empleado
            Empleado nuevoEmp = new Empleado();

            //Verificar que el puesto no esté nulo
            if (cboPuesto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un puesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nuevoEmp.Puesto = cboPuesto.SelectedItem.ToString();

            //Guardar los datos en un objeto
            
            nuevoEmp.Contraseña = txtContraseña.Text;
            nuevoEmp.NombreYApellido = txtNombreApellido.Text;
            nuevoEmp.Cedula = txtCedula.Text;
            nuevoEmp.Correo = txtCorreo.Text;
            nuevoEmp.Puesto = cboPuesto.SelectedItem.ToString();
            nuevoEmp.Telefono = txtTelefono.Text;
            nuevoEmp.Direccion = txtDireccion.Text;
            nuevoEmp.FechaIngreso = dtpFechaIngreso.Value;
            nuevoEmp.SueldoBase = decimal.Parse(txtSueldoBase.Text);

            //Verificar si falta algún dato
            if (string.IsNullOrEmpty(nuevoEmp.Contraseña) || 
                string.IsNullOrEmpty(nuevoEmp.NombreYApellido) || 
                string.IsNullOrEmpty(nuevoEmp.Cedula) || 
                string.IsNullOrEmpty(nuevoEmp.Correo) || 
                string.IsNullOrEmpty(nuevoEmp.Puesto) || 
                string.IsNullOrEmpty(nuevoEmp.Telefono) || 
                string.IsNullOrEmpty(nuevoEmp.Direccion) || 
                string.IsNullOrEmpty(txtSueldoBase.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Si no falta ninguno, se ejecuta la query
            else
            {
                //Query
                string query = @"INSERT INTO Empleados 
                (Contraseña, NombreYApellido, Cedula, Correo, Puesto, Telefono, Direccion, FechaIngreso, SueldoBase) 
                VALUES 
                (@contraseña, @nombre, @cedula, @correo, @puesto, @telefono, @direccion, @fecha, @sueldo)";

                //Conexión
                using (ConexionDB.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, ConexionDB.ObtenerConexion());

                    //Se guardan los datos del objeto en la base de datos
                    cmd.Parameters.AddWithValue("@contraseña", nuevoEmp.Contraseña);
                    cmd.Parameters.AddWithValue("@nombre", nuevoEmp.NombreYApellido);
                    cmd.Parameters.AddWithValue("@cedula", nuevoEmp.Cedula);
                    cmd.Parameters.AddWithValue("@correo", nuevoEmp.Correo);
                    cmd.Parameters.AddWithValue("@puesto", nuevoEmp.Puesto);
                    cmd.Parameters.AddWithValue("@telefono", nuevoEmp.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", nuevoEmp.Direccion);
                    cmd.Parameters.AddWithValue("@fecha", nuevoEmp.FechaIngreso);
                    cmd.Parameters.AddWithValue("@sueldo", nuevoEmp.SueldoBase);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Empleado agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtContraseña.Clear();
            txtNombreApellido.Clear();
            txtCedula.Clear();
            txtCorreo.Clear();
            cboPuesto.Text = "";
            txtTelefono.Clear();
            txtDireccion.Clear();
            dtpFechaIngreso.Value = DateTime.Now;
            txtSueldoBase.Clear();
        }
    }
}
