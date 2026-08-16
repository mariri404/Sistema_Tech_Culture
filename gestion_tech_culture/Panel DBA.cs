using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_tech_culture
{
    public partial class Panel_DBA : Form
    {
        public Panel_DBA()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Usar el método de ConexionDB para actualizar el DataGridView
            ConexionDB.ActualizarDGV(cboTablas.Text, dgvDatos, false);

            //Si la tabla seleccionada es HistorialVentas, se deshabilita la edición del DGV
            if (cboTablas.Text == "HistorialVentas")
            {
                dgvDatos.ReadOnly = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Usar el método de ConexionDB para buscar el registro
            ConexionDB.BuscarRegistro(cboTablas.Text, dgvDatos);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        { 
            //Agregar empleado
            if (cboTablas.Text == "Empleados")
            {
                AgregarEmpleado ventanaAgregarEmpleado = new AgregarEmpleado();
                ventanaAgregarEmpleado.Show();
            }
            //Agregar laptop
            else if (cboTablas.Text == "Laptops")
            {
                AgregarLaptop ventanaAgregarLaptop = new AgregarLaptop();
                ventanaAgregarLaptop.Show();
            }
            //El historial de ventas se actualiza solo
            else if(cboTablas.Text == "HistorialVentas")
            {
                MessageBox.Show("Las ventas son registradas automáticamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //La edición se hace directamente desde el DataGridView
        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Se guarda la fila y columna de la celda editada
                int filaIndex = e.RowIndex;
                int columnaIndex = e.ColumnIndex;

                //Se guarda el nombre de la columna y el valor que se editó
                object nombreCampo = dgvDatos.Columns[columnaIndex].Name;
                object nuevoValor = dgvDatos.Rows[filaIndex].Cells[columnaIndex].Value;

                //Se guarda el código de la entidad editada
                object codigo = Convert.ToInt32(dgvDatos.Rows[filaIndex].Cells["Codigo"].Value);

                //Se establece y ejecuta la query de actualización
                string query = $"UPDATE {cboTablas.Text} SET {nombreCampo} = @nuevoValor WHERE Codigo = @codigo";

                SqlCommand cmd = new SqlCommand(query, ConexionDB.ObtenerConexion());
                cmd.Parameters.AddWithValue("@nuevoValor", nuevoValor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@codigo", codigo);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Dato actualizado en la BD.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar la base de datos.", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Si la tabla seleccionada es HistorialVentas, no se permite eliminar registros
            if (cboTablas.Text == "HistorialVentas")
            {
                MessageBox.Show("No se pueden eliminar registros del historial de ventas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Query y conexión
            string query = $"DELETE FROM {cboTablas.Text} WHERE Codigo = @codigo";
            SqlCommand cmd = new SqlCommand(query, ConexionDB.ObtenerConexion());

            //Usar el método de ConexionDB para buscar el registro
            int codigo = ConexionDB.BuscarRegistro(cboTablas.Text, dgvDatos);

            //Confirmar la eliminación de la fila
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.AddWithValue("@codigo", codigo);
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else { MessageBox.Show("Eliminación cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information); }
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
