using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.trasversal.Log4Net
{
    /// <summary>
    /// A Log4Net Source base, log factory
    /// </summary>
    public class Log4NetLogFactory : ILoggerFactory
    {
        /// <summary>
        /// Create the trace source log
        /// </summary>
        /// <returns>New ILog based on Trace Source infrastructure</returns>
        public ILogger Create(string programName)
        {
            Log._aplicacionNombre = programName;
            return Log.ObtenerInstancia;            
        }
    }
}
