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



        private BindingList<string> ListarMateriasHabilitadas(BindingList<string> materiasAprobadas, BindingList<string> listaMateriasCursando)
        {
            BindingList<string> materiasHabilitadas = new BindingList<string>();
            bool todasCorrelativasAprobadas = true;
            Materia materiaSeleccionada = new Materia();
            

            //Obtengo el listado completo de materias
            List<string> materias = new List<string>();
            materias.AddRange(Connection.CrearListadoDeMateriasPorCuatrimestre(1));
            materias.AddRange(Connection.CrearListadoDeMateriasPorCuatrimestre(2));
            materias.AddRange(Connection.CrearListadoDeMateriasPorCuatrimestre(3));
            materias.AddRange(Connection.CrearListadoDeMateriasPorCuatrimestre(4));




            foreach(string materia in materias)
            {
                materiaSeleccionada = Connection.BuscarMateriaPorNombre(materia);
                List<string> listaMateriasCorrelativas = new List<string>(Connection.BuscarMateriasCorrelativasDeMateria(materiaSeleccionada.Id));

                foreach(string materiaCorrelativa in listaMateriasCorrelativas)
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

            return materiasHabilitadas;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string materiaSeleccionada = lstMateriasHabilitadas.Text;
            if(materiaSeleccionada != "")
            {

                Materia nuevaMateriaCursando = Connection.BuscarMateriaPorNombre(materiaSeleccionada); 
                Connection.AsignarAlumnoAMateria(alumnoLogueado.Id, nuevaMateriaCursando.Id); 

                RefrescarListados();
            }


        }

        private void RefrescarListados()
        {
            materiasAprobadas = Connection.ObtenerListadoDeMateriasAprobadasDeAlumnoSeleccionado(alumnoLogueado.Id);
            materiasCursando = Connection.ObtenerListadoDeMateriasCursandoDeAlumnoSeleccionado(alumnoLogueado.Id);
            lstMateriasCursando.DataSource = materiasCursando;
            lstMateriasAprobadas.DataSource = materiasAprobadas;
            lstMateriasHabilitadas.DataSource = ListarMateriasHabilitadas(materiasAprobadas, materiasCursando);

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
