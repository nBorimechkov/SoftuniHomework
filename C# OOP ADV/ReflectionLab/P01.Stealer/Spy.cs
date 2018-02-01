using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType(classToInvestigate);
            FieldInfo[] fields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            StringBuilder builder = new StringBuilder();

            Object instance = Activator.CreateInstance(classType, new object[] { });

            builder.AppendLine($"Class under investigation: {classToInvestigate}");

            foreach (FieldInfo field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                    builder.AppendLine($"{field.Name} = {field.GetValue(classType)}");
                
            }
            return builder.ToString().Trim();
        }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder builder = new StringBuilder();

        Object instance = Activator.CreateInstance(classType, new object[] { });

        foreach (FieldInfo field in fields)
        {
            builder.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} have to be public");
        }

        foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} have to be private!");
        }

        return builder.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);


        StringBuilder builder = new StringBuilder();


        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return builder.ToString().Trim();
    }
}

