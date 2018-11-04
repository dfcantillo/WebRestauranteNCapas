using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;



namespace Infraestructura.trasversal.Log4Net
{
    /// <summary>
    /// Log Factory
    /// </summary>
    public static class LoggerFactory
    {
        #region Members

        private static ILoggerFactory _currentLogFactory = null;
        public static string _nombreAplicacion = "";

        #endregion

        #region Public Methods


        /// <summary>
        /// Set the  log factory to use
        /// </summary>
        /// <param name="logFactory">Log factory to use</param>
        public static void SetCurrent(ILoggerFactory logFactory)
        {
            _currentLogFactory = logFactory;
        }


        public static ILogger CreateLog()
        {
            return (_currentLogFactory != null) ? _currentLogFactory.Create(_nombreAplicacion) : null;
        }

        #endregion
    }
}