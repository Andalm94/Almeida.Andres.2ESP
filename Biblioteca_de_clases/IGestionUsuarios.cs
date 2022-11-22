using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public interface IGestionUsuarios
    {

        int Id { get; set; }
        int TipoUsuario { get; set; }
        string Nombre { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string Telefono { get; set; }
        string Email { get; set; }

    }
}
