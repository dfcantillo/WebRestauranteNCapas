using Infraestructura.trasversal.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.trasversal.Utilities
{
    public interface ITools
    {
        string[] ObtenerFranjaDeFechasYNombreArchivo(string accion);

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendMailDTO"></param>
        /// <param name="archivos"></param>
        /// <param name="nombreCorreo"></param>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        object[] SendCorreo(SendMailDTO sendMailDTO, List<string> archivos, string nombreCorreo, string nombreArchivo);




        
    }
}
