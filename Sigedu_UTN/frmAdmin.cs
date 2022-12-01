using Biblioteca_de_clases;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Sigedu_UTN
{
    public partial class frmAdmin : Form
    {

        Admin adminLogueado;

        List<Alumno> listadoAlumnosTotales;
        List<Profesor> listadoProfesoresTotales;
        List<Materia> listadoMateriasTotales;


        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;



        public frmAdmin()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            try
            {
                adminLogueado = new Admin();
                listadoAlumnosTotales = ConnectionDao.ObtenerListadoDeAlumnos();
                listadoProfesoresTotales = ConnectionDao.ObtenerListadoDeProfesores();
                listadoMateriasTotales = ConnectionDao.ObtenerListadoDeMaterias();

                //List: Crear nueva Materia
                listSeleccionarMateriasCorrelativas.ValueMember = "id";
                listSeleccionarMateriasCorrelativas.DisplayMember = "nombre";

                //Comboboxes: Asignar profesor a materia
                cmbSeleccionarProfesor.ValueMember = "id";
                cmbSeleccionarProfesor.DisplayMember = "nombre";
                cmbSeleccionarProfesor.DataSource = listadoProfesoresTotales;

                //Comboboxes: Asignar alumno a materia
                cmbSeleccionarAlumnoAsignarMateria.ValueMember = "id";
                cmbSeleccionarAlumnoAsignarMateria.DisplayMember = "nombre";
                cmbSeleccionarAlumnoAsignarMateria.DataSource = listadoAlumnosTotales;

                RefrescarListadoMaterias();

                //Comboboxes: Exportar datos
                cmbMateriaExport.ValueMember = "id";
                cmbMateriaExport.DisplayMember = "nombre";
                cmbMateriaExport.DataSource = listadoMateriasTotales;

                //Comboboxes: Cambiar estado de materia
                //cmbSeleccionarAlumno.DataSource = listadoAlumnosTotales;
                cmbSeleccionarAlumno.ValueMember = "id";
                cmbSeleccionarAlumno.DisplayMember = "nombre";
                cmbSeleccionarAlumno.DataSource = listadoAlumnosTotales;
                cmbMateriasAlumnoSeleccionado.ValueMember = "id";
                cmbMateriasAlumnoSeleccionado.DisplayMember = "nombre";
                cmbMateriasAlumnoSeleccionado.DataSource = listadoMateriasTotales;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        //===================================== CREAR NUEVO USUARIO ==================================================
        private void btnCreateUser_Click(object sender, EventArgs e)
        {  
            try
            {
                int tipoUsuario = codificarTipoUsuario();
                string nombreNuevoUsuario = txtNewUserName.Text;
                string emailNuevoUsuario = txtNewUserMail.Text;
                string passNuevoUsuario = txtNewUserPass.Text;
                adminLogueado.CrearNuevoUsuario(tipoUsuario, nombreNuevoUsuario, emailNuevoUsuario, passNuevoUsuario);

                txtNewUserName.Text = "";
                txtNewUserMail.Text = "";
                txtNewUserPass.Text = "";
                MessageBox.Show("Usuario creado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private int codificarTipoUsuario()
        {
            int respuesta = -1;

            if (radNewAdmin.Checked == true)
            {
                respuesta = 0;
            }
            else if (radNewProfesor.Checked == true)
            {
                respuesta = 1;
            }
            else if (radNewAlumno.Checked == true)
            {
                respuesta = 2;
            }

            return respuesta;
        }






        //===================================== CAMBIAR ESTADO MATERIA ==================================================
       
        //Cambia el Estado de la materia (1:Regular/0:Libre) del alumno seleccionado.
        private void btnCambiarEstadoMateria_Click(object sender, EventArgs e)
        {
            try
            {
                int idAlumnoSeleccionado = int.Parse(cmbSeleccionarAlumno.SelectedValue.ToString());
                int idMateriaSeleccionada = int.Parse(cmbMateriasAlumnoSeleccionado.SelectedValue.ToString());
                int nuevoEstado = adminLogueado.CambiarEstadoMateria(idAlumnoSeleccionado, idMateriaSeleccionada);


                //Modificamos la interfaz del usuario en funcion del nuevo estado de la materia
                SetCartelEstadoMateria(nuevoEstado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cmbMateriasAlumnoSeleccionado_TextChanged(object sender, EventArgs e)
        {
            //Recibimos los inputs del usuario
            int idAlumnoSeleccionado = int.Parse(cmbSeleccionarAlumno.SelectedValue.ToString());

            int idMateriaSeleccionada = int.Parse(cmbMateriasAlumnoSeleccionado.SelectedValue.ToString());
            int estadoMateria = ConnectionDao.ObtenerEstadoMateria(idAlumnoSeleccionado, idMateriaSeleccionada);

            SetCartelEstadoMateria(estadoMateria);
        }

        private void SetCartelEstadoMateria(int estadoMateria)
        {
            if (estadoMateria == 1)
            {
                picEstadoMateria.BackColor = Color.YellowGreen;
                lblEstadoMateria.Text = "Regular";
                lblEstadoMateria.BackColor = Color.YellowGreen;
            }
            else if (estadoMateria == 0)
            {
                picEstadoMateria.BackColor = Color.IndianRed;
                lblEstadoMateria.Text = "Libre";
                lblEstadoMateria.BackColor = Color.IndianRed;
            }
        }

        //===================================== CREAR NUEVA MATERIA ==================================================
        private void btnCrearMateria_Click(object sender, EventArgs e)
        {
            try
            {
                //Recibimos los datos cargados y lo cargamos a la DB
                string nombreNuevaMateria = txtNuevaMateria.Text;
                int cuatrimestre = TomarCuatrimestreDeNuevaMateria();
                List<int> materiasCorrelativasSeleccionadas = recibirIdsMateriasCorrelativasIngresadas();

                if(adminLogueado.CrearNuevaMateria(nombreNuevaMateria, cuatrimestre, materiasCorrelativasSeleccionadas))
                {
                    MessageBox.Show($"Se ha cargado exitosamente la siguiente materia: \n\n Nombre: {nombreNuevaMateria}" +
                    $"\n Cuatrimestre: {cuatrimestre}");
                    RefrescarListadoMaterias();
                }
                else
                {
                    MessageBox.Show("Ha habido un error en la creacion de la nueva materia");
                }



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private int TomarCuatrimestreDeNuevaMateria()
        {
            int respuesta = -1;
            if (radCuatri1.Checked == true)
            {
                respuesta = 1;
            }
            else if (radCuatri2.Checked == true)
            {
                respuesta = 2;
            }
            else if (radCuatri3.Checked == true)
            {
                respuesta = 3;
            }
            else if (radCuatri4.Checked == true)
            {
                respuesta = 4;
            }
            return respuesta;
        }


        private List<int> recibirIdsMateriasCorrelativasIngresadas()
        {
            List<int> materiasCorrelativas = new List<int>();
            int cantidadItemsSeleccionados = listSeleccionarMateriasCorrelativas.SelectedItems.Count;
            int idMateriaSeleccionada;


            foreach (Materia item in listSeleccionarMateriasCorrelativas.SelectedItems)
            {
                materiasCorrelativas.Add(item.Id);
            }

            return materiasCorrelativas;
        }

        private void radCuatri1_CheckedChanged(object sender, EventArgs e)
        {
            List<Materia> materiasDelCuatriSeleccionado = new List<Materia>();
            listSeleccionarMateriasCorrelativas.ValueMember = "id";
            listSeleccionarMateriasCorrelativas.DisplayMember = "nombre";
            listSeleccionarMateriasCorrelativas.DataSource = materiasDelCuatriSeleccionado;
        }
        private void radCuatri2_CheckedChanged(object sender, EventArgs e)
        {
            List<Materia> materiasDelCuatriSeleccionado = new List<Materia>();
            materiasDelCuatriSeleccionado.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(1));
            listSeleccionarMateriasCorrelativas.ValueMember = "id";
            listSeleccionarMateriasCorrelativas.DisplayMember = "nombre";
            listSeleccionarMateriasCorrelativas.DataSource = materiasDelCuatriSeleccionado;

        }
        private void radCuatri3_CheckedChanged(object sender, EventArgs e)
        {
            List<Materia> materiasDelCuatriSeleccionado = new List<Materia>();
            materiasDelCuatriSeleccionado.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(1));
            materiasDelCuatriSeleccionado.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(2));
            listSeleccionarMateriasCorrelativas.ValueMember = "id";
            listSeleccionarMateriasCorrelativas.DisplayMember = "nombre";
            listSeleccionarMateriasCorrelativas.DataSource = materiasDelCuatriSeleccionado;
        }

        private void radCuatri4_CheckedChanged(object sender, EventArgs e)
        {
            List<Materia> materiasDelCuatriSeleccionado = new List<Materia>();
            materiasDelCuatriSeleccionado.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(1));
            materiasDelCuatriSeleccionado.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(2));
            materiasDelCuatriSeleccionado.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(3));
            listSeleccionarMateriasCorrelativas.ValueMember = "id";
            listSeleccionarMateriasCorrelativas.DisplayMember = "nombre";
            listSeleccionarMateriasCorrelativas.DataSource = materiasDelCuatriSeleccionado;
        }

        private void RefrescarListadoMaterias()
        {
            listadoMateriasTotales = ConnectionDao.ObtenerListadoDeMaterias();
            cmbSeleccionarMateriaProfesor.DisplayMember = "nombre";
            cmbSeleccionarMateriaProfesor.ValueMember = "id";
            cmbSeleccionarMateriaProfesor.DataSource = listadoMateriasTotales;

            cmbSeleccionarMateriaAlumno.DisplayMember = "nombre";
            cmbSeleccionarMateriaAlumno.ValueMember = "id";
            cmbSeleccionarMateriaAlumno.DataSource = listadoMateriasTotales;
        }


        //========================================= ASIGNAR MATERIA ======================================================

        //Asignar materia a Profesor
        private void btnAsignarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                int idProfesorSeleccionado = int.Parse(cmbSeleccionarProfesor.SelectedValue.ToString());
                int idMateriaSeleccionada = int.Parse(cmbSeleccionarMateriaProfesor.SelectedValue.ToString());

                if (adminLogueado.AsignarProfesorAMateria(idProfesorSeleccionado, idMateriaSeleccionada))
                {
                    MessageBox.Show("El profesor ha sido asignado a la materia correctamente");
                }
                else
                {
                    MessageBox.Show("El profesor ya tiene asignada la materia seleccionada");
                }
                
                cmbSeleccionarProfesor.Text = "";
                cmbSeleccionarMateriaProfesor.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //Asignar materia a Alumno
        private void btnAsignarMAteriaAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                int idAlumnoSeleccionado = int.Parse(cmbSeleccionarAlumnoAsignarMateria.SelectedValue.ToString());
                int idMateriaSeleccionada = int.Parse(cmbSeleccionarMateriaAlumno.SelectedValue.ToString());
                int respuesta = adminLogueado.AsignarAlumnoAMateria(idAlumnoSeleccionado, idMateriaSeleccionada);
                switch (respuesta)
                {
                    case -3:
                        MessageBox.Show("El alumno no posee todas las materias correlativas aprobadas.");
                        break;
                    case -2:
                        MessageBox.Show("El alumno ya tiene aprobada la materia.");
                        break;
                    case -1:
                        MessageBox.Show("El alumno se encuentra cursando la materia.");
                        break;
                    case 1:
                        MessageBox.Show("El alumno ha sido asignado a la materia satisfactoriamente.");
                        break;

                }

                cmbSeleccionarAlumnoAsignarMateria.Text = "";
                cmbSeleccionarMateriaAlumno.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        //============================================= EXPORT DATOS ========================================================

        private void btnExportarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                int idMateriaSeleccionada = int.Parse(cmbSeleccionarMateriaAlumno.SelectedValue.ToString());
                int formatoSeleccionado = SeleccionarFormatoExport();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(adminLogueado.ExportarDatos(formatoSeleccionado, saveFileDialog.FileName, idMateriaSeleccionada))
                    {
                        MessageBox.Show("Datos exportados correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Ha habido un error en la exportacion de datos.");
                    }
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private int SeleccionarFormatoExport()
        {
            int respuesta = -1;
            if (radCsv.Checked == true)
            {
                respuesta = 1;
            }
            else if (radJson.Checked == true)
            {
                respuesta = 2;
            }
            return respuesta;
        }






        //========================================================================================================
        //=============================================== SALIR ==================================================

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
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


        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
