using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Biblioteca_de_clases
{
    public class Admin : usuarioUTN
    {

        //======================================================= CONSTRUCTORES =================================================================

        public Admin(int id, int tipoUsuario, string nombre, string email, string password) : base(id, tipoUsuario, nombre, email, password)
        {

        }

        public Admin(int tipoUsuario, string nombre, string email, string password) : base(-1, tipoUsuario, nombre, email, password)
        {

        }

        public Admin() : base(-1, "", "", "")
        {

        }







        //========================================================== METODOS ====================================================================
        public void CrearNuevoUsuario (int tipoUsuario, string nombre, string email, string password)
        {
            ConnectionDao.CrearNuevoUsuario(tipoUsuario, nombre, email, password);
        }

        public bool CrearNuevaMateria (string nombre, int cuatrimestre, List<int> idsMateriasCorrelativas)
        {
            bool success = false;
            try
            {
                ConnectionDao.CrearNuevaMateria(nombre, cuatrimestre);
                int ultimoId = ConnectionDao.ObtenerUltimoIdMateria();
                ConnectionDao.CargarMateriasCorrelativas(ultimoId, idsMateriasCorrelativas);
                success = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return success;
        }

        public int CambiarEstadoMateria(int idAlumnoSeleccionado, int idMateriaSeleccionada)
        {
            int nuevoEstado = -1;

            //Buscamos al alumno y la materia seleccionada. Luego obtengo el ID de su relacion y su estado
            Alumno alumnoSeleccionado = ConnectionDao.BuscarAlumnoPorId(idAlumnoSeleccionado);
            Materia materiaSeleccionada = ConnectionDao.BuscarMateriaPorId(idMateriaSeleccionada);
            int estadoMateria = ConnectionDao.ObtenerEstadoMateria(idAlumnoSeleccionado, idMateriaSeleccionada);


            //Switcheamos su estado
            if(estadoMateria == 0)
            {
                ConnectionDao.CambiarEstadoMateria(idAlumnoSeleccionado, idMateriaSeleccionada, 1);
                nuevoEstado = 1;
            }
            else if(estadoMateria == 1)
            {
                ConnectionDao.CambiarEstadoMateria(idAlumnoSeleccionado, idMateriaSeleccionada, 0);
                nuevoEstado = 0;
            }


            return nuevoEstado;
        }

        public bool AsignarProfesorAMateria(int idProfesor, int idMateria)
        {
            bool success = false;

            if(ConnectionDao.ValidarProfesorDictaMateria(idProfesor, idMateria) == false)
            {
                ConnectionDao.AsignarProfesorAMateria(idProfesor, idMateria);
                success = true;
            }


            return success;
        }

        public int AsignarAlumnoAMateria(int idAlumno, int idMateria)
        {
            //En esta funcion se realizan varios return a lo largo de la misma debido a que se desea cortar
            //su ejecucion en caso de que sea necesario y devolver un posible codigo de error sin que siga ejecutandose.
            /*Returns:
             * -3: ERROR: No posee todas las correlativas aprobadas.
             * -2: ERROR: La materia ya esta aprobada.
             * -1: ERROR: La materia la esta cursando actualmente.
             * 
             *  1: SUCCESS: Se asigno correctamente la materia al alumno.
             */
            List<int> listadoIdsMateriasAprobadas = ConnectionDao.ObtenerListadoIdsMateriasAprobadasDelAlumno(idAlumno);
            List<int> listadoIdsMateriasCursando = ConnectionDao.ObtenerListadoIdsMateriasCursandoDelAlumno(idAlumno);
            List<int> listadoIdsMateriasCorrelativas = ConnectionDao.ObtenerListadoIdsMateriasCorrelativasDeMateria(idMateria);


            //Se valida que posea todas las materias correlativas aprobadas
            foreach(int materiaCorrelativa in listadoIdsMateriasCorrelativas) {

                if (!listadoIdsMateriasAprobadas.Contains(materiaCorrelativa))
                {
                    return -3;
                }

            }


            //Se valida que la materia no haya sido aprobada
            if (listadoIdsMateriasAprobadas.Contains(idMateria))
            {
                return -2;
            }


            //Se valida que la materia no se este cursando actualmente
            if (listadoIdsMateriasCursando.Contains(idMateria))
            {
                return -1;
            }



            //Validaciones pasadas satisfactoriamente
            ConnectionDao.AsignarAlumnoAMateria(idAlumno, idMateria);
            return 0;
        }
    
        public bool ExportarDatos(int formato, string path, int idMateria)
        {
            bool success = false;
            List<Alumno> listadoAlumnos = ConnectionDao.ObtenerListadoDeAlumnosQueCursanLaMateria(idMateria);

            if (formato == 1) //-----> Se exporta un archivo CSV
            {
                Archivo<Alumno> file = new Archivo<Alumno>(path + ".txt");
                file.GuardarArchivoCSV(listadoAlumnos);
                success = true;
            }
            else if (formato == 2) //-----> Se exporta un archivo JSON
            {

                Archivo<Alumno> file = new Archivo<Alumno>(path + ".json");
                file.GuardarArchivoJSON(listadoAlumnos);
                success = true;

            }
            return success;
        }
    
    }
}
