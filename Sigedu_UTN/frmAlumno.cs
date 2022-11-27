using Biblioteca_de_clases;
using Microsoft.VisualBasic.ApplicationServices;
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

namespace Sigedu_UTN
{
    public partial class frmAlumno : Form
    {
        Alumno alumnoLogueado;
        List<Materia> materiasTotales;
        List<Materia> materiasHabilitadasParaInscripcion;
        List<Materia> materiasAprobadasDelAlumno;
        List<Materia> materiasCursandoDelAlumno;


        public frmAlumno(int id)
        {
            try
            {
                InitializeComponent();
                alumnoLogueado = ConnectionDao.BuscarAlumnoPorId(id);



                materiasAprobadasDelAlumno = ConnectionDao.ObtenerListadoDeMateriasAprobadasDelAlumno(id);
                materiasCursandoDelAlumno = ConnectionDao.ObtenerListadoDeMateriasCursandoDelAlumno(id);
                materiasTotales = ConnectionDao.ObtenerListadoDeMaterias();
                CargarDtgvMateriasAprobadas();
                CargarDtgvMateriasCursando();


                cmbMaterias.ValueMember = "id";
                cmbMaterias.DisplayMember = "nombre";
                cmbMaterias.DataSource = materiasCursandoDelAlumno;



                cmbMateriasInscripcion.ValueMember = "id";
                cmbMateriasInscripcion.DisplayMember = "nombre";
                cmbMateriasInscripcion.DataSource = FiltrarMateriasAprobadasYCursando();

                lblNombre.Text = $"¡Hola \n {alumnoLogueado.Nombre}!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnDarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                int idMateriaSeleccionada = int.Parse(cmbMaterias.SelectedValue.ToString());
                Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorId(idMateriaSeleccionada);
                if (alumnoLogueado.DarAsistenciaAMateria(idMateriaSeleccionada))
                {
                    MessageBox.Show($"Se cargo tu asistencia a {materiaSeleccionada.Nombre} el dia {DateTime.Today.ToShortDateString()}");
                }
                else
                {
                    MessageBox.Show($"Ya has dado asistencia hoy en la materia {materiaSeleccionada.Nombre}");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }




        
        private List<Materia> FiltrarMateriasAprobadasYCursando()
        {
            List<Materia> lista = this.materiasTotales;

            //Se filtran materias aprobadas
            foreach (Materia materiaAprobada in materiasAprobadasDelAlumno)
            {
                for(int i = 0; i<materiasTotales.Count(); i++)
                {
                    if (lista[i].Id == materiaAprobada.Id)
                    {
                        lista.Remove(lista[i]);
                    }
                }

            }

            //Se filtran materias cursando
            foreach (Materia materiaCursando in materiasCursandoDelAlumno)
            {
                for (int i = 0; i < materiasTotales.Count(); i++)
                {
                    if (lista[i].Id == materiaCursando.Id)
                    {
                        lista.Remove(lista[i]);
                    }
                }

            }



            return lista;
        }


        //------------------------------------------------------------------
        //Cargar listados de visualizacion de materias aprobadas y cursando:
        //------------------------------------------------------------------
        private void CargarDtgvMateriasAprobadas()
        {
            List<string[]> dataMaterias = ConnectionDao.ObtenerInformacionDeMateriasAprobadas(alumnoLogueado.Id);


            int index = 0;
            foreach(string[] data in dataMaterias)
            {
                dtgvAprobadas.Rows.Add();
                dtgvAprobadas.Rows[index].Cells[0].Value = data[0];
                dtgvAprobadas.Rows[index].Cells[1].Value = data[1];
                dtgvAprobadas.Rows[index].Cells[2].Value = data[2];
                dtgvAprobadas.Rows[index].Cells[3].Value = data[3];
                index++;
            }
        }

        private void CargarDtgvMateriasCursando()
        {
            List<string[]> dataMaterias = ConnectionDao.ObtenerInformacionDeMateriasCursando(alumnoLogueado.Id);


            int index = 0;
            foreach (string[] data in dataMaterias)
            {
                dtgvCursando.Rows.Add();
                dtgvCursando.Rows[index].Cells[0].Value = data[0];
                dtgvCursando.Rows[index].Cells[1].Value = data[1];
                dtgvCursando.Rows[index].Cells[2].Value = data[2];
                dtgvCursando.Rows[index].Cells[3].Value = data[3];
                index++;
            }
        }



        //================================== INSCRIBIRSE A MATERIA ===============================================

        private void btnInscripcionMateria_Click(object sender, EventArgs e)
        {
            int idMateria = int.Parse(cmbMateriasInscripcion.SelectedValue.ToString());
            Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorId(idMateria);
            int respuesta = alumnoLogueado.InscribirseAMateria(idMateria);

            switch (respuesta)
            {
                case 1:
                    MessageBox.Show($"¡Te has inscripto a {materiaSeleccionada.Nombre}!");
                    break;
                case -1:
                    MessageBox.Show($"No posees todas las materias correlativas aprobadas para anotarte a {materiaSeleccionada.Nombre}");
                    break;
                case -2:
                    MessageBox.Show("Ya estas inscripto en 2 materias.");
                    break;

            }

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
