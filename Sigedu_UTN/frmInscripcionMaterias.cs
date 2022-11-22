using System;
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
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;

namespace Sigedu_UTN
{
    public partial class frmInscripcionMaterias : Form
    {
        Alumno alumnoLogueado;
        BindingList<string> materiasAprobadas;
        BindingList<string> materiasCursando;
        public frmInscripcionMaterias(Alumno alumno)
        {
            InitializeComponent();
            this.alumnoLogueado = alumno;
        }

        private void frmInscripcionMaterias_Load(object sender, EventArgs e)
        {
            RefrescarListados();
        }


        /// <summary>
        /// Muestra el listado de materias habilitadas para la inscripcion del alumno.
        /// Filtra las materias que ya está cursando y las que tiene aprobadas.
        /// Muestra solo las que cumplen con la condicion de tener las correlativas aprobadas.
        /// </summary>
        /// <param name="materiasAprobadas">Se eliminan del listado y se utilizan para determinar cuales puede inscribirse</param>
        /// <param name="listaMateriasCursando">Se eliminan del listado</param>
        /// <returns>Listado de materias habilitadas para inscribirse</returns>
        private BindingList<string> ListarMateriasHabilitadas(BindingList<string> materiasAprobadas, BindingList<string> listaMateriasCursando)
        {
            BindingList<string> materiasHabilitadas = new BindingList<string>();
            
            try
            {
                bool todasCorrelativasAprobadas = true;
                Materia materiaSeleccionada = new Materia();


                //Obtengo el listado completo de materias
                List<string> materias = new List<string>(ConnectionDao.ListarMateriasTotales());


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

                //Elimino las materias que ya está cursando o que ya tiene aprobadas
                foreach (string materiaAprobada in materiasAprobadas)
                {
                    materiasHabilitadas.Remove(materiaAprobada);
                }

                foreach (string materiaCursando in materiasCursando)
                {
                    materiasHabilitadas.Remove(materiaCursando);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return materiasHabilitadas;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string materiaSeleccionada = lstMateriasHabilitadas.Text;
                if (materiaSeleccionada != "")
                {
                    Materia nuevaMateriaCursando = ConnectionDao.BuscarMateriaPorNombre(materiaSeleccionada);
                    ConnectionDao.AsignarAlumnoAMateria(alumnoLogueado.Id, nuevaMateriaCursando.Id);

                    RefrescarListados();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Actualiza las listas de materias cursando, aprobadas y habilitadas.
        private void RefrescarListados()
        {
            try
            {
                materiasAprobadas = ConnectionDao.ObtenerListadoDeMateriasAprobadasDeAlumnoSeleccionado(alumnoLogueado.Id);
                materiasCursando = ConnectionDao.ObtenerListadoDeMateriasCursandoDeAlumnoSeleccionado(alumnoLogueado.Id);
                lstMateriasCursando.DataSource = materiasCursando;
                lstMateriasAprobadas.DataSource = materiasAprobadas;
                lstMateriasHabilitadas.DataSource = ListarMateriasHabilitadas(materiasAprobadas, materiasCursando);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmAlumno frmAlumno = new frmAlumno(alumnoLogueado.User);
            frmAlumno.Show();
            this.Hide();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
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
