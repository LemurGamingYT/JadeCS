using Jade.Lang;

namespace Jade.Objects
{
    public class FloatObj
    {
        public double Value;
        public string Type = "float";

        public FloatObj(string value)
        {
            Value = float.Parse(value);
        }

        public string Repr(object context)
        {
            return Value.ToString();
        }

        public object Add(object other)
        {
            if (other is IntObj i)
            {
                return new FloatObj((Value + i.Value).ToString());
            }
            else if (other is FloatObj f)
            {
                return new FloatObj((Value + f.Value).ToString());
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
                return new FloatObj((Value - i.Value).ToString());
            }
            else if (other is FloatObj f)
            {
                return new FloatObj((Value - f.Value).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError("-", other, Type);
            }
        }

        public object Mul(object other)
        {
            if (other is IntObj i)
            {
                return new FloatObj((Value * i.Value).ToString());
            }
            else if (other is FloatObj f)
            {
                return new FloatObj((Value * f.Value).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError("*", other, Type);
            }
        }

        public object Div(object other)
        {
            if (other is IntObj i)
            {
                return new FloatObj((Value / i.Value).ToString());
            }
            else if (other is FloatObj f)
            {
                return new FloatObj((Value / f.Value).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError("/", other, Type);
            }
        }

        public object Pow(object other)
        {
            if (other is IntObj i)
            {
                return new FloatObj(Math.Pow(Value, i.Value).ToString());
            }
            else if (other is FloatObj f)
            {
                return new FloatObj(Math.Pow(Value, f.Value).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError("**", other, Type);
            }
        }

        public object Mod(object other)
        {
            if (other is IntObj i)
            {
                return new FloatObj((Value % i.Value).ToString());
            }
            else if (other is FloatObj f)
            {
                return new FloatObj((Value % f.Value).ToString());
            }
            else
            {
                return Helper.RaiseOperatorError("%", other, Type);
            }
        }

        public object Eq(object other)
        {
            if (other is FloatObj f)
            {
                return new BoolObj((Value == f.Value).ToString());
            }
            else
            {
                return new BoolObj("false");
            }
        }

        public object Neq(object other)
        {
            if (other is FloatObj f)
            {
                return new BoolObj((Value != f.Value).ToString());
            }
            else
            {
                return new BoolObj("false");
            }
        }

        public object Gt(object other)
        {
            if (other is FloatObj f)
            {
                return new BoolObj((Value > f.Value).ToString());
            }
            else
            {
                return new BoolObj("false");
            }
        }

        public object Gte(object other)
        {
            if (other is FloatObj f)
            {
                return new BoolObj((Value >= f.Value).ToString());
            }
            else
            {
                return new BoolObj("false");
            }
        }

        public object Lt(object other)
        {
            if (other is FloatObj f)
            {
                return new BoolObj((Value < f.Value).ToString());
            }
            else
            {
                return new BoolObj("false");
            }
        }

        public object Lte(object other)
        {
            if (other is FloatObj f)
            {
                return new BoolObj((Value <= f.Value).ToString());
            }
            else
            {
                return new BoolObj("false");
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
            return Helper.RaiseNotOperatorError(Type);
        }

        public object Index(int _)
        {
            return Helper.RaiseIndexOperatorError(Type);
        }
    }
}
