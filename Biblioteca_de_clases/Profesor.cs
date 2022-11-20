using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{

    public class Profesor : usuarioUTN
    {


        //=================================== CONSTRUCTORES =========================================

        public Profesor(int tipoUsuario, string user, string password, string nombre, string telefono, string email) : base(tipoUsuario, user, password)
        {
            this.Telefono = telefono;
            this.Email = email;
        }





        public Profesor() : this(-1, "", "", "", "", "")
        {
        }

        public Profesor(int id, int tipoUsuario, string user, string password)
        {
            this.Id = id;
            this.TipoUsuario = tipoUsuario;
            this.User = user;
            this.Password = password;
        }
    }
}
