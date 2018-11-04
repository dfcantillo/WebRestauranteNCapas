using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.DAO.Contractos
{
    public interface IConexionBD
    {
       
        OracleConnection ConnectionDB();
    }
}
