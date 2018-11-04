using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.trasversal.DTO
{
    class UsuariosDTO
    {
        public virtual int Id { get; set; }
        public virtual string Login { get; set; }
        public virtual string  Password { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int IdRol { get; set; }
    }
}
