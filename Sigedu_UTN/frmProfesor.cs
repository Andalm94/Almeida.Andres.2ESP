using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca_de_clases;
using Microsoft.VisualBasic;

namespace Sigedu_UTN
{
    public partial class frmProfesor : Form
    {

        //--------------------------------------------------------------------------
        //Declaracion de variables a utilizar en el formulario:

        Profesor profesorLogueado;
        private string user;

        BindingList<string> materiasDictando = new BindingList<string>();
        BindingList<string> examenesMostrados = new BindingList<string>();
        BindingList<string> listadoAlumnosAEvaluar = new BindingList<string>();
        Dictionary<string, int> alumnosEvaluados = new Dictionary<string, int>();


        Materia materiaSeleccionada = new Materia();
        Alumno alumnoSeleccionado = new Alumno();



        //--------------------------------------------------------------------------


        public frmProfesor(string user)
        {
            InitializeComponent();
            profesorLogueado = Connection.BuscarProfesorPorUser(user);
        }


        private void frmProfesor_Load_1(object sender, EventArgs e)
        {

            //Se carga el listado de materias del profesor logueado
            materiasDictando = Connection.ObtenerListadoDeMateriasDictandoDeProfesorSeleccionado(profesorLogueado.Id);

            cmbMateria.DataSource = materiasDictando;

            listMaterias.DataSource = materiasDictando;

            


            //Se cargan los datos del profesor logueado
            lblNombre.Text = profesorLogueado.Nombre;
            txtTelefono.Text = profesorLogueado.Telefono;
            txtMail.Text = profesorLogueado.Email;

        }

        //------------------------------------ Crear examen -------------------------------------

        private void btnCrearExamen_Click(object sender, EventArgs e)
        {
            Materia materiaNuevoExamen = Connection.BuscarMateriaPorNombre(listMaterias.Text);
            string nombreExamen = txtNombreExamen.Text;
            string fecha = dttFecha.Text;

            Connection.CrearNuevoExamen(nombreExamen, fecha, materiaNuevoExamen.Id);

            txtNombreExamen.Text = "";
        }



        //------------------------------------ Corregir examen -------------------------------------


        private void cmbMateria_TextChanged(object sender, EventArgs e)
        {
            materiaSeleccionada = Connection.BuscarMateriaPorNombre(cmbMateria.Text);
            cmbExamenes.DataSource = Connection.ObtenerListadoExamenesDeMateriaSeleccionada(materiaSeleccionada.Id);
            cmbAlumnosEvaluados.Text = "";
            cmbExamenes.Text = "";
        }

        private void cmbExamenes_TextChanged(object sender, EventArgs e)
        {
            cmbAlumnosEvaluados.Text = "";
            Examen examenSeleccionado = Connection.BuscarExamenPorNombre(cmbExamenes.Text);
            lblExamenFecha.Text = $"Fecha: {examenSeleccionado.Fecha}";
            listadoAlumnosAEvaluar = Connection.ObtenerListadoDeNombresDeAlumnosQueCursanLaMateria(materiaSeleccionada.Id);
            cmbAlumnosEvaluados.DataSource = listadoAlumnosAEvaluar;

        }




        private void btnCalificar_Click(object sender, EventArgs e)
        {
            alumnoSeleccionado = Connection.BuscarAlumnoPorNombre(cmbAlumnosEvaluados.Text);
            float nota = (float)numNota.Value;
            Connection.CargarNotaAAlumno(alumnoSeleccionado.Id, materiaSeleccionada.Id, nota);
            
            listadoAlumnosAEvaluar.Remove(alumnoSeleccionado.Nombre);
            cmbAlumnosEvaluados.DataSource = listadoAlumnosAEvaluar;


            cmbAlumnosEvaluados.Text = "";
            lblUltimoCalificado.Text = $"Alumno evaluado: {alumnoSeleccionado.Nombre}";
            lblUltimaNota.Text = $"Nota asignada: {nota}";

        }


        private void RefrescarListados()
        {
            cmbAlumnosEvaluados.DataSource = listadoAlumnosAEvaluar;
        }



        //==============================================================================================

        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();

        }

        private void btnEditarDatos_Click(object sender, EventArgs e)
        {


            if (txtTelefono.Visible == true)
            {


                lblDatoTelefono.Text = txtTelefono.Text;
                txtTelefono.Text = "";

                lblDatoMail.Text = txtMail.Text;
                txtMail.Text = "";

                txtTelefono.Visible = false;
                txtMail.Visible = false;

                btnEditarDatos.Text = "Actualizar datos";


            }
            else
            {

                txtTelefono.Visible = true;
                txtMail.Visible = true;

                btnEditarDatos.Text = "Guardar datos";

            }

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
