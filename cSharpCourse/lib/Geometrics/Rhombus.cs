namespace cSharpCourse.lib.Geometrics;

public class Rhombus(double diagonal1, double diagonal2) : GeometricShape
{
    private double _diagonal1 = diagonal1;
    public double Diagonal1
    {
        get => _diagonal1;
        set => _diagonal1 = SetIfGood(value);
    }
    private double _diagonal2 = diagonal2;
    public double Diagonal2
    {
        get => _diagonal2;
        set => _diagonal2 = SetIfGood(value);
    }
    public double Side { get; private set; }
    
    public override double Area()
    {
        return _diagonal1 * _diagonal2 / 2;
    }

    public override double Perimeter()
    {
        Side = Math.Sqrt(Math.Pow(_diagonal1 / 2, 2) + Math.Pow(_diagonal1 / 2, 2));
        return 4 * Side;
    }
}
