using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Interfaces
{
    public interface ILogger
    {

        void Fatal(string timeStamp, string message);

        void Critical(string timeStamp, string message);

        void Error(string timeStamp, string message);

        void Warning(string timeStamp, string message);

        void Info(string timeStamp, string message);
    }
}
