using Jade.Lang;

namespace Jade.Objects
{
    public class StringObj
    {
        public string Value;
        public string Type = "string";

        public StringObj(string value)
        {
            Value = value[1..^1];
        }

        public string Repr(object context)
        {
            if (context is ArrayObj)
            {
                return "'" + Value + "'";
            }

            return Value;
        }

        public StringObj Lower(List<object> args)
        {
            return new StringObj(Value.ToLower());
        }

        public StringObj Upper(List<object> args)
        {
            return new StringObj(Value.ToUpper());
        }

        public object Add(object other)
        {
            if (other is StringObj s)
            {
                return new StringObj("\"" + Value + s.Value + "\"");
            } else
            {
                return Helper.RaiseOperatorError("+", other, Type);
            }
        }

        public object Sub(object other)
        {
            if (other is StringObj s)
            {
                return new StringObj("\"" + Value[0..^s.Value.Length] + "\"");
            } else if (other is IntObj i)
            {
                return new StringObj("\"" + Value[0..^(int)i.Value] + "\"");
            } else
            {
                return Helper.RaiseOperatorError("-", other, Type);
            }
        }

        public object Mul(object other)
        {
            if (other is IntObj i)
            {
                return new StringObj("\"" + string.Concat(Enumerable.Repeat(Value, (int)i.Value)) + "\"");
            } else
            {
                return Helper.RaiseOperatorError("*", other, Type);
            }
        }

        public object Div(object other)
        {
            return Helper.RaiseOperatorError("/", other, Type);
        }

        public object Pow(object other)
        {
            if (other is IntObj i)
            {
                return new StringObj("\"" + string.Concat(Enumerable.Repeat(Value, (int)i.Value)) + "\"");
            } else
            {
                return Helper.RaiseOperatorError("**", other, Type);
            }
        }

        public object Mod(object other)
        {
            if (other is IntObj i)
            {
                return new StringObj("\"" + string.Concat(Enumerable.Repeat(Value, (int)i.Value)) + "\"");
            } else if (other is StringObj s)
            {
                return new StringObj("\"" + Value[1..^s.Value.Length] + "\"");
            } else
            {
                return Helper.RaiseOperatorError("%", other, Type);
            }
        }

        public object Eq(object other)
        {
            if (other is StringObj s)
            {
                return new BoolObj((Value == s.Value).ToString().ToLower());
            } else
            {
                return new BoolObj("false");
            }
        }

        public object Neq(object other)
        {
            if (other is StringObj s)
            {
                return new BoolObj((Value != s.Value).ToString().ToLower());
            } else
            {
                return new BoolObj("false");
            }
        }

        public object Gt(object other)
        {
            if (other is StringObj s)
            {
                return new BoolObj((Value.Length > s.Value.Length).ToString().ToLower());
            } else
            {
                return new BoolObj("false");
            }
        }

        public object Gte(object other)
        {
            if (other is StringObj s)
            {
                return new BoolObj((Value.Length >= s.Value.Length).ToString().ToLower());
            } else
            {
                return new BoolObj("false");
            }
        }
        
        public object Lt(object other)
        {
            if (other is StringObj s)
            {
                return new BoolObj((Value.Length < s.Value.Length).ToString().ToLower());
            } else
            {
                return new BoolObj("false");
            }
        }

        public object Lte(object other)
        {
            if (other is StringObj s)
            {
                return new BoolObj((Value.Length <= s.Value.Length).ToString().ToLower());
            } else
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
            return new StringObj("\"" + new string(Value.Reverse().ToArray()) + "\"");
        }

        public object Index(int IntValue)
        {
            return new StringObj(Value[IntValue].ToString());
        }
    }
}
