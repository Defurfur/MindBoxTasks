using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculatorLibrary.Abstractions;
/// <summary>
/// Service that can calculate area of a geometric figure. The figure must implement <typeparamref name="IShape"/> interface.
/// </summary>
public interface IAreaCalculator
{
    /// <summary>
    /// Calculates an area of a given <paramref name="shape"/>
    /// </summary>
    /// <param name="shape"></param>
    /// <returns></returns>
    double Calculate(IShape shape);
    /// <summary>
    /// Calculates an area of a given <paramref name="shape"/> and then invokes <paramref name="checkLambda"/>.
    /// Returns an <typeparamref name="ICheckResult"/> object which Value property
    /// is the calculated area and Check property is the result of <paramref name="checkLambda"/> execution.
    /// </summary>
    /// <typeparam cref="ICheckResult{TValue, TCheck}"></typeparam>
    /// <param name="shape"></param>
    /// <param name="checkLambda"></param>
    /// <returns></returns>
    ICheckResult<double, string> CalculateWithCheck(
        IShape shape,
        Func<IShape, string>? checkLambda = null);
}
