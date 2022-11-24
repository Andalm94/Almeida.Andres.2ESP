using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{

    public class Alumno : usuarioUTN
    {

        List<Materia> materiasAprobadas;
        List<Materia> materiasCursando;
        List<Materia> materiasHabilitadasParaInscripcion;


        //======================================================= CONSTRUCTORES =================================================================

        public Alumno(int id, int tipoUsuario, string nombre, string email, string password) : base(id, tipoUsuario, nombre, email, password)
        {

        }

        public Alumno(int tipoUsuario, string nombre, string email, string password) : base(-1, tipoUsuario, nombre, email, password)
        {

        }

        public Alumno() : base(-1, "", "", "")
        {

        }

        //======================================================= PROPIEDADES =================================================================

        public List<Materia> MateriasAprobadas
        {
            get { return materiasAprobadas; }
            set { materiasAprobadas = value; }
        }
        public List<Materia> MateriasCursando
        {
            get { return materiasCursando; }
            set { materiasCursando = value; }
        }
        public List<Materia> MateriasHabilitadasParaInscripcion
        {
            get { return materiasHabilitadasParaInscripcion; }
            set { materiasHabilitadasParaInscripcion = value; }
        }


        //======================================================= METODOS =================================================================
    
        public bool DarAsistenciaAMateria(int idMateriaSeleccionada)
        {
            bool success = true;
            int idAlumno = this.Id;
            DateTime diaActual = DateTime.Today;

            if(ConnectionDao.ValidarNoHayAsistenciasAMateriaEnFechaSeleccionada(idAlumno, idMateriaSeleccionada, diaActual))
            {
                ConnectionDao.CargarAsistenciaAlumno(idAlumno, idMateriaSeleccionada);
            }
            else
            {
                success = false;
            }
            

            return success;
        }
    
        //CONTINUAR ACA: validar que la materia tenga todas sus correlativas aprobadas e inscribirse.
        public int InscribirseAMateria(int idMateriaSeleccionada)
        {
            int idAlumno = this.Id;
            List<int> idsMateriasCorrelativas = ConnectionDao.ObtenerListadoIdsMateriasCorrelativasDeMateria(idMateriaSeleccionada);
            List<int> idsMateriasAprobadas = ConnectionDao.ObtenerListadoIdsMateriasAprobadasDelAlumno(idAlumno);
            int cantidadDeMateriasCursando = ConnectionDao.ObtenerCantidadDeMateriasQueCursaAlumno(idAlumno);

            //Se valida que posea menos de dos materias
            if(cantidadDeMateriasCursando >= 2)
            {
                return -2;
            }


            //La funcion se corta al encontrar que el alumno no posee al menos una de las materias correlativas aprobadas
            foreach (int idMateriaMateriaCorrelativa in idsMateriasCorrelativas)
            {
                if (!idsMateriasAprobadas.Contains(idMateriaMateriaCorrelativa))
                {
                    return -1;
                }
            }



            //Pasada la validacion anterior, la funcion asigna el alumno a la materia y devuelve true
            ConnectionDao.AsignarAlumnoAMateria(idAlumno, idMateriaSeleccionada);
            return 1;
        }
    }
}
