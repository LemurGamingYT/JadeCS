using Jade.Lang;

namespace Jade.Objects
{
    public class NullObj
    {
        public string Value = "null";
        public string Type = "null";

        public string Repr(object context)
        {
            return Value;
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
            return Helper.RaiseOperatorError("==", other, Type);
        }

        public object Neq(object other)
        {
            return Helper.RaiseOperatorError("!=", other, Type);
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
