using AreaCalculatorLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculatorLibrary.Models;

public record Circle(double Radius) : IShape
{
    public double GetArea()
    {
        return double.Pi * Radius * Radius;
    }
}
