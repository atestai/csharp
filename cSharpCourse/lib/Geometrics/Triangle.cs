namespace cSharpCourse.lib.Geometrics;

public class Triangle(double sideA, double sideB, double sideC) : GeometricShape
{
    private static readonly double _angleSum = 180;
    public static double AngleSum => _angleSum;

    private double _sideA = sideA;
    public double SideA
    {
        get => _sideA;
        set => _sideA = SetIfGood(value);
    }

    private double _sideB = sideB;
    public double SideB
    {
        get => _sideB;
        set => _sideB = SetIfGood(value);
    }
    
    
    private double _sideC = sideC;
    public double SideC
    {
        get => _sideC;
        set => _sideC = SetIfGood(value);
    }

    public Triangle() : this(1, 1, 1)
    {
    }

    public Triangle(double sideA, double sideB) : this(sideA, sideB, 0)
    {
    }

    public override double Area()
    {
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public override double Perimeter()
    {
        return SideA + SideB + SideC;
    }
}
