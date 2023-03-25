using AppNET.Domain.Interfaces;
using System.Text;

namespace AppNET.Infrastructure.LogToTxt
{
    public class Logger : ILogger
    {

        private readonly string LOG_TXT_NAME = "Log_"+DateTime.Now.ToShortDateString().Replace(".", "_") + ".txt";  //Log_23_03_2023 gibi bir dosya adı oluşturacak..
        public void Error(string message)
        {
            Log(message,Logs.Error);
        }

        public void Info(string message)
        {
            Log(message, Logs.Info);
        }

        public void Warn(string message)
        {
            Log(message, Logs.Warn);
        }

        private void Log(string message,Logs logType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------");
            sb.AppendLine("Date:"+DateTime.Now);
            sb.AppendLine("Log Type:"+ logType);
            sb.AppendLine("Message:"+message);
            sb.AppendLine("----------------------");
            File.AppendAllText(LOG_TXT_NAME,sb.ToString());
        }
        public enum Logs
        {
            Error,
            Warn,
            Info
        
        }
    }
}