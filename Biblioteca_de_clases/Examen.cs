﻿using System;
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
        private string fecha;
        private float nota;
        private int idMateria;

        public Examen(int id, string nombre, string fecha, float nota, int idMateria)
        {
            this.id = id;
            this.nombre = nombre;
            this.fecha = fecha;
            this.nota = nota;
            this.idMateria = idMateria;
        }

        public Examen() : this(-1, "", "", 0, -1)
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

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public float Nota
        {
            get { return nota; }
            set { nota = value; }
        }

        public int IdMateria
        {
            get { return idMateria; }
            set { idMateria = value; }
        }
    }
}
