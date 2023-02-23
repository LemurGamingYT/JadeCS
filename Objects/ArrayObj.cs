using Jade.Lang;
using System.Text;

namespace Jade.Objects
{
    public class ArrayObj
    {
        public object[] Value;
        public string Type = "array";

        public ArrayObj(object[] value) {
            Value = value;
        }

        public string Repr(object context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            for (int i = 0; i < Value.ToArray().Length; i++)
            {
                sb.Append(Helper.ReflectionMethodInvoke(Value[i], "Repr", new object[] { this }));
                sb.Append(i == Value.Length - 1 ? "" : ", ");
            }

            sb.Append(']');

            return sb.ToString();
        }

        public ArrayObj RemoveDuplicates(List<object> args)
        {
            List<object> V = (List<object>) Value.Clone();
            List<object> cache = new();
            foreach (var arg in Value)
            {
                object property = Helper.GetPropertyValue(arg, "Value");
                if (cache.Contains(property))
                {
                    V.Remove(property);
                } else
                {
                    cache.Add(property);
                }
            }

            return new ArrayObj(V.ToArray());
        }

        public object Add(object other)
        {
            if (other is ArrayObj a)
            {
                return new ArrayObj(Value.Concat(a.Value).ToArray());
            }
            else
            {
                return Helper.RaiseOperatorError("+", other, Type);
            }
        }

        public object Sub(object other)
        {
            if (other is IntObj i)
            {
                return new ArrayObj(Value.Skip((int)i.Value).ToArray());
            }
            else
            {
                return Helper.RaiseOperatorError("-", other, Type);
            }
        }

        public object Mul(object other)
        {
            return Helper.RaiseOperatorError("*", other, Type);
        }

        public object Div(object other)
        {
            return Helper.RaiseOperatorError("/", other, Type);
        }

        public object Pow(object other)
        {
            return Helper.RaiseOperatorError("**", other, Type);
        }

        public object Mod(object other)
        {
            return Helper.RaiseOperatorError("%", other, Type);
        }

        public object Eq(object other)
        {
            if (other is ArrayObj a)
            {
                return new BoolObj((Value == a.Value).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError("<=", other, Type);
            }
        }

        public object Neq(object other)
        {
            if (other is ArrayObj a)
            {
                return new BoolObj((Value != a.Value).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError("!=", other, Type);
            }
        }

        public object Gt(object other)
        {
            if (other is ArrayObj a)
            {
                return new BoolObj((Value.Length > a.Value.Length).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError(">", other, Type);
            }
        }

        public object Gte(object other)
        {
            if (other is ArrayObj a)
            {
                return new BoolObj((Value.Length >= a.Value.Length).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError(">=", other, Type);
            }
        }

        public object Lt(object other)
        {
            if (other is ArrayObj a)
            {
                return new BoolObj((Value.Length < a.Value.Length).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError("<", other, Type);
            }
        }

        public object Lte(object other)
        {
            if (other is ArrayObj a)
            {
                return new BoolObj((Value.Length <= a.Value.Length).ToString());
            } else
            {
                return Helper.RaiseOperatorError("<=", other, Type);
            }
        }

        public object And(object other)
        {
            return Helper.RaiseOperatorError("&&", other, Type);
        }

        public object Or(object other)
        {
            return Helper.RaiseOperatorError("||", other, Type);
        }

        public object Not()
        {
            return new ArrayObj(Value.Reverse().ToArray());
        }

        public object Index(int i)
        {
            try
            {
                return Value[i];
            } catch (IndexOutOfRangeException)
            {
                return new Error("Index", $"Index out of range '{i}'");
            }
        }
    }
}
