using System;
using System.Globalization;
using System.IO;
using log4net;
using log4net.Appender;
using ILog = log4net.ILog;

namespace Infraestructura.trasversal.Log4Net
{
    public class Log : ILogger
    {

      
        private static Log _instancia;
        public static string _aplicacionNombre;

        private static readonly object Bloqueo = new object();

        private Log()
        {
            ConstruirLog();
        }

        public static Log ObtenerInstancia
        {
            get
            {
                lock (Bloqueo)
                {
                    return _instancia ?? (_instancia = new Log());
                }
            }
        }

        private ILog _logger;

        public ILog Logger
        {
            get
            {
                if (_logger == null)
                {
                    ConstruirLog();
                }
                return _logger;
            }
        }



        #region Private Methods

        private void ConstruirLog()
        {

            var loggerName = typeof(Log).FullName;
            var logger = (log4net.Repository.Hierarchy.Logger)LogManager.GetRepository().GetLogger(loggerName);

            //Add the default log appender if none exist
            if (logger.Appenders.Count == 0)
            {
                var ruta = _aplicacionNombre;
                string directoryName = String.Format(@"{0}\", ruta);

                //If the directory doesn't exist then create it
                if (!Directory.Exists(directoryName))
                    Directory.CreateDirectory(directoryName);

                var fileName = Path.Combine(directoryName, "log-");

                //Create the rolling file appender
                var appender = new RollingFileAppender
                {
                    Name = "RollingFileAppender",
                    File = fileName,
                    StaticLogFileName = false,
                    AppendToFile = true,
                    CountDirection = -1,
                    DatePattern = "yyyyMMdd'.txt'",
                    RollingStyle = RollingFileAppender.RollingMode.Date,
                    MaxSizeRollBackups = 0,
                    MaximumFileSize = "7MB"
                };

                //Configure the layout of the trace message write
                var layout = new log4net.Layout.PatternLayout
                {
                    ConversionPattern =
                        "[%-5p] | [%date] | [%P{Method}] | [%P{Class}] | [%m]%n"
                };
                appender.Layout = layout;
                layout.ActivateOptions();

                //Let log4net configure itself based on the values provided
                appender.ActivateOptions();
                log4net.Config.BasicConfigurator.Configure(appender);
            }

            _logger = LogManager.GetLogger(loggerName);

        }

        private void SetProperties(string metodo, string clase)
        {
            try
            {
                ThreadContext.Properties["Method"] = metodo;
                GlobalContext.Properties["Class"] = clase;
            }
            catch (Exception ex)
            {
                Logger.Fatal("Error en metodo SetProperties = " + ex.Message);
            }
        }

        #endregion

        #region ILogger Members

        public void LogInfo(string metodo, string clase, string message, params object[] args)
        {

            var messageToLog = string.Format(CultureInfo.InvariantCulture, message, args);
            SetProperties(metodo, clase);
            Logger.Info(messageToLog);
        }

        public void LogWarning(string metodo, string clase, string message, params object[] args)
        {
            var messageToLog = string.Format(CultureInfo.InvariantCulture, message, args);
            SetProperties(metodo, clase);
            Logger.Warn(messageToLog);
        }

        public void LogError(string metodo, string clase, string message, params object[] args)
        {
            var messageToLog = string.Format(CultureInfo.InvariantCulture, message, args);
            SetProperties(metodo, clase);
            Logger.Error(messageToLog);
        }

        public void LogError(string metodo, string clase, string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrEmpty(message) && exception != null)
            {

                var messageToLog = string.Format(CultureInfo.InvariantCulture, message, args);
                var exceptionData = exception.ToString();
                SetProperties(metodo, clase);
                Logger.Error(string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToLog,
                    exceptionData));

            }
        }

        public void Debug(string metodo, string clase, string message, params object[] args)
        {
        }

        public void Debug(string metodo, string clase, string message, Exception exception, params object[] args)
        {
        }

        public void Debug(object item)
        {
        }


        public void Fatal(string metodo, string clase, string message, params object[] args)
        {
            if (!String.IsNullOrEmpty(message))
            {

                var messageToLog = string.Format(CultureInfo.InvariantCulture, message, args);
                SetProperties(metodo, clase);
                Logger.Fatal(messageToLog);

            }
        }

        public void Fatal(string metodo, string clase, string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrEmpty(message) && exception != null)
            {
                var messageToLog = string.Format(CultureInfo.InvariantCulture, message, args);
                var exceptionData = exception.ToString();
                SetProperties(metodo, clase);
                Logger.Fatal(string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToLog,
                    exceptionData));

            }
        }


        #endregion
    }
}
