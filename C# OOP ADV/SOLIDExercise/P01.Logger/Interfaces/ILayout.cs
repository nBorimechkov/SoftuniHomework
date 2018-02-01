using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string timeStamp, string reportLevel, string message);
    }
}
