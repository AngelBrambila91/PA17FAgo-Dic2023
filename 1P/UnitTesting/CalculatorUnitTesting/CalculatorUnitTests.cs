namespace CalculatorUnitTesting;
using CalculatorLib;

public class CalculatorUnitTests
{
    [Fact]// Annotation
    public void TestAdd2And2()
    {
        //arrange
        double a = 2;
        double b = 2;
        double expected = 4;
        Calculator calc = new();
        // act
        double actual = calc.Add(a , b);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]// Annotation
    public void TestAdd2And3()
    {
        //arrange
        double a = 2;
        double b = 3;
        double expected = 5;
        Calculator calc = new();
        // act
        double actual = calc.Add(a , b);
        // Assert
        Assert.Equal(expected, actual);
    }
}