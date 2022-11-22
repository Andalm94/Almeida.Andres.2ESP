using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{

    public class Alumno : usuarioUTN
    {

        //=================================== CONSTRUCTORES ======================================================

        public Alumno(int tipoUsuario, string user, string pass, string nombre, string telefono, string email)
        {
            this.TipoUsuario = tipoUsuario;
            this.User = user;
            this.Password = pass;
            this.Telefono = telefono;
            this.Email = email;
        }

        public Alumno() : this (-1, "", "", "", "", "")
        {

        }

        public Alumno(int id, int tipoUsuario, string user, string pass)
        {
            this.Id = id;
            this.TipoUsuario = tipoUsuario;
            this.User = user;
            this.Password = pass;

        }

        public Alumno(int id, int tipoUsuario, string nombre, string user, string pass)
        {
            this.Id = id;
            this.TipoUsuario = tipoUsuario;
            this.Nombre = nombre;
            this.User = user;
            this.Password = pass;

        }
    }
}
