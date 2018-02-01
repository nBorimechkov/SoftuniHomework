using P01.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P01.Logger.Entities.Factories
{
    public class LayoutFactory
    {
        public static ILayout GetInstance(string layoutName)
        {
            Type layoutType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == layoutName);

            return (ILayout)Activator.CreateInstance(layoutType);        }
    }
}
