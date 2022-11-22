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

        BindingList<string> listadoAlumnosTotales;
        BindingList<string> materiasDeAlumnoSeleccionado;

       
        BindingList<string> listadoProfesoresTotales;
        BindingList<string> materiasDisponiblesParaProfesor;
        BindingList<string> materiasHabilitadasParaAlumno;

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;


        //El constructor inicializa los listados que recibe de la DB
        public frmAdmin()
        {
            
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            listadoAlumnosTotales = ConnectionDao.ObtenerNombresAlumnos();
            listadoProfesoresTotales = ConnectionDao.ObtenerNombresProfesores();
            cmbMateriaExport.DataSource = ConnectionDao.ListarMateriasTotales();
            
            
            materiasDeAlumnoSeleccionado = new BindingList<string>();
            materiasDisponiblesParaProfesor = new BindingList<string>();
            materiasHabilitadasParaAlumno = new BindingList<string>();

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

            cmbSeleccionarAlumno.DataSource = listadoAlumnosTotales;
            cmbSeleccionarProfesor.DataSource = listadoProfesoresTotales;

            cmbSeleccionarAlumnoAsignarMateria.DataSource = listadoAlumnosTotales;
            cmbSeleccionarMateriaAlumno.DataSource = materiasHabilitadasParaAlumno;

        }





        //===================================== CREAR NUEVO USUARIO ==================================================
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string userNuevoUsuario = txtNewUser.Text;
            string passNuevoUsuario = txtNewUserPass.Text;
            string nombreNuevoUsuario = txtNewUserName.Text;
            string telefonoNuevoUsuario = txtNewUserTel.Text;
            string emailNuevoUsuario = txtNewUserMail.Text;
            int tipoUsuario = codificarTipoUsuario();

            ConnectionDao.CrearNuevoUsuario(tipoUsuario, userNuevoUsuario, passNuevoUsuario, nombreNuevoUsuario, telefonoNuevoUsuario, emailNuevoUsuario);
            
            MessageBox.Show("Usuario creado exitosamente");
            txtNewUser.Text = "";
            txtNewUserPass.Text = "";
            txtNewUserName.Text = "";
            txtNewUserTel.Text = "";
            txtNewUserMail.Text = "";
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
            //Recibimos los inputs del usuario
            string nombreAlumnoSeleccionado = cmbSeleccionarAlumno.Text;
            string nombreMateriaSeleccionada = cmbMateriasAlumnoSeleccionado.Text;


            //Buscamos al alumno y la materia seleccionada. Luego obtengo el ID de su relacion y su estado
            Alumno alumnoSeleccionado = ConnectionDao.BuscarAlumnoPorNombre(nombreAlumnoSeleccionado);
            Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorNombre(nombreMateriaSeleccionada);
            int idRelacion = ConnectionDao.SeleccionarIDMateriasAlumnosCursando(alumnoSeleccionado.Id, materiaSeleccionada.Id);
            int estadoMateria = ConnectionDao.ObtenerEstadoMateria(idRelacion);


            //Alternamos el estado de esa materia
            if (estadoMateria == 1)
            {
                ConnectionDao.CambiarEstadoMateria(idRelacion, 0);
                picEstadoMateria.BackColor = Color.IndianRed;
                lblEstadoMateria.Text = "Libre";
                lblEstadoMateria.BackColor = Color.IndianRed;
            }
            else if (estadoMateria == 0)
            {
                ConnectionDao.CambiarEstadoMateria(idRelacion, 1);
                picEstadoMateria.BackColor = Color.YellowGreen;
                lblEstadoMateria.Text = "Regular";
                lblEstadoMateria.BackColor = Color.YellowGreen;
            }

        }

        private void cmbMateriasAlumnoSeleccionado_TextChanged(object sender, EventArgs e)
        {
            //Recibimos los inputs del usuario
            string nombreAlumnoSeleccionado = cmbSeleccionarAlumno.Text;
            string nombreMateriaSeleccionada = cmbMateriasAlumnoSeleccionado.Text;

            //Buscamos al alumno seleccionado
            Alumno alumnoSeleccionado = ConnectionDao.BuscarAlumnoPorNombre(nombreAlumnoSeleccionado);
            Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorNombre(nombreMateriaSeleccionada);
            int idRelacion = ConnectionDao.SeleccionarIDMateriasAlumnosCursando(alumnoSeleccionado.Id, materiaSeleccionada.Id);
            int estadoMateria = ConnectionDao.ObtenerEstadoMateria(idRelacion);



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

        private void cmbSeleccionarAlumno_TextChanged(object sender, EventArgs e)
        {
            Alumno alumnoSeleccionado = ConnectionDao.BuscarAlumnoPorNombre(cmbSeleccionarAlumno.Text);

            materiasDeAlumnoSeleccionado = ConnectionDao.ObtenerListadoDeMateriasCursandoDeAlumnoSeleccionado(alumnoSeleccionado.Id);
            cmbMateriasAlumnoSeleccionado.DataSource = materiasDeAlumnoSeleccionado;
        }






        //===================================== CREAR NUEVA MATERIA ==================================================
        private void btnCrearMateria_Click(object sender, EventArgs e)
        {
            //Recibimos los datos cargados y lo cargamos a la DB
            string nombreNuevaMateria = txtNuevaMateria.Text;
            int cuatrimestre = TomarCuatrimestreDeNuevaMateria();
            List<string> materiasCorrelativasSeleccionadas = recibirMateriasCorrelativasIngresadas();
            ConnectionDao.CrearNuevaMateria(nombreNuevaMateria, cuatrimestre);

            //Buscamos la materia recien creada para obtener su ID
            //Le cargamos las materias correlativas seleccionadas
            Materia nuevaMateria = ConnectionDao.BuscarMateriaPorNombre(nombreNuevaMateria);
            ConnectionDao.CargarMateriasCorrelativas(nuevaMateria.Id, materiasCorrelativasSeleccionadas);


            MessageBox.Show($"Se ha cargado exitosamente la siguiente materia: \n\n Nombre: {nombreNuevaMateria}" +
                $"\n Cuatrimestre: {cuatrimestre}");
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


        private List<string> recibirMateriasCorrelativasIngresadas()
        {
            List<string> materiasCorrelativas = new List<string>();
            var variable = listSeleccionarMateriasCorrelativas.SelectedItems;

            foreach (string materia in variable)
            {
                materiasCorrelativas.Add(materia);
            }

            return materiasCorrelativas;
        }

        private void cmbCuatriSeleccionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<string> seleccionMateriasCorrelativas = ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(int.Parse(cmbCuatriSeleccionado.Text));

            listSeleccionarMateriasCorrelativas.DataSource = seleccionMateriasCorrelativas;
        }




        
        
        //===================================== ASIGNAR PROFESOR A MATERIA ==================================================

        private void btnAsignarMateria_Click(object sender, EventArgs e)
        {
            //Buscamos el profesor y la materia que fueron seleccionados
            Profesor profesorSeleccionado = ConnectionDao.BuscarProfesorPorNombre(cmbSeleccionarProfesor.Text);
            Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorNombre(cmbSeleccionarMateriaProfesor.Text);
            
            //Asigno la materia en la DB
            ConnectionDao.AsignarProfesorAMateria(profesorSeleccionado.Id, materiaSeleccionada.Id);
            MessageBox.Show($"El profesor {profesorSeleccionado.Nombre} ha sido asignado a la materia {materiaSeleccionada.Nombre}");

            cmbSeleccionarProfesor.Text = "";
            cmbSeleccionarMateriaProfesor.Text = "";
        }

        private BindingList<string> ListarMateriasDisponiblesParaProfesor()
        {
            Profesor profesorSeleccionado = ConnectionDao.BuscarProfesorPorNombre(cmbSeleccionarProfesor.Text);

            //Obtengo el listado completo de materias
            List<string> materias = new List<string>();
            materias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(1));
            materias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(2));
            materias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(3));
            materias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(4));
            
            //Descarto las materias que actualmente esta dictando
            BindingList<string> materiasActualesDelProfesor = ConnectionDao.ObtenerListadoDeMateriasDictandoDeProfesorSeleccionado(profesorSeleccionado.Id);
            foreach(string materia in materiasActualesDelProfesor)
            {
                materias.Remove(materia);
            }


            //Con el listado filtrado creo una BindingList y la retorno
            BindingList<string> listadoMateriasDisponibles = new BindingList<string>(materias);

            return listadoMateriasDisponibles;
        }


        private void cmbSeleccionarProfesor_TextChanged(object sender, EventArgs e)
        {
            
            materiasDisponiblesParaProfesor = ListarMateriasDisponiblesParaProfesor();
            cmbSeleccionarMateriaProfesor.DataSource = materiasDisponiblesParaProfesor;
            
        }



        //===================================== INSCRIBIR ALUMNO A MATERIA ==================================================


        private void cmbSeleccionarAlumnoAsignarMateria_TextChanged(object sender, EventArgs e)
        {

            Alumno alumnoSeleccionado = ConnectionDao.BuscarAlumnoPorNombre(cmbSeleccionarAlumnoAsignarMateria.Text);
            Materia materiaSeleccionada;
            BindingList<string> materiasAprobadas = ConnectionDao.ObtenerListadoDeMateriasAprobadasDeAlumnoSeleccionado(alumnoSeleccionado.Id);
            BindingList<string> materiasCursando = ConnectionDao.ObtenerListadoDeMateriasCursandoDeAlumnoSeleccionado(alumnoSeleccionado.Id);
            bool todasCorrelativasAprobadas = true;

            //Obtengo el listado completo de materias
            List<string> materias = new List<string>();
            materias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(1));
            materias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(2));
            materias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(3));
            materias.AddRange(ConnectionDao.ObtenerListadoDeMateriasPorCuatrimestre(4));
            List<string> materiasHabilitadas = new List<string>();


            foreach (string materia in materias)
            {
                materiaSeleccionada = ConnectionDao.BuscarMateriaPorNombre(materia);
                List<string> listaMateriasCorrelativas = new List<string>(ConnectionDao.BuscarMateriasCorrelativasDeMateria(materiaSeleccionada.Id));

                foreach (string materiaCorrelativa in listaMateriasCorrelativas)
                {
                    if (!materiasAprobadas.Contains(materiaCorrelativa))
                    {
                        todasCorrelativasAprobadas = false;
                        break;
                    }
                }
                if (todasCorrelativasAprobadas == true)
                {
                    materiasHabilitadas.Add(materia);
                }


            }


            //Filtro las que ya tiene aprobadas o está cursando actualmente
            foreach (string materia in materiasAprobadas)
            {
                materiasHabilitadas.Remove(materia);
            }
            foreach (string materia in materiasCursando)
            {
                materiasHabilitadas.Remove(materia);
            }

            materiasHabilitadasParaAlumno = new BindingList<string>(materiasHabilitadas);
            cmbSeleccionarMateriaAlumno.DataSource = materiasHabilitadasParaAlumno;
        }



        private void btnAsignarMAteriaAlumno_Click(object sender, EventArgs e)
        {

            //Buscamos el alumno y la materia que fueron seleccionados
            Alumno alumnoSeleccionado = ConnectionDao.BuscarAlumnoPorNombre(cmbSeleccionarAlumno.Text);
            Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorNombre(cmbSeleccionarMateriaAlumno.Text);

            //Asigno la materia en la DB
            ConnectionDao.AsignarAlumnoAMateria(alumnoSeleccionado.Id, materiaSeleccionada.Id);
            MessageBox.Show($"El alumno {alumnoSeleccionado.Nombre} ha sido asignado a la materia {materiaSeleccionada.Nombre}");

            cmbSeleccionarAlumnoAsignarMateria.Text = "";
            cmbSeleccionarMateriaAlumno.Text = "";
        }




        private void btnExportarDatos_Click(object sender, EventArgs e)
        {
            Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorNombre(cmbMateriaExport.Text);
            List<Alumno> listadoAlumnos = ConnectionDao.ObtenerListadoDeAlumnosQueCursanLaMateria(materiaSeleccionada.Id);
            int formatoSeleccionado = SeleccionarFormatoExport();
            if(formatoSeleccionado == 1) //-----> Se exporta un archivo CSV
            {
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Archivo<Alumno> file = new Archivo<Alumno>(saveFileDialog.FileName + ".txt");
                    file.GuardarArchivoCSV(listadoAlumnos);
                }

            }
            else if(formatoSeleccionado == 2) //-----> Se exporta un archivo JSON
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Archivo<Alumno> file = new Archivo<Alumno>(saveFileDialog.FileName + ".json");
                    file.GuardarArchivoJSON(listadoAlumnos);
                }
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

        private void radNewAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (radNewAdmin.Checked == true)
            {
                txtNewUserName.Text = "";
                txtNewUserTel.Text = "";
                txtNewUserMail.Text = "";
                txtNewUserName.ReadOnly = true;
                txtNewUserTel.ReadOnly = true;
                txtNewUserMail.ReadOnly = true;

            }
            else
            {
                txtNewUserName.ReadOnly = false;
                txtNewUserTel.ReadOnly = false;
                txtNewUserMail.ReadOnly = false;
            }
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



    }
}
