using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

namespace AreaCalculatorLibrary.Abstractions;

public interface ICheckResult<TValue, TCheck>
{
    public TValue Value { get; }
    public TCheck Check { get; }

}