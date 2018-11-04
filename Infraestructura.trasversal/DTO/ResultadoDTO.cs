using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.trasversal.DTO
{
    public class ResultadoDTO
    {

        public virtual string Resultado { get; set; }

        public virtual string Mensaje { get; set; }

        public virtual string MensajeDeExcepcion { get; set; }
    }
}
