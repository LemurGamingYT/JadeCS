using Jade.Lang;

namespace Jade.Objects
{
    public class BoolObj
    {
        public bool Value;
        public string Type = "bool";

        public BoolObj(string value)
        {
            Value = bool.Parse(value);
        }

        public string Repr(object context)
        {
            return Value.ToString().ToLower();
        }

        public object Add(object other)
        {
            return Helper.RaiseOperatorError("+", other, Type);
        }

        public object Sub(object other)
        {
            return Helper.RaiseOperatorError("-", other, Type);
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
            if (other is BoolObj b)
            {
                return new BoolObj((Value == b.Value).ToString());
            } else
            {
                return new BoolObj("false");
            }
        }

        public object Neq(object other)
        {
            if (other is BoolObj b)
            {
                return new BoolObj((Value != b.Value).ToString());
            }
            else
            {
                return new BoolObj("false");
            }
        }

        public object Gt(object other)
        {
            return Helper.RaiseOperatorError(">", other, Type);
        }

        public object Gte(object other)
        {
            return Helper.RaiseOperatorError(">=", other, Type);
        }

        public object Lt(object other)
        {
            return Helper.RaiseOperatorError("<", other, Type);
        }

        public object Lte(object other)
        {
            return Helper.RaiseOperatorError("<=", other, Type);
        }

        public object And(object other)
        {
            if (other is BoolObj b)
            {
                return new BoolObj((Value && b.Value).ToString());
            } else
            {
                return new BoolObj("false");
            }
        }

        public object Or(object other)
        {
            if (other is BoolObj b)
            {
                return new BoolObj((Value || b.Value).ToString());
            } else
            {
                return new BoolObj("false");
            }
        }

        public object Not()
        {
            return new BoolObj((!Value).ToString());
        }

        public object Index(int _)
        {
            return Helper.RaiseIndexOperatorError(Type);
        }
    }
}
