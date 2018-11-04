using System;


namespace Infraestructura.trasversal.Log4Net
{
    public interface ILogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="clase"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Debug(string metodo, string clase, string message, params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="clase"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Debug(string metodo, string clase, string message, Exception exception, params object[] args);

        /// <summary>
        /// Log debug message 
        /// </summary>
        /// <param name="item">The item with information to write in debug</param>
        void Debug(object item);

        /// <summary>
        ///
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="clase"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Fatal(string metodo, string clase, string message, params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="clase"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void Fatal(string metodo, string clase, string message, Exception exception, params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="clase"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogInfo(string metodo, string clase, string message, params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="clase"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogWarning(string metodo, string clase, string message, params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="clase"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogError(string metodo, string clase, string message, params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="clase"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="args"></param>
        void LogError(string metodo, string clase, string message, Exception exception, params object[] args);
    }
}
