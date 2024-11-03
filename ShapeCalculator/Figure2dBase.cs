namespace ShapeCalculator;

/// <summary>
/// Represents two-dimensional figure.
/// </summary>
public abstract class Figure2dBase
{
    public abstract double GetArea();
    public int[] Sides { get; protected set; } = [];
    public object? Info { get; protected set; }
}