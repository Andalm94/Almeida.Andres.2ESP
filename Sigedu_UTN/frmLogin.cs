using System;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using Biblioteca_de_clases;
using Microsoft.VisualBasic.ApplicationServices;

namespace Sigedu_UTN
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        //========================================= LOGIN ==================================================
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //Se recibe el usuario y contraseņa ingresados.
            //Se buscan los datos del usuario ingresado
            string usuarioIngresado = txtUser.Text;
            string passIngresada = txtPassword.Text;
            usuarioUTN usuarioLogueado = ConnectionDao.ObtenerDatosAccesoUsuario(usuarioIngresado);



            //Se valida que la contraseņa ingresada corresponda al usuario ingresado
            //Devuelve el tipo de usuario logueado: (0:Admin | 1:Profesor | 2:Alumno)
            int tipoDeUsuarioLogueado = ValidarUsuario(usuarioLogueado, usuarioIngresado, passIngresada);

            if(tipoDeUsuarioLogueado != -1)
            {
                switch (tipoDeUsuarioLogueado)
                {
                    case 0:
                        frmAdmin frmAdmin = new frmAdmin();
                        frmAdmin.Show();
                        this.Hide();
                        break;
                    case 1:
                        frmProfesor frmProfesor = new frmProfesor(usuarioIngresado);
                        frmProfesor.Show();
                        this.Hide();
                        break;
                    case 2:
                        frmAlumno frmAlumno = new frmAlumno(usuarioIngresado);
                        frmAlumno.Show();
                        this.Hide();
                        break;
                }

            }
            else
            {
                MessageBox.Show("Usuario o contraseņa incorrectos.");
            }

        }


        /// <summary>
        /// Recibe un usuario y los datos de acceso ingresados.
        /// Valida que los datos de user/pass del usuario correspondan a los ingresados.
        /// </summary>
        /// <param name="usuarioLogueado">Usuario comado de la DB</param>
        /// <param name="user">Input del usuario</param>
        /// <param name="pass">Input del usuario</param>
        /// <returns>Devuelve el tipo de usuario logueado (0:Admin | 1:Profesor | 2:Alumno)</returns>
        private int ValidarUsuario(usuarioUTN usuarioLogueado, string user, string pass)
        {
            int respuesta = -1;

            if(usuarioLogueado.User == user && usuarioLogueado.Password == pass)
            {
                respuesta = usuarioLogueado.TipoUsuario;
            }

            return respuesta;
        }







        //=========================== Botones de hardcodeo de datos de acceso ========================================
        private void btnAdmin_Click(object sender, EventArgs e)
        {

            txtUser.Text = "admin";
            txtPassword.Text = "admin";
        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            txtUser.Text = "mrampi";
            txtPassword.Text = "mrampi";
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            txtUser.Text = "aalmeida";
            txtPassword.Text = "aalmeida";
        }






        //============================================ SALIR =========================================================
        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }





        //=========================== Funcionalidad para desplazar la ventana con el pnlTop ==========================
        int mouse;
        int mX;
        int mY;
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = 1;
            mX = e.X;
            mY = e.Y;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mX, MousePosition.Y - mY);
            }
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = 0;
        }
    }


}