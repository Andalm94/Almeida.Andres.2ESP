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
        
        public int AsignarNotasAAlumnos(int idMateria, int idExamen, List<int> idAlumnos, List<float>notas)
        {
            int success = 1;

            //Se valida que las notas ingresadas esten en rango correcto (1-10)
            //Se valida que la cantidad de alumnos recibido sea igual a la cantidad de notas
            //Se asigna la nota a cada alumno
            //Se marca el examen como corregido
            if(ValidarNotasEnRango(notas) != 1)
            {
                success = -3;
            }
            else
            {
                if (ConnectionDao.ObtenerEstadoExamen(idExamen) != 0)
                {
                    success = -2;
                }
                else
                {
                    if (idAlumnos.Count != notas.Count)
                    {
                        success = -1;
                    }
                    else
                    {

                        //Se carga la nota
                        for (int i = 0; i < idAlumnos.Count; i++)
                        {
                            ConnectionDao.CargarNotaAAlumno(idAlumnos[i], idMateria, notas[i]);


                            //Se valida si el alumno tiene las notas cargadas y puede aprobar la materia.
                            //Si la validacion es true, se marca la materia como aprobada y se elimina como materia cursando
                            if (ValidarAprobarMateriaAlumno(idAlumnos[i], idMateria) == 0)
                            {
                                ConnectionDao.EliminarMateriaCursandoAlumno(idAlumnos[i], idMateria);
                            }

                        }
                        success = 0;
                        ConnectionDao.MarcarExamenCorregido(idExamen);
                    }
                }
            }

            

            return success;
        }
    


        public int ValidarAprobarMateriaAlumno(int idAlumno, int idMateria)
        {
            int success = -1;
            List<float> notas = ConnectionDao.ObtenerNotasDeMateriaDeAlumno(idAlumno, idMateria);
            float promedio = notas.Sum() / notas.Count();

            if (notas.Count >= 2 && promedio >= 6)
            {
                promedio = (float)(Math.Truncate((double)promedio * 100.0) / 100.0); //Se redondea a 2 decimales
                ConnectionDao.AprobarMateriaAlumno(idAlumno, idMateria, notas[0], notas[1], promedio);
                success = 0;
            }

            return success;
        }

        public int ValidarNotasEnRango(List<float> listadoNotas)
        {
            int success = 1;

            foreach (float nota in listadoNotas)
            {
                if (nota < 1 || nota > 10)
                {
                    success = -1;
                    break;
                }
            }
            return success;
        }
    }
}
