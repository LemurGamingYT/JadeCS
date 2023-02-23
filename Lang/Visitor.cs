using Antlr4.Runtime.Misc;
using Jade.Objects;


namespace Jade.Lang
{
    public class Visitor : JadeBaseVisitor<object>
    {
        public object GetValue([NotNull] JadeParser.AtomContext atom)
        {
            object evaluated = VisitAtom(atom);

            if (evaluated is IdObj r)
            {
                try
                {
                    evaluated = env.vars[r.Value].Value;
                }
                catch (KeyNotFoundException)
                {
                    return new Error("Name", $"Unknown object '{r.Value}'");
                }
            }

            return evaluated;
        }

        public object GetValue([NotNull] JadeParser.ExprContext expr)
        {
            object evaluated = VisitExpr(expr);

            if (evaluated is IdObj r)
            {
                try
                {
                    evaluated = env.vars[r.Value].Value;
                } catch (KeyNotFoundException)
                {
                    return new Error("Name", $"Unknown object '{r.Value}'");
                }
            }

            return evaluated;
        }

        public Env env;
        public Funcs funcs = new();
        public string VisitorName;

        public Dictionary<string, string> operators = new();

        public Visitor(Env env, string VisitorName)
        {
            this.env = env;
            this.VisitorName = VisitorName;

            operators.Add("+", "Add");
            operators.Add("-", "Sub");
            operators.Add("*", "Mul");
            operators.Add("/", "Div");
            operators.Add("**", "Pow");
            operators.Add("%", "Mod");
            operators.Add("==", "Eq");
            operators.Add("!=", "Neq");
            operators.Add("~=", "Neq");
            operators.Add(">", "Gt");
            operators.Add(">=", "Gte");
            operators.Add("<", "Lt");
            operators.Add("<=", "Lte");
            operators.Add("!", "Not");
            operators.Add("not", "Not");
            operators.Add("&&", "And");
            operators.Add("and", "And");
            operators.Add("||", "Or");
            operators.Add("or", "Or");
        }

        public override object VisitArgs([NotNull] JadeParser.ArgsContext context)
        {
            List<object> args = new();
            if (context != null)
            {
                args.AddRange(context.expr().Select(GetValue));
            }

            return args;
        }

        public override object VisitParams([NotNull] JadeParser.ParamsContext context)
        {
            List<string> @params = new();
            if (context != null)
            {
                @params.AddRange(context.ID().Select(id => id.ToString()));
            }

            return @params.ToArray();
        }

        public override object VisitVarAssign([NotNull] JadeParser.VarAssignContext context)
        {
            string name = context.ID().ToString();
            object value = GetValue(context.expr());

            bool constant = context.CONST() != null;
            if (!constant) constant = name.Equals(name.ToUpper());

            bool IsPublic = context.PUBLIC() != null;

            env.vars.Add(name, new VarObj(name, value, constant, IsPublic));

            return new NullObj();
        }

        public override object VisitFuncAssign([NotNull] JadeParser.FuncAssignContext context)
        {
            string name = context.ID().ToString();
            string[] @params = (string[]) VisitParams(context.@params());
            JadeParser.BlockContext block = context.block();
            bool IsPublic = context.PUBLIC() != null;
            bool _ = context.OVERRIDE() != null;

            env.funcs.Add(name, new FuncObj(name, @params, IsPublic, true, block));

            return new NullObj();
        }

        public override object VisitFuncExpr([NotNull] JadeParser.FuncExprContext context)
        {
            string name = context.ID().ToString();
            string[] @params = (string[])VisitParams(context.@params());
            JadeParser.BlockContext block = context.block();
            
            return new FuncObj(name, @params, false, true, block);
        }

        public override object VisitIndexing([NotNull] JadeParser.IndexingContext context)
        {
            object atom = GetValue(context.atom());
            return Helper.ReflectionMethodInvoke(atom, "Index", new object[] { int.Parse(context.INT().ToString()) });
        }

        public override object VisitGetAttributes([NotNull] JadeParser.GetAttributesContext context)
        {
            object atom = GetValue(context.atom());

            return Helper.ReflectionMethodInvoke(atom, context.ID(0).ToString(), new object[] { VisitArgs(context.args(0)) });
        }

        public override object VisitCall([NotNull] JadeParser.CallContext context)
        {
            string name = context.ID().ToString();
            List<object> args = (List<object>) VisitArgs(context.args());

            if (env.funcs.TryGetValue(name, out FuncObj value))
            {
                return value.Call(args, this);
            } else
            {
                return new Error("Name", $"Unknown function '{name}'");
            }
        }

        public override object VisitExpr([NotNull] JadeParser.ExprContext context)
        {
            if (context.atom() != null)
            {
                return VisitAtom(context.atom());
            }  else if (context.call() != null)
            {
                return VisitCall(context.call());
            } else if (context.getAttributes() != null)
            {
                return VisitGetAttributes(context.getAttributes());
            } else if (context.indexing() != null)
            {
                return VisitIndexing(context.indexing());
            } else if (context.expr().Length == 1 && context.op != null)
            {
                object obj = GetValue(context.expr(0));
                return Helper.ReflectionMethodInvoke(obj, "Not", Array.Empty<object>());
            } else if (context.expr().Length == 2 && context.op != null)
            {
                object obj1 = GetValue(context.expr(0));
                object obj2 = GetValue(context.expr(1));

                return Helper.ReflectionMethodInvoke(obj1, operators[context.op.Text], new object[] { obj2 });
            } else if (context.expr().Length == 1 && context.op == null)
            {
                return GetValue(context.expr(0));
            }
            else
            {
                return new NullObj();
            }
        }

        public override object VisitList([NotNull] JadeParser.ListContext context)
        {
            return new ArrayObj(((List<object>) VisitArgs(context.args())).ToArray());
        }

        public override object VisitAtom([NotNull] JadeParser.AtomContext context)
        {
            if (context.list() != null)
            {
                return VisitList(context.list());
            }

            string text = context.GetText();
            if (context.STRING() != null)
            {
                return new StringObj(text);
            }
            else if (context.ID() != null)
            {
                return new IdObj(text);
            }
            else if (context.BOOL() != null)
            {
                return new BoolObj(text);
            }
            else if (context.INT() != null)
            {
                return new IntObj(text);
            }
            else if (context.FLOAT() != null)
            {
                return new FloatObj(text);
            }
            else if (context.NUL() != null)
            {
                return new NullObj();
            }
            else
            {
                return new NullObj();
            }
        }
    }
}
