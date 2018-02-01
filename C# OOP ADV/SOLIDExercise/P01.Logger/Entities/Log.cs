using P01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Entities
{
    public class Log : ILogger
    {
        private IAppender[] appenders;

        public Log(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        private void Logg(string timeStamp, string reportLevel, string message)
        {
            foreach (IAppender appender in appenders)
            {
                if ((ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel) >= appender.ReportLevel)
                {
                    appender.Append(timeStamp, reportLevel, message);
                }
            }
        }

        public void Critical(string timeStamp, string message)
        {
            this.Logg(timeStamp, "Critical", message);
        }
        
        public void Fatal(string timeStamp, string message)
        {
            this.Logg(timeStamp, "Fatal", message);
        }

        public void Error(string timeStamp, string message)
        {
            this.Logg(timeStamp, "Error", message);
        }

        public void Warning(string timeStamp, string message)
        {
            this.Logg(timeStamp, "Warning", message);
        }

        public void Info(string timeStamp, string message)
        {
            this.Logg(timeStamp, "Info", message);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Logger info:");

            foreach (IAppender appender in appenders)
            {
                builder.AppendLine(appender.ToString());
            }
            return builder.ToString();
        }
    }
}
