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


        BindingList<string> listadoAlumnosAEvaluar;


        Materia materiaSeleccionada = new Materia();
        Alumno alumnoSeleccionado = new Alumno();



        //--------------------------------------------------------------------------


        public frmProfesor(int id)
        {
            InitializeComponent();
            
            try
            {
                //Busco el profesor logueado y cargo su listado de materias.
                profesorLogueado = ConnectionDao.BuscarProfesorPorId(id);
                profesorLogueado.MateriasDictando = ConnectionDao.ObtenerListadoDeMateriasDictandoDeProfesorSeleccionado(id);


                //listMaterias ---> (Funcionalidad de crear examen)
                //cmbMaterias ----> (Funcionalidad de corregir examen)
                listMaterias.ValueMember = "id";
                listMaterias.DisplayMember = "nombre";
                listMaterias.DataSource = profesorLogueado.MateriasDictando;
                cmbMateria.ValueMember = "id";
                cmbMateria.DisplayMember = "nombre";
                cmbMateria.DataSource = profesorLogueado.MateriasDictando;

                //Comboboxes -----> Seleciion de examenes y alumnos
                cmbExamenes.ValueMember = "id";
                cmbExamenes.DisplayMember = "nombre";
                cmbAlumnosEvaluados.ValueMember = "id";
                cmbAlumnosEvaluados.DisplayMember = "nombre";



                //Se cargan los datos del profesor logueado
                lblNombre.Text = $"¡Hola {profesorLogueado.Nombre}!";
                txtMail.Text = profesorLogueado.Email;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        //------------------------------------ Crear examen -------------------------------------

        private void btnCrearExamen_Click(object sender, EventArgs e)
        {
            try
            {

                int idMateria = int.Parse(listMaterias.SelectedValue.ToString());
                string nombreExamen = txtNombreExamen.Text;
                DateTime fechaSeleccionada = dttFecha.Value.Date;

                int respuesta = profesorLogueado.CrearExamen(idMateria, nombreExamen, fechaSeleccionada);
                switch (respuesta)
                {
                    case 1:
                        MessageBox.Show("Se ha creado el examen exitosamente");
                        break;
                    case -1:
                        MessageBox.Show("La materia seleccionada ya posee dos examenes");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        //------------------------------------ Corregir examen -------------------------------------


        private void cmbMateria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Se busca la materia seleccionada.
                //Se buscan los examenes asociados a la materia.
                Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorId(int.Parse(cmbMateria.SelectedValue.ToString()));
                cmbExamenes.DataSource = ConnectionDao.ObtenerListadoExamenesDeMateriaSeleccionada(materiaSeleccionada.Id);
                cmbAlumnosEvaluados.DataSource = ConnectionDao.ObtenerListadoDeAlumnosQueCursanLaMateria((materiaSeleccionada.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se busca el alumno seleccionado y se recibe la nota.
                //Se carga la nota de ese examen a la DB
                int idAlumnoSeleccionado = int.Parse(cmbAlumnosEvaluados.SelectedValue.ToString());
                int idMateriaSeleccionada = int.Parse(cmbMateria.SelectedValue.ToString());
                float nota = (float)numNota.Value;


                ConnectionDao.CargarNotaAAlumno(alumnoSeleccionado.Id, materiaSeleccionada.Id, nota);



                //Se elimina el alumno del listado de alumnos a evaluar
                //Se muestra al usuario el ultimo alumno y nota asignada
                listadoAlumnosAEvaluar.Remove(alumnoSeleccionado.Nombre);
                cmbAlumnosEvaluados.DataSource = listadoAlumnosAEvaluar;
                lblUltimoCalificado.Text = $"Alumno evaluado: {alumnoSeleccionado.Nombre}";
                lblUltimaNota.Text = $"Nota asignada: {nota}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
