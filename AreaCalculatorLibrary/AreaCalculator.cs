using AreaCalculatorLibrary.Abstractions;
using AreaCalculatorLibrary.Models;

namespace AreaCalculatorLibrary;
/// <summary>
/// <inheritdoc cref="IAreaCalculator"/>
/// </summary>
public class AreaCalculator : IAreaCalculator
{
    public double Calculate(IShape shape)
    {
        var result = shape.GetArea();

        return result;
    }

    public ICheckResult<double, string> CalculateWithCheck(
            IShape shape, Func<IShape, string>? checkLambda = null)
    {
        double area = shape.GetArea();
        string check = string.Empty;

        // I didn't understand how exactly triangle check has to be conducted so I decided to make it this way.
        // Now we can perform any checks on IShape objects when we call this method using lamda.
        // However, it would require type checking in the body (as in the demo) which is definitely not the best option
        // But that's how it is :)

        if (checkLambda is null)
        {
            return new CheckResult(area, check);
        }

        try
        {
            check = checkLambda.Invoke(shape);
        }
        catch(Exception ex)
        {
            Console.WriteLine(
                "{ExceptionName} occurred while trying to invoke a check lambda. Full message: {ExceptionMessage}" ,
                ex.GetType().Name,
                ex.Message);
        }

        var checkResult = new CheckResult(area, check);

        return checkResult;
    }
}