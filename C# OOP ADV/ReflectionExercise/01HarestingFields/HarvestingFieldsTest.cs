namespace _01HarestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    class HarvestingFieldsTest
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            while (input != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        getPrivateFields();
                        break;
                    case "protected":
                        getProtectedFields();
                        break;
                    case "public":
                        GetPublicFields();
                        break;
                    case "all":
                        GetAllFields();
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
        }

        public static void getPrivateFields()
        {
            Type classType = typeof(HarvestingFields);
            FieldInfo[] fieldInfo = classType.GetFields(
                BindingFlags.Instance  | BindingFlags.NonPublic);

            foreach (FieldInfo field in fieldInfo.Where(f => f.IsPrivate))
            {
                Console.WriteLine(($"private {field.FieldType.Name} {field.Name}"));
            }
        }

        public static void getProtectedFields()
        {
            Type classType = typeof(HarvestingFields);
            FieldInfo[] fieldInfo = classType.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fieldInfo.Where(f => !f.IsPrivate))
            {
                Console.WriteLine(($"protected {field.FieldType.Name} {field.Name}"));
            }
        }

        public static void GetPublicFields()
        {
            Type classType = typeof(HarvestingFields);
            FieldInfo[] fieldInfo = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Public);

            foreach (FieldInfo field in fieldInfo)
            {
                Console.WriteLine(($"public {field.FieldType.Name} {field.Name}"));
            }
        }

        public static void GetAllFields()
        {
            Type classType = typeof(HarvestingFields);
            FieldInfo[] fieldInfo = classType.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fieldInfo)
            {
                if (field.IsPrivate)
                {
                    Console.WriteLine(($"private {field.FieldType.Name} {field.Name}"));
                }
                else if (field.IsPublic)
                {
                    Console.WriteLine(($"public {field.FieldType.Name} {field.Name}"));
                }
                else
                {
                    Console.WriteLine(($"protected {field.FieldType.Name} {field.Name}"));
                }
                
            }
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fieldInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder stringBilder = new StringBuilder();

            foreach (FieldInfo field in fieldInfo)
            {
                stringBilder.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBilder.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBilder.AppendLine($"{method.Name} have to be private!");
            }

            return stringBilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"All Private Methods of Class: {className}");
            stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classNonPublicMethods)
            {
                stringBuilder.AppendLine(method.Name);
            }
            return stringBuilder.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
