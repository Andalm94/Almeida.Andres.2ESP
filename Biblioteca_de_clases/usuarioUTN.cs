using System.Net;
using System.Runtime.Serialization;

namespace Biblioteca_de_clases
{
    public class usuarioUTN
    {
        private int id;
        private int tipoUsuario;
        private string nombre;
        private string user;
        private string password;
        private string telefono;
        private string email;


        //=================================== CONSTRUCTOR ======================================================
        public usuarioUTN() : this(-1, "", "")
        {

        }

        public usuarioUTN(int tipoUsuario, string name, string user, string password) : this(tipoUsuario, user, password)
        {
            this.nombre = name;
        }

        public usuarioUTN(int tipoUsuario, string user, string password)
        {
            this.tipoUsuario = tipoUsuario;
            this.user = user;
            this.password = password;
        }

        public usuarioUTN(int id, int tipoUsuario, string user, string pass)
        {
            this.Id = id;
            this.TipoUsuario = tipoUsuario;
            this.User = user;
            this.Password = pass;

        }


        //=================================== PROPIEDADES ======================================================

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public int TipoUsuario
        {
            get { return this.tipoUsuario; }
            set { this.tipoUsuario = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string User
        {
            get { return this.user; }
            set { this.user = value; }  
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

    }
}