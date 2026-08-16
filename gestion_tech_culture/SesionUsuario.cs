using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_tech_culture
{
    public static class SesionUsuario
    {
        public static Empleado EmpleadoActual { get; set; }

        public static void MostrarLogin()
        {
            TechCultureLogin ventanaLogin = new TechCultureLogin();
            ventanaLogin.Show();
        }
    }
}
