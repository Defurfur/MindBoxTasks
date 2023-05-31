using AreaCalculatorLibrary;
using AreaCalculatorLibrary.Models;

namespace UnitTests;

public class AreaCalculatorTests
{
    AreaCalculator _calculator = new();
    [Fact]
    public void Calculate_Returns_CorrectValue_With_CircleShape()
    {
        //ARRANGE
        Circle circle = new(10);
        //ACT

        var result = _calculator.Calculate(circle);
        //ASSERT

        Assert.Equal(314, result, 1d);
    }
    [Fact]
    public void CalculateWithCheck_With_DefaultCheckLamda_Returns_CorrectObject()
    {
        //ARRANGE
        var triangle = new Triangle(3, 4, 5);
        //ACT
        var result = _calculator.CalculateWithCheck(triangle);
        //ASSERT
        Assert.Equal(6d, result.Value);
        Assert.Empty(result.Check);
    }
    
    [Fact]
    public void CalculateWithCheck_Returns_CorrectObject()
    {
        //ARRANGE
        var triangle = new Triangle(3, 4, 5);
        //ACT
        var result = _calculator.CalculateWithCheck(triangle, (shape) => {
            if (shape is Triangle tr)
                return tr.isRightAngled().ToString();

            return string.Empty;
        }
            
        );
        //ASSERT
        Assert.Equal(6d, result.Value);
        Assert.Equal("True", result.Check);
    }
}