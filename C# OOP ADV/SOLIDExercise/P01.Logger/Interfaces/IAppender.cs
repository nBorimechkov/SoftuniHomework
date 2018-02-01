using P01.Logger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Interfaces
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        ILayout Layout { get; }
        void Append(string timeStamp, string reportLevel, string message);
    }
}
