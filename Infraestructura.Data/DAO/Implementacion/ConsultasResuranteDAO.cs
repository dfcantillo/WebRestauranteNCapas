using Infraestructura.Data.DAO.Contractos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.DAO.Implementacion
{
   
    public class ConsultasResuranteDAO: IConsultasResuranteDAO
    {
        #region Dependency Injection

        private readonly IConexionBD _conexionBD;
        public ConsultasResuranteDAO(IConexionBD conexionBD)
        {
            _conexionBD = conexionBD;

        }


        #endregion


        

    }
}
