using Jade.Objects;


namespace Jade.Lang
{
    public class Helper
    {
        public static object GetPropertyValue(object Instance, string PropertyName)
        {
            return Instance.GetType().GetProperty(PropertyName).GetValue(Instance);
        }

        public static object ReflectionMethodInvoke(object obj, string name, object[] @params)
        {
            object o = obj.GetType().GetMethod(name).Invoke(obj, @params);
            if (o == null)
            {
                return new NullObj();
            } else
            {
                return o;
            }
        }

        public static Error RaiseOperatorError(string op, object other, string thisType)
        {
            return new Error("Type", $"Unsupported operation '{op}' on type '{thisType}' and" +
                    $" '{Helper.GetPropertyValue(other, "Type")}'");
        }

        public static Error RaiseNotOperatorError(string thisType)
        {
            return new Error("Type", $"Unable to perform operation unary '!' on type {thisType}");
        }

        public static Error RaiseIndexOperatorError(string thisType)
        {
            return new Error("Type", $"Unable to Index type '{thisType}'");
        }

        public static object GetArgument(List<object> args, int index)
        {
            try
            {
                return args[index];
            } catch (IndexOutOfRangeException)
            {
                return new Error("Index", "Invalid number of arguments");
            }
        }
    }
}
