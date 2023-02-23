using Jade.Objects;


namespace Jade.Lang
{
    public class Env
    {
        public readonly Dictionary<string, VarObj> vars = new();
        public readonly Dictionary<string, FuncObj> funcs = new();
        
        public Env()
        {
            vars.Add("PI", new VarObj("PI", new FloatObj(Math.PI.ToString()), true, false));
            vars.Add("CD", new VarObj("CD", new StringObj(Directory.GetCurrentDirectory()), true, false));

            funcs.Add("Println", new FuncObj("Println", new string[] { "value" }, false, true, null));
            funcs.Add("Min", new FuncObj("Min", new string[] { "val1", "val2" }, false, true, null));
            funcs.Add("Max", new FuncObj("Max", new string[] { "val1", "val2" }, false, true, null));
        }

        public string ShowVariables()
        {
            string str = "";
            foreach (var v in vars.Values)
            {
                str += v.Name + ", ";
            }

            return $"Environment variables: {str}";
        }

        public string ShowFunctions()
        {
            string str = "";
            foreach (var v in funcs.Values)
            {
                str += v.Name + ", ";
            }

            return $"Environment Functions: {str}";
        }
    }
}
