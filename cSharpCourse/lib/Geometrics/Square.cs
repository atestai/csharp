namespace cSharpCourse.lib.Geometrics;

public class Square(double side) : GeometricShape
{
    private double _side = side;

    public double Side { 
        get => _side;
        set => _side = SetIfGood(value);
    }

    public override double Area()
    {
        return _side * _side;
    }

    public override double Perimeter()
    {
        return 4 * _side;
    }
}
