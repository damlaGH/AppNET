using AppNET.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNET.Domain.Entities.LogAggregate
{
    public class Log:BaseEntity
    {
        public LogType _logType;
        public DateTime _logDate;
        public string _logMessage;

        public Log(LogType logType, string logMessage)
        {
            _logType = logType;
            _logMessage = logMessage;
            _logDate = DateTime.Now;
        }
       
    }
}
