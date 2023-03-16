using AppNET.Domain.Entities.LogAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.App
{
    public interface ILogService
    {
        void ErrorLog(string message);
        void SuccessLog(string message);
        void InfoLog(string message);
        void SaveLog(LogType logType ,string logMessage);
        List<Log> GetLogs();

        void WriteLogToTxt(Log log, string fileRoad);
    } 
}
