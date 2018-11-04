using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.trasversal.DTO
{
    public class ProductosDTO
    {
        public virtual int Id { get; set; }
        public virtual string nombre { get; set; }
        public virtual int Precio { get; set; }
        public virtual DateTime FechaProducto { get; set; }

        public virtual int IdCategoria { get; set; }
        public virtual int idProvedores { get; set; }
        public virtual int IdProducto { get; set; }

    }
}
