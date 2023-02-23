using System.Diagnostics;
using Antlr4.Runtime;
using Jade.Lang;

Stopwatch watch = Stopwatch.StartNew();

AntlrFileStream stream = new("examples/test.jd");
/*
try
{
    stream = new(args[0]);
} catch (IndexOutOfRangeException)
{
    new Error("Name", $"Cannot open file '{args[0]}'");
}*/

JadeLexer lexer = new(stream);
CommonTokenStream tokens = new(lexer);

JadeParser parser = new(tokens);
parser.RemoveErrorListeners();
parser.AddErrorListener(new Error.ErrorListener());
JadeParser.ParseContext tree = parser.parse();

Env env = new();

Visitor visitor = new(env, "Main");
visitor.Visit(tree);

watch.Stop();

Console.WriteLine($"Time taken to execute: {watch.Elapsed}");
Console.ReadLine();
