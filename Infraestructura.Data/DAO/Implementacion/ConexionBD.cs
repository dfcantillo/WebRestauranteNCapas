using Em.Infrastructure.Transversal.Constants;
using Infraestructura.Data.DAO.Contractos;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.DAO.Implementacion
{
    public class ConexionBD : IConexionBD
    {
        public OracleConnection ConnectionDB()
        {
            try
            {
                string oradb = Configurations.CONEXION_BD;
                OracleConnection conn = new OracleConnection(oradb);
                return conn;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
