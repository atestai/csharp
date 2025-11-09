namespace cSharpCourse.lib.Geometrics;

public class Circle(double radius) : GeometricShape
{
    private double _radius = radius;
    public double Radius {
        get => _radius;
        set => _radius = SetIfGood(value);
    }

    public Circle() : this(1.0)
    {
    }

    public override double Area()
    {
        return Math.PI * _radius * _radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * _radius;
    }
}
