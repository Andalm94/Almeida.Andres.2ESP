using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
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


        List<Alumno> alumnosQueCursanMateria;
        List<Examen> examenesMateriaSeleccionada;

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
                //CargarListBoxMateriasDeProfesor();
                listMaterias.ValueMember = "id";
                listMaterias.DisplayMember = "nombre";
                listMaterias.DataSource = profesorLogueado.MateriasDictando;
                //*----------------------------------------------------------


                cmbMateria.ValueMember = "id";
                cmbMateria.DisplayMember = "nombre";
                cmbMateria.DataSource = profesorLogueado.MateriasDictando;

                //Comboboxes -----> Seleciion de examenes y alumnos
                cmbExamenes.ValueMember = "id";
                cmbExamenes.DisplayMember = "nombre";
                cmbExamenes.DataSource = examenesMateriaSeleccionada;






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

                listMaterias.ValueMember = "id";
                listMaterias.DisplayMember = "nombre";
                listMaterias.DataSource = profesorLogueado.MateriasDictando;

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
                RefrescarListados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void CargarListBoxMateriasDeProfesor()
        {
            foreach(Materia mat in profesorLogueado.MateriasDictando)
            {
                listMaterias.Items.Add(new KeyValuePair<string, int>(mat.Nombre, mat.Id));
                listMaterias.DisplayMember = mat.Nombre;
                listMaterias.ValueMember = mat.Id.ToString();
            }
            

        }


        //------------------------------------ Corregir examen -------------------------------------


        private void cmbMateria_TextChanged(object sender, EventArgs e)
        {
            try
            {

                RefrescarListados();
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

                int idMateriaSeleccionada = int.Parse(cmbMateria.SelectedValue.ToString());
                int idExamenSeleccionado = int.Parse(cmbExamenes.SelectedValue.ToString());
                List<float> notasAsignadas = TomarNotasAsignadas(alumnosQueCursanMateria.Count);
                List<int> idAlumnosEvaluados = TomarIdsAlumnosEvaluados(alumnosQueCursanMateria.Count);

                int respuesta = profesorLogueado.AsignarNotasAAlumnos(idMateriaSeleccionada, idExamenSeleccionado, idAlumnosEvaluados, notasAsignadas);

                switch (respuesta)
                {
                    case 0:
                        MessageBox.Show("Has cargado las notas exitosamente");
                        break;
                    case -1:
                        MessageBox.Show("Has habido un error en la carga");
                        break;
                    case -2:
                        MessageBox.Show("Ese examen ya esta corregido");
                        break;
                    case -3:
                        MessageBox.Show("Hay al menos una nota fuera de rango");
                        break;
                }
                
                RefrescarListados();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No se ha realizado la carga. Faltan completar campos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        

        private void CargardtgvAlumnosID(List<Alumno> alumnos)
        {
            int index = 0;
            foreach (Alumno alumno in alumnos)
            {
                dtgvAlumnosEvaluados.Rows.Add();
                dtgvAlumnosEvaluados.Rows[index].Cells[0].Value = alumno.Id;
                index++;
            }

        }

        private void CargardtgvAlumnosEvaluados(List<Alumno> alumnos)
        {
            int index = 0;
            foreach (Alumno alumno in alumnos)
            {
                dtgvAlumnosEvaluados.Rows.Add();
                dtgvAlumnosEvaluados.Rows[index].Cells[1].Value = alumno.Nombre;
                index++;
            }

        }

        private List<float> TomarNotasAsignadas(int lenght)
        {
            List<float> list = new List<float>();
            try
            {
                float nota;

                for (int i = 0; i < lenght; i++)
                {
                    nota = float.Parse(dtgvAlumnosEvaluados.Rows[i].Cells[2].Value.ToString());
                    list.Add(nota);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Faltan completar campos");
            }


            return list;
        }

        private List<int> TomarIdsAlumnosEvaluados(int lenght)
        {
            List<int> list = new List<int>();
            int idAlumno;

            for (int i = 0; i < lenght; i++)
            {
                idAlumno = int.Parse(dtgvAlumnosEvaluados.Rows[i].Cells[0].Value.ToString());
                list.Add(idAlumno);
            }

            return list;
        }

        
        private void RefrescarListados()
        {
            //Se limpia el datagrid
            //Se busca la materia seleccionada.
            //Se buscan los examenes asociados a la materia (se valida que hayan al menos 1)
            //Se buscan los alumnos que cursan la materia
            dtgvAlumnosEvaluados.Rows.Clear();
            Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorId(int.Parse(cmbMateria.SelectedValue.ToString()));




            examenesMateriaSeleccionada = ConnectionDao.ObtenerListadoExamenesDeMateriaSeleccionada(materiaSeleccionada.Id, 0);
            if (examenesMateriaSeleccionada.Count > 0)
            {
                cmbExamenes.DisplayMember = "nombre";
                cmbExamenes.ValueMember = "id";
                cmbExamenes.DataSource = examenesMateriaSeleccionada;
            }
            else
            {
                cmbExamenes.DataSource = null;
            }
            alumnosQueCursanMateria = ConnectionDao.ObtenerListadoDeAlumnosQueCursanLaMateria(materiaSeleccionada.Id);
            CargardtgvAlumnosEvaluados(alumnosQueCursanMateria);
            CargardtgvAlumnosID(alumnosQueCursanMateria);
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
