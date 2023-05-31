using AreaCalculatorLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculatorLibrary.Models;

public record Triangle (double A, double B, double C): IShape
{
    public bool isRightAngled()
    {
        double[] arr = { A, B, C };
        arr = arr.OrderDescending().ToArray();

        if (double.Pow(arr[0], 2d) == (double.Pow(arr[1], 2d) + double.Pow(arr[2], 2d)))
            return true;

        return false;
    }
    public double GetArea()
    {
        var p = (A + B + C)/2;

        var result =  Math.Sqrt(p * (p - A) * (p - B) * (p - C));

        return
            result is double.NaN
            ? 0
            : result;
    }
}
