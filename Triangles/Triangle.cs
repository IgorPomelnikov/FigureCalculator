using ShapeCalculator;

namespace Triangles;

/// <summary>
/// Represents a simple triangle and provides methods to calculate its area and determine its type.
/// </summary>
public sealed class SimpleTriangle : Figure2dBase
{
    private const string RightAngled = "right-angled triangle";
    private const string Obtuse = "obtuse-angled triangle";
    private const string Acute = "acute-angled triangle";
    private const string ZeroExceptionMessage = "All sides of triangle must be greater than 0";
    private const string ExceptionMessage = "Cannot create triangle from values ({0}, {1}, {2})";

    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleTriangle"/> class with the specified side lengths.
    /// </summary>
    /// <param name="a">The length of the first side of the triangle.</param>
    /// <param name="b">The length of the second side of the triangle.</param>
    /// <param name="c">The length of the third side of the triangle.</param>
    /// <exception cref="ArgumentException">Thrown when any side length is less than or equal to zero.</exception>
    public SimpleTriangle(int a, int b, int c)
    {
        if ((a + b > c) && (a + c > b) && (b + c > a))
        {
            Sides = [a, b, c];
            if (Sides.Any(x => x < 1))
                throw new ArgumentException(ZeroExceptionMessage);
            SetDescription();
        }
        else
        {
            throw new ArgumentException(string.Format(ExceptionMessage, a, b, c));
        }
    }

    /// <summary>
    /// Calculates the area of the triangle using Heron's formula.
    /// </summary>
    /// <returns>The area of the triangle as a double.</returns>
    public override double GetArea()
    {
        var perimeter = Sides.Sum() / 2;
        var area = Math.Sqrt(perimeter * (perimeter - Sides[0]) * (perimeter - Sides[1]) * (perimeter - Sides[2]));
        return area;
    }

    /// <summary>
    /// Sets the description of the triangle based on its angles (right-angled, obtuse-angled, or acute-angled).
    /// </summary>
    private void SetDescription()
    {
        var max = Math.Max(Sides[0], Math.Max(Sides[1], Sides[2]));
        var sumOfShorts = 0;
        for (var i = 0; i < Sides.Length - 1; i++)
        {
            if (Sides[i] == max)
                max *= max;
            else
            {
                sumOfShorts += Sides[i] * Sides[i];
            }
        }
        
        if (max == sumOfShorts)
            Info = RightAngled;
        else if (max > sumOfShorts)
            Info = Obtuse;
        else 
            Info = Acute;
    }
}
