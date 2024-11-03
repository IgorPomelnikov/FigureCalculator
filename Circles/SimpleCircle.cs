using ShapeCalculator;

namespace Circles;

/// <summary>
/// Represents a simple circle and provides a method to calculate its area.
/// </summary>
public sealed class SimpleCircle : Figure2dBase
{
    /// <summary>
    /// Gets the radius of the circle.
    /// </summary>
    public int Radius { get; private set; }

    private const string Description = "Regular circle";

    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleCircle"/> class with the specified radius.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    public SimpleCircle(int radius)
    {
        Radius = radius;
        Info = Description;
    }

    /// <summary>
    /// Calculates the area of the circle using the formula π * r².
    /// </summary>
    /// <returns>The area of the circle as a double.</returns>
    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
