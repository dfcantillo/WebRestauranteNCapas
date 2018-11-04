using Em.Infrastructure.Transversal.Constants;
using Infraestructura.trasversal.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.trasversal.Utilities
{


    public class Tools : ITools
    {
        public string[] ObtenerFranjaDeFechasYNombreArchivo(string accion)
        {
            string[] respuesta;
            try
            {

               
                string sNombreArchivo = string.Empty;
                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                int hora = DateTime.Now.Hour;

                string sDay = (day <= 9) ? string.Concat("0", day) : Convert.ToString(day);
                string sMonth = (month <= 9) ? string.Concat("0", month) : Convert.ToString(month);


                string sFechaActual = string.Concat(sDay, "/", sMonth, "/", year);

                string sHoraInicio = string.Concat(hora, ":00:00");
                string sHoraFin = (hora == 23) ? "00:00:00" : string.Concat((hora + 1), ":00:00");
                string fechaInicio = string.Concat(sFechaActual, " ", sHoraInicio);
                string fechaFin = string.Concat(sFechaActual, " ", sHoraFin);

                //Nombre que llevara el archivo creado
                sNombreArchivo = string.Concat(Configurations.NOMBRE_ARCHIVO ,sDay, sMonth, year ,"_","CORTE_" , hora,"00" , Configurations.XLSX );

                // Opciones a retornar
                switch (accion)
                {
                    case "Rango Fechas":
                        respuesta = new string[] { fechaInicio, fechaFin };
                        break;

                    case "Nombre Archivo":
                        respuesta = new string[] { sNombreArchivo };
                        break;

                    default:
                        respuesta = new string[] { "No ingreso una acción valida" };
                        break;
                }

                return respuesta;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }







        public object[] SendCorreo(SendMailDTO sendMailDTO, List<string> archivos, string nombreCorreo, string nombreArchivo)
        {
            MailMessage Mail = new MailMessage();
            SmtpClient SMTP = new SmtpClient();
            try
            {
                Mail.To.Clear();
                Mail.From = new MailAddress(sendMailDTO.Remitente, nombreCorreo);

                foreach (var address in sendMailDTO.Destinatarios.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Mail.To.Add(address);
                }

                Mail.Subject = sendMailDTO.Asunto;
                Mail.Body = sendMailDTO.Mensaje;
                Mail.IsBodyHtml = true;
                Mail.Priority = MailPriority.Normal;
                if (archivos != null)
                {
                    //agregado de archivo
                    foreach (string archivo in archivos)
                    {
                        //comprobamos si existe el archivo y lo agregamos a los adjuntos
                        if (System.IO.File.Exists(@archivo))
                        {
                            var a = new Attachment(@archivo, System.Net.Mime.MediaTypeNames.Application.Octet);
                            Mail.Attachments.Add(a);
                        }
                    }
                }

                MailAddress fromAddress = new MailAddress(sendMailDTO.Remitente, nombreCorreo); //CORREO REMITENTE
                SMTP.Host = Configurations.HOST;  // host;//"smtp.gmail.com";
                SMTP.Port = Configurations.PUERTO; //587
                SMTP.EnableSsl = true;
                SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                SMTP.UseDefaultCredentials = false;
                SMTP.Credentials = new NetworkCredential(fromAddress.Address, Configurations.PASSWORD);

                SMTP.Send(Mail);
                return new object[] { true };
            }
            catch (Exception ex)
            {
                return new object[] { false, ex.Message };
            }
            finally
            {
                SMTP = null;
                Mail.Dispose();
                Mail = null;
            }
        }




    }

}
