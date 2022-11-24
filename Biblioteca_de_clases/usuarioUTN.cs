using System.Net;
using System.Runtime.Serialization;

namespace Biblioteca_de_clases
{
    public class usuarioUTN : IGestionUsuarios
    {
        private int id;
        private int tipoUsuario;
        private string nombre;
        private string email;
        private string password;



        //=================================== CONSTRUCTORES ======================================================

        public usuarioUTN(int id, int tipoUsuario, string nombre, string email, string password)
        {
            this.id = id;
            this.tipoUsuario = tipoUsuario;
            this.nombre = nombre;
            this.email = email;
            this.password = password;
        }

        public usuarioUTN(int tipoUsuario, string nombre, string email, string password) : this(-1, tipoUsuario, nombre, email, password)
        {

        }

        public usuarioUTN() : this(-1, "", "", "")
        {

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

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }




    }
}