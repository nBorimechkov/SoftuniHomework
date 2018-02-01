using P01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Entities.Factories
{
    public class AppenderFactory
    {
        public static IAppender GetInstance(string appenderName, ILayout layoutType)
        {
            Type appenderType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == appenderName);

            return (IAppender)Activator.CreateInstance(appenderType, layoutType);
        }
    }
}

