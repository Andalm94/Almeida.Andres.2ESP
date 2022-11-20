using Biblioteca_de_clases;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sigedu_UTN
{
    public partial class frmAlumno : Form
    {
        Alumno alumnoLogueado;
        BindingList<string> materiasCursando;

        public frmAlumno(string user)
        {
            InitializeComponent();
            alumnoLogueado = Connection.BuscarAlumnoPorUser(user);
            this.materiasCursando = Connection.ObtenerListadoDeMateriasCursandoDeAlumnoSeleccionado(alumnoLogueado.Id);
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            cmbMaterias.DataSource = materiasCursando;
            lblNombre.Text = alumnoLogueado.Nombre;
        }


        private void btnMaterias_Click(object sender, EventArgs e)
        {
            frmInscripcionMaterias frmInscripcionMaterias = new frmInscripcionMaterias(alumnoLogueado);
            frmInscripcionMaterias.Show();
            this.Hide();
        }

        private void btnDarAsistencia_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Has dado el presente a {cmbMaterias.Text} exitosamente");
        }




        //===================================================================================================
        //Funcionalidad para mover la ventana arrastrando el pnlTop
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }


    }
}
