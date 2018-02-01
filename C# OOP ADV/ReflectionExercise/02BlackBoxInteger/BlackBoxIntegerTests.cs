namespace _02BlackBoxInteger
{
    using System;
    using System.Reflection;
    using System.Text;

    class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            Type classType = typeof(BlackBoxInt);
            Type[] ctorParamsType = {typeof(int) };
            ConstructorInfo ctorInt = classType.GetConstructor(new Type[] { });
            BlackBoxInt blackBox = (BlackBoxInt)ctorInt.Invoke(new object[] { });
            FieldInfo field = classType.GetField("innerValue");
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            while (input != "END")
            {
                string[] commands = input.Split('_');
                string command = commands[0];
                int number = int.Parse(commands[1]);
                switch (command)
                {
                    case "Add":
                        MethodInfo info = classType.GetMethod("Add");
                        info.Invoke(blackBox, new object[] { number });
                        int fieldValue = (int)field.GetValue(blackBox);
                        break;
                    case "Subtract":

                        break;
                    case "Divide":

                        break;
                    case "Multiply":

                        break;
                    case "LeftShift":

                        break;
                    case "RightShift":

                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
