using AreaCalculatorLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculatorLibrary.Models;

public record Rectangle (double A, double B): IShape
{
    public double GetArea()
    {
        return A * B;
    }
}
