using P01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Entities.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string timeStamp, string reportLevel, string message)
        {
            return $"{timeStamp} - {reportLevel} - {message}";
        }
    }
}
