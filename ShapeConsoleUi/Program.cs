using ShapeCalculator;

Console.WriteLine("Welcome to the Shape Calculator Console Ui.\n");

var triangleArea = Calculator.CalculateAreaFor("Triangles.SimpleTriangle",
    @"..\..\..\Figures\net8.0\Triangles.dll", [3,66,5]);
Console.WriteLine($"Calculated area for triangle is {triangleArea}");


var circleArea = Calculator.CalculateAreaFor("Circles.SimpleCircle",
    @"..\..\..\Figures\net8.0\Circles.dll", [3]);
Console.WriteLine($"Calculated area for circle is {circleArea}");