using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Infrastructure.Transversal.Constants
{
    public class Configurations
    {
        
        public const string NOMBRE_ARCHIVO = "InformeDeEmpresa_";


        public const string CONEXION_BD = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=MZLSKDBDEV.colombia.emergiacc.com)(PORT=1523)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=MOBILE)));User Id=MOBILE;Password=MOBILE;";

        public const string HOST = "smtp.gmail.com";

        public const int PUERTO = 587;

        public const string HOST_POP = "pop.gmail.com";

        public const int PUERTO_POP = 995;

        public const string REMITENTE = "rpa_emergia@emergiacc.com";

       
        public const string PASSWORD = "lbdcwtdjwrshyfrw";

        public const string XLSX = ".xlsx";

        public const string TIPO_OK = "OK";

        public const string TIPO_ERROR = "ERROR";

        public const string SMS_ERROR = "Hola, en este momento el robot no puede continuar por favor revise su correo y siga las instruciones que allí se detallan , una vez haya realizado ese paso preciones Continuar";

        public const string SMS_OK = "OK";

   
      


    }
}
