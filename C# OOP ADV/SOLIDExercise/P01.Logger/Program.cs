using P01.Logger.Entities;
using P01.Logger.Entities.Appenders;
using P01.Logger.Entities.Factories;
using P01.Logger.Entities.Layouts;
using P01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            int appenderCount = int.Parse(Console.ReadLine());
            IAppender[] appenders = new IAppender[appenderCount];
            for (int i = 0; i < appenderCount; i++)
            {
                string[] appenderInfo = Console.ReadLine().Split();
                ILayout currentLayout = LayoutFactory.GetInstance(appenderInfo[1]);
                IAppender currentAppender = AppenderFactory.GetInstance(appenderInfo[0], currentLayout);
                if (appenderInfo.Length > 2)
                {
                    string enumName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(appenderInfo[2].ToLower());
                    currentAppender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), enumName);
                }

                appenders[i] = currentAppender;
            }

            ILogger logger = new Log(appenders);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] messageParts = input.Split('|');
                string methodName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(messageParts[0].ToLower());
                MethodInfo currentMethod = typeof(Log).GetMethod(methodName);
                currentMethod.Invoke(logger, new string[] { messageParts[1], messageParts[2] });

            }

            Console.WriteLine(logger);
            Console.ReadLine();
        }
    }
}
