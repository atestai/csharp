namespace cSharpCourse.lib.Geometrics;

public class Trapezoid(double base1, double base2, double heigth) : GeometricShape
{   
    private double _base1 = base1;
    public double Base1
    {
        get => _base1;
        set => _base1 = SetIfGood(value);
    }

    private double _base2 = base2;
    public double Base2
    {
        get => _base2;
        set => _base2 = SetIfGood(value);
    }

    private double _height = heigth;
    public double Heigth
    {
        get => _height;
        set => _height = SetIfGood(value);
    }

    public override double Area()
    {
        return (_base1 + _base2) * _height / 2;
    }

    public override double Perimeter()
    {
        return _base1 + _base1 + 2 * _height;
    }
}
