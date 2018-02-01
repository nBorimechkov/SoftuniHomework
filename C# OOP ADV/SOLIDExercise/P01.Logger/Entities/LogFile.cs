using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Entities
{
    public class LogFile
    {
        private const string DefaultFilename = "log.txt";
        private StringBuilder builder;

        public LogFile()
        {
            this.builder = new StringBuilder();
        }

        public int Size { get; private set; }

        private int GetLettersOnlySum(string message)
        {
            return message.Where(c => char.IsLetter(c)).Sum(c => c);
        }

        public void Write(string message)
        {
            this.builder.AppendLine(message);
            File.AppendAllText(DefaultFilename, message + Environment.NewLine);
            this.Size = this.GetLettersOnlySum(message);
        }
    }
}
