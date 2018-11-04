using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.trasversal.DTO
{
    class FacturaDTO
    {
        public virtual int Id { get; set; }
        public virtual string NombrVendedor { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual int ValorCompra { get; set; }
        public virtual int IdCompra { get; set; }


    }
}
