using P01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Entities.Layouts
{
    public class XmlLayout : ILayout
    {
        public string FormatMessage(string timeStamp, string reportLevel, string message)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<log>" + Environment.NewLine);
           builder.Append($"    <date>{timeStamp}</date>" + Environment.NewLine);
           builder.Append($"    <level>{reportLevel}</level>" + Environment.NewLine);
           builder.Append($"    <message>{message}</message>" + Environment.NewLine);
            builder.Append("</log>");

            return builder.ToString();
        }
    }
}
