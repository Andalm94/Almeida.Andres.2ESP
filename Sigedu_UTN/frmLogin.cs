using System;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using Biblioteca_de_clases;
using Microsoft.VisualBasic.ApplicationServices;

namespace Sigedu_UTN
{
    public partial class frmLogin : Form
    {

        private int tipoDeUsuarioLogueado;
        List<usuarioUTN> usuarios;
        usuarioUTN? usuarioLogueado;

        public string? usuarioIngresado;
        private string? passIngresada;

        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }


        //Login:
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            usuarioIngresado = txtUser.Text;
            passIngresada = txtPassword.Text;

            usuarioLogueado = Connection.ObtenerDatosAccesoUsuario(usuarioIngresado);

            tipoDeUsuarioLogueado = ValidarUsuario(usuarioLogueado, usuarioIngresado, passIngresada);

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
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }

        }

        private int ValidarUsuario(usuarioUTN usuarioLogueado, string user, string pass)
        {
            int respuesta = -1;

            if(usuarioLogueado.User == user && usuarioLogueado.Password == pass)
            {
                respuesta = usuarioLogueado.TipoUsuario;
            }

            return respuesta;
        }






        //Botones de carga de datos de acceso:
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



        //===================================================================================================
        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


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