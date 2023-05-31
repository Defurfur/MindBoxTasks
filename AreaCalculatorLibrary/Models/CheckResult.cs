using AreaCalculatorLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculatorLibrary.Models;

public class CheckResult : ICheckResult<double, string>
{
    public double Value { get; private set; }

    public string Check { get; private set; }


    public CheckResult(double value, string check)
    {
        Value = value;
        Check = check;
    }

 
}
