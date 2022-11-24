using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{

    public class Profesor : usuarioUTN
    {
        List<Materia> materiasDictando;

        //======================================================= CONSTRUCTORES =================================================================

        public Profesor(int id, int tipoUsuario, string nombre, string email, string password) : base(id, tipoUsuario, nombre, email, password)
        {

        }

        public Profesor(int tipoUsuario, string nombre, string email, string password) : base(-1, tipoUsuario, nombre, email, password)
        {

        }

        public Profesor() : base(-1, "", "", "")
        {

        }

        //======================================================= PROPIEDADES =================================================================

        public List<Materia> MateriasDictando
        {
            get { return materiasDictando; }
            set { materiasDictando = value; }
        }

        //======================================================== METODOS ===================================================================
    
        public int CrearExamen(int idMateria, string nombre, DateTime fecha)
        {
            int cantidadExamenesDeMateria = ConnectionDao.ObtenerCantidadDeExamenesQueTieneMateria(idMateria);

            //Se valida que la materia no posea mas de dos examenes
            //Si posee mas de dos examenes devuelve -2 y se corta la ejecucion
            if(cantidadExamenesDeMateria >= 2)
            {
                return -1;
            }

            //Pasadas las validaciones, carga un nuevo examen en la DB
            ConnectionDao.CrearNuevoExamen(idMateria, nombre, fecha);
            return 1;
        }
        
        public int AsignarNotaAlumno(int idMateria, int idAlumno, float nota)
        {
            int success = 0;


            return success;
        }
    }
}
