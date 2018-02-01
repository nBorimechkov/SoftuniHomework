using P01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Entities.Appenders
{
    class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public int Count { get; private set; }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string timeStamp, string reportLevel, string message)
        {
            string formattedMessage = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            Console.WriteLine(formattedMessage);
            this.Count++;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Appender type: {this.GetType().Name}, ");
            builder.Append($"Layout type: {this.Layout.GetType().Name}, ");
            builder.Append($"Report level: {this.ReportLevel.ToString().ToUpper()}, ");
            builder.Append($"Messages appended: {this.Count}, ");

            return builder.ToString();
        }
    }
}
