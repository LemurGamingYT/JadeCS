namespace Jade.Objects
{
    public class VarObj
    {
        public string Name;
        public object Value;
        public bool Constant;
        public bool IsPublic;

        public VarObj(string name, object value, bool constant, bool isPublic)
        {
            Name = name;
            Value = value;
            Constant = constant;
            IsPublic = isPublic;
        }

        public string Repr(object context)
        {
            return $"Variable({Name}, {Value}, {Constant}, {IsPublic})";
        }
    }
}
