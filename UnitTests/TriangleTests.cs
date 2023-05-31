using AreaCalculatorLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests;

public class RightAngledTriangleTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 3, 4, 5, true };
        yield return new object[] { 8, 8, 7, false};
        yield return new object[] { 6, 8, 10, true};
        yield return new object[] { 1, 8, 10, false};
        yield return new object[] { 7, 24, 25, true};
        yield return new object[] { 93, 80, 100, false};
        yield return new object[] { 1, 6, 15, false};

    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class TriangleTests
{
    [Theory]
    [ClassData(typeof(RightAngledTriangleTestData))]
    public void isRightAngled_Returns_CorrectValue(double A, double B, double C, bool result)
    {
        //ARRANGE
        var triangle = new Triangle(A, B, C);

        //ACT
        //ASSERT

        Assert.Equal(result, triangle.isRightAngled());

    }
    [Theory]
    [InlineData(8, 3, 5)]
    [InlineData(5, 5, 10)]
    [InlineData(16, 18, 1)]
    [InlineData(10, 10, 21)]
    public void TriangleArea_EqualsZero_If_It_Cant_Exist(double A, double B, double C)
    {
        //ARRANGE
        var triangle = new Triangle(A, B, C);

        //ACT
        //ASSERT

        Assert.Equal(0, triangle.GetArea());
    }
}
