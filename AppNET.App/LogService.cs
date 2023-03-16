using AppNET.Domain.Entities.LogAggregate;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppNET.App
{
    public class LogService : ILogService
    {

        public static List<Log> logList = new List<Log>();
        private readonly IRepository<Log> _logRepository;

        public LogService()
        {
            _logRepository = IOCContainer.Resolve<IRepository<Log>>();
        }
        public void ErrorLog(string message)
        {
            Log errorLog = new Log(LogType.Error, message);
            errorLog._logDate = DateTime.Now;
            logList.Add(errorLog);
            SaveLog(errorLog._logType, message);

        }

        public List<Log> GetLogs()
        {
            return logList;
        }

        public void InfoLog(string message)
        {
            Log infoLog = new Log(LogType.Information, message);
            infoLog._logDate = DateTime.Now;
            logList.Add(infoLog);
            SaveLog(infoLog._logType, message);
        }
        public void SuccessLog(string message)
        {
            Log successLog = new Log(LogType.Success, message);
            successLog._logDate = DateTime.Now;
            logList.Add(successLog);
            SaveLog(successLog._logType, message);
        }
        public void SaveLog(LogType logType, string logMessage)
        {
            Log log = new Log(logType, logMessage);
            log._logDate = DateTime.Now;

            WriteLogToTxt(log, LogFileRoad.LOG_FILE_ROAD);
        }  

        public void WriteLogToTxt(Log log, string fileRoad)
        {
           File.WriteAllText(fileRoad, JsonSerializer.Serialize(log)); 
        }
    }
}
