namespace cSharpCourse.lib.Geometrics;

public enum ShapeCompareResult
{
    FirstIsBigger = 1,
    SecondIsBigger = -1,
    Equal = 0
}

public interface IGeometricShape
{
    double Area();
    void Display();
    double SemiPerimeter() => Perimeter() / 2;
    double Perimeter();

}

public abstract class GeometricShape : IGeometricShape
{
    public abstract double Area();

    public abstract double Perimeter();

    public void Display() => Console.WriteLine($"Area: {Area()}, Perimeter: {Perimeter()}");

    protected static double SetIfGood(double value) => (value <= 0) ?
        throw new ArgumentException("Side length must be greater than zero.") :
        value;

    public static ShapeCompareResult CompareByArea(IGeometricShape shape1, IGeometricShape shape2) => (ShapeCompareResult) shape1.Area().CompareTo(shape2.Area());
    public static ShapeCompareResult CompareByPerimeter(IGeometricShape shape1, IGeometricShape shape2) => (ShapeCompareResult) shape1.Perimeter().CompareTo(shape2.Perimeter());

}
