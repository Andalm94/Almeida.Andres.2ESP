using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Examen
    {
        private int id;
        private string nombre;
        private DateTime fecha;
        private int idMateria;
        private int corregido;

        public Examen(int id, string nombre, DateTime fecha, int idMateria, int corregido)
        {
            this.id = id;
            this.nombre = nombre;
            this.fecha = fecha;
            this.idMateria = idMateria;
            this.corregido = corregido;
        }

        public Examen() : this(-1, "", new DateTime(), -1, 0)
        {

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int IdMateria
        {
            get { return idMateria; }
            set { idMateria = value; }
        }
    }
}
