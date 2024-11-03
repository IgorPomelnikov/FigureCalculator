using System.Reflection;

namespace ShapeCalculator;

public class Calculator
{
    /// <summary>
    /// Calculates the area of a shape specified by its type and sides.
    /// </summary>
    /// <param name="typeOfShape">The fully qualified name of the shape type to be instantiated.</param>
    /// <param name="assemblyPath">The path to the assembly where the shape type is defined.</param>
    /// <param name="sidesOfFigure">An array of integers representing the lengths of the sides of the figure.</param>
    /// <returns>The area of the specified shape as a double.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="typeOfShape"/> or <paramref name="assemblyPath"/> is null or empty, or when <paramref name="sidesOfFigure"/> has no elements.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the specified type cannot be found in the assembly, when a suitable constructor cannot be found, or when the created object does not derive from <see cref="Figure2dBase"/>.</exception>
    public static double CalculateAreaFor(string typeOfShape, string assemblyPath, int[] sidesOfFigure)
    {
        ArgumentException.ThrowIfNullOrEmpty(typeOfShape, nameof(typeOfShape));
        ArgumentException.ThrowIfNullOrEmpty(assemblyPath, nameof(assemblyPath));
        if(sidesOfFigure.Length < 1)
            throw new ArgumentException("At least one side of figure is required.");

        
        var argsTypes = new Type[sidesOfFigure.Length];
        var args = new object[sidesOfFigure.Length];
        var typeOfLines = sidesOfFigure[0].GetType();
        for (var i = 0; i < argsTypes.Length; i++)
        {
            argsTypes[i] = typeOfLines;
            args[i] = sidesOfFigure[i];
        }
        
        var assembly = Assembly.LoadFrom(assemblyPath);
        var type = assembly.GetType(typeOfShape);
        if (type is null)
            throw new InvalidOperationException($"Cannot find type {typeOfShape} in assembly {assemblyPath}");

        var ctor = type.GetConstructor(argsTypes);
        if(ctor is null)
            throw new InvalidOperationException($"Cannot find constructor for type {typeOfShape} in assembly {assemblyPath}");
        var obj = ctor.Invoke(BindingFlags.Public | BindingFlags.CreateInstance , null, args,null);

        if (obj is Figure2dBase figure2dBase)
        {
            return figure2dBase.GetArea();
        }
        else
        {
            throw new InvalidOperationException($"Type {typeOfShape} doesn't derive from Figure2dBase type.");
        }
    }
}