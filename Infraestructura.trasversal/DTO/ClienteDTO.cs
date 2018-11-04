using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.trasversal.DTO
{
    public class ClienteDTO
    {
       public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellidos { get; set; }
         public virtual  DateTime FechaNacimiento { get; set; }


        public virtual string LugarNacimiento { get; set; }
        public virtual string Telefono { get; set; }

    }
}
