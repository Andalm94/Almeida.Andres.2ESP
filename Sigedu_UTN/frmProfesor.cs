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

        BindingList<string> materiasDictando;
        BindingList<string> examenesMostrados;
        BindingList<string> listadoAlumnosAEvaluar;


        Materia materiaSeleccionada = new Materia();
        Alumno alumnoSeleccionado = new Alumno();



        //--------------------------------------------------------------------------


        public frmProfesor(string user)
        {
            InitializeComponent();
            //Busco el profesor logueado y cargo su listado de materias.
            profesorLogueado = ConnectionDao.BuscarProfesorPorUser(user);
            materiasDictando = ConnectionDao.ObtenerListadoDeMateriasDictandoDeProfesorSeleccionado(profesorLogueado.Id);
            cmbMateria.DataSource = materiasDictando;
            listMaterias.DataSource = materiasDictando;


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
            //Se busca la materia seleccionada en la DB.
            //Se toma el nombre y la fecha del examen.
            Materia materiaNuevoExamen = ConnectionDao.BuscarMateriaPorNombre(listMaterias.Text);
            string nombreExamen = txtNombreExamen.Text;
            string fecha = dttFecha.Text;


            //Con la informacion recibida se crea un nuevo examen.
            ConnectionDao.CrearNuevoExamen(nombreExamen, fecha, materiaNuevoExamen.Id);
            txtNombreExamen.Text = "";
            MessageBox.Show($"Examen creado exitosamente para la materia {materiaNuevoExamen.Nombre}");
        }



        //------------------------------------ Corregir examen -------------------------------------


        private void cmbMateria_TextChanged(object sender, EventArgs e)
        {
            //Se busca la materia seleccionada.
            //Se buscan los examenes asociados a la materia.
            materiaSeleccionada = ConnectionDao.BuscarMateriaPorNombre(cmbMateria.Text);
            cmbExamenes.DataSource = ConnectionDao.ObtenerListadoExamenesDeMateriaSeleccionada(materiaSeleccionada.Id);
            cmbAlumnosEvaluados.Text = "";
            cmbExamenes.Text = "";
        }



        private void cmbExamenes_TextChanged(object sender, EventArgs e)
        {
            //Se busca el examen seleccionado
            //Se buscan los alumnos asociados a la materia de ese examen.
            cmbAlumnosEvaluados.Text = "";
            Examen examenSeleccionado = ConnectionDao.BuscarExamenPorNombre(cmbExamenes.Text);
            lblExamenFecha.Text = $"Fecha: {examenSeleccionado.Fecha}";
            listadoAlumnosAEvaluar = ConnectionDao.ObtenerListadoDeNombresDeAlumnosQueCursanLaMateria(materiaSeleccionada.Id);
            cmbAlumnosEvaluados.DataSource = listadoAlumnosAEvaluar;

        }



        private void btnCalificar_Click(object sender, EventArgs e)
        {
            //Se busca el alumno seleccionado y se recibe la nota.
            //Se carga la nota de ese examen a la DB
            alumnoSeleccionado = ConnectionDao.BuscarAlumnoPorNombre(cmbAlumnosEvaluados.Text);
            float nota = (float)numNota.Value;
            ConnectionDao.CargarNotaAAlumno(alumnoSeleccionado.Id, materiaSeleccionada.Id, nota);
            


            //Se elimina el alumno del listado de alumnos a evaluar
            //Se muestra al usuario el ultimo alumno y nota asignada
            listadoAlumnosAEvaluar.Remove(alumnoSeleccionado.Nombre);
            cmbAlumnosEvaluados.DataSource = listadoAlumnosAEvaluar;
            cmbAlumnosEvaluados.Text = "";
            lblUltimoCalificado.Text = $"Alumno evaluado: {alumnoSeleccionado.Nombre}";
            lblUltimaNota.Text = $"Nota asignada: {nota}";
        }


        //==============================================================================================



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
