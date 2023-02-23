using Jade.Objects;


namespace Jade.Lang
{
    public class Funcs
    {
        public static object Println(List<object> args, Visitor visitor)
        {
            object value = Helper.GetArgument(args, 0);

            Console.WriteLine(Helper.ReflectionMethodInvoke(value, "Repr", args.ToArray()));

            return new NullObj();
        }

        public static object Print(List<object> args, Visitor visitor)
        {
            object value = Helper.GetArgument(args, 0);

            Console.WriteLine(Helper.ReflectionMethodInvoke(value, "Repr", args.ToArray()));

            return new NullObj();
        }

        // TODO: Finish this
        public static object Evaluate(List<object> args, Visitor visitor)
        {
            object expression = Helper.GetArgument(args, 0);

            return expression;
        }

        public static object Min(List<object> args, Visitor visitor)
        {
            object one = Helper.GetArgument(args, 0);
            object two = Helper.GetArgument(args, 1);

            if (one is not IntObj || two is not IntObj)
            {
                return new Error("Type", "Function 'Min' requires type 'int'");
            }

            IntObj val1 = (IntObj) one;
            IntObj val2 = (IntObj) two;

            if (val1.Value < val2.Value)
            {
                return val1;
            } else
            {
                return val2;
            }
        }

        public static object Max(List<object> args, Visitor visitor)
        {
            object one = Helper.GetArgument(args, 0);
            object two = Helper.GetArgument(args, 1);

            if (one is not IntObj || two is not IntObj)
            {
                return new Error("Type", "Function 'Min' requires type 'int'");
            }

            IntObj val1 = (IntObj)one;
            IntObj val2 = (IntObj)two;

            if (val1.Value < val2.Value)
            {
                return val1;
            }
            else
            {
                return val2;
            }
        }
    }
}
