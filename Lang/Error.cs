using Antlr4.Runtime;

namespace Jade.Lang
{
    public class Error
    {
        public Error(string ErrorType, string Msg)
        {
            Console.WriteLine($"{ErrorType}Error: {Msg}");
            Console.ReadLine();
            Environment.Exit(1);
        }

        public class ErrorListener : BaseErrorListener
        {
            public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                Console.WriteLine(msg);
                _ = new Error("Syntax", $"Unexpected '{offendingSymbol.Text}' at ln {line}, column {charPositionInLine}");
            }
        }
    }
}
