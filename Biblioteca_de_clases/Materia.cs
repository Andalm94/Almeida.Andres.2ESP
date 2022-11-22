using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class Materia
    {

        //============== ATRIBUTOS ==================
        int id;
        private string nombre;
        private int cuatrimestre;


        //=================================== CONSTRUCTORES =========================================
        
        public Materia() : this(-1, "", -1)
        {

        }

        public Materia(int id, string nombre, int cuatrimestre)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Cuatrimestre = cuatrimestre;
        }

        //=================================== PROPERTIES =========================================
        
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int Cuatrimestre
        {
            get { return this.cuatrimestre; }
            set { this.cuatrimestre = value; }
        }

    }
}
