namespace Patterns.Behavior;

// ======================================================================
// PATRÓN INTERPRETER (Intérprete)
// ======================================================================
// Define una representación gramatical para un lenguaje y un intérprete
// que utiliza la representación para interpretar sentencias del lenguaje.

/// <summary>
/// Interfaz de Expresión - Define la operación de interpretación
/// </summary>
public interface IExpresion
{
    public int Interpret();
}

/// <summary>
/// Expresión terminal - Números
/// </summary>
public class NumericExpression : IExpresion
{
    public int _number;

    public NumericExpression(int number)
    {
        _number = number;
    }

    public NumericExpression(string number)
    {
        _number = int.Parse(number);
    }

    public int Interpret()
    {
        return _number;
    }
}

/// <summary>
/// Expresión no terminal - Suma
/// </summary>
public class AdditionExpression : IExpresion
{
    private IExpresion _firstExpression, _secondExpression;

    public AdditionExpression(IExpresion firstExpression, IExpresion secondExpression)
    {
        _firstExpression = firstExpression;
        _secondExpression = secondExpression;
    }

    public int Interpret()
    {
        return _firstExpression.Interpret() + _secondExpression.Interpret();
    }

    public override string ToString() => "+";
}

/// <summary>
/// Expresión no terminal - Resta
/// </summary>
public class SubstractionExpression : IExpresion
{
    private IExpresion _firstExpression, _secondExpression;

    public SubstractionExpression(IExpresion firstExpression, IExpresion secondExpression)
    {
        _firstExpression = firstExpression;
        _secondExpression = secondExpression;
    }

    public int Interpret()
    {
        return _firstExpression.Interpret() - _secondExpression.Interpret();
    }

    public override string ToString() => "-";
}

/// <summary>
/// Expresión no terminal - Multiplicación
/// </summary>
public class MultiplicationExpression : IExpresion
{
    private IExpresion _firstExpression, _secondExpression;

    public MultiplicationExpression(IExpresion firstExpression, IExpresion secondExpression)
    {
        _firstExpression = firstExpression;
        _secondExpression = secondExpression;
    }

    public int Interpret()
    {
        return _firstExpression.Interpret() * _secondExpression.Interpret();
    }

    public override string ToString() => "*";
}

/// <summary>
/// Parser de expresiones - Convierte notación postfija a árbol de expresiones
/// </summary>
public class ExpressionParser
{
    /// <summary>
    /// Verifica si el símbolo es un operador
    /// </summary>
    private static bool IsOperator(string input) => input.Equals("+") || input.Equals("-") || input.Equals("*");

    /// <summary>
    /// Factory method para crear expresiones según el operador
    /// </summary>
    private static IExpresion GetExpresionObject(IExpresion firstExpresion, IExpresion secondExpression, string symbol)
    {
        if (symbol.Equals("+"))
            return new AdditionExpression(firstExpresion, secondExpression);
        else if (symbol.Equals("-"))
            return new SubstractionExpression(firstExpresion, secondExpression);
        else
            return new MultiplicationExpression(firstExpresion, secondExpression);
    }

    Stack<IExpresion> stack = new Stack<IExpresion>();

    /// <summary>
    /// Parsea una expresión en notación postfija y la evalúa
    /// </summary>
    public int Parse(string input)
    {
        var tokenList = input.Split(' ');
        foreach (string symbol in tokenList)
        {
            if (!IsOperator(symbol))
            {
                // Es un número - expresión terminal
                IExpresion numberExpression = new NumericExpression(symbol);
                stack.Push(numberExpression);
            }
            else if (IsOperator(symbol))
            {
                // Es un operador - expresión no terminal
                IExpresion firstExpression = stack.Pop();
                IExpresion secondExpression = stack.Pop();
                IExpresion expressionObject = GetExpresionObject(firstExpression, secondExpression, symbol);
                var resultExpression = new NumericExpression(expressionObject.Interpret());
                stack.Push(resultExpression);
            }
        }
        return stack.Pop().Interpret();
    }
}