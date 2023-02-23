using Jade.Lang;
using System.Reflection;

namespace Jade.Objects
{
    public class FuncObj
    {
        public string Name;
        public string[] Params;
        public bool IsPublic;
        public bool Immutable;
        public JadeParser.BlockContext Block;

        public Env env;

        public FuncObj(string name, string[] @params, bool isPublic, bool immutable, JadeParser.BlockContext block)
        {
            Name = name;
            Params = @params;
            IsPublic = isPublic;
            Immutable = immutable;
            Block = block;
        }

        public string Repr(object context)
        {
            return $"Function({Name}, {Params})";
        }

        public void IncludeParameters(List<object> args)
        {
            int l = Params.Length - 1;
            for (int i = 0; i < l; i++)
            {
                env.vars.Add(Params[i], new VarObj(Name, args[i], false, false));
            }
        }

        public object Call(List<object> args, Visitor visitor)
        {
            /*
            if (visitor.VisitorName == "Called")
            {
                Console.WriteLine($"Function '{Name}' Called from 'Called' visitor");
            }
            else
            {
                Console.WriteLine($"Function '{Name}' Called from 'Main' visitor");
            }*/

            if (Block != null)
            {
                IncludeParameters(args);

                return new Visitor(new Env(), "Called").VisitBlock(Block);
            } else
            {
                Type type = visitor.funcs.GetType();
                MethodInfo[] methods = type.GetMethods();

                foreach (MethodInfo method in methods)
                {
                    if (method.Name == Name)
                    {
                        return method.Invoke(visitor.funcs, new object[] { args, visitor });
                    }
                }

                return new NullObj();
            }
        }
    }
}
