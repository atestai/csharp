
namespace cSharpCourse.lib.Geometrics;

public class RectangleTriangle : Triangle
{
    public static double Cateto1
    {
        get;
        set;
    }

    public static double Cateto2
    {
        get;
        set;
    }

    public RectangleTriangle(double cateto1, double cateto2)
    {
        Cateto1 = cateto1;
        Cateto2 = cateto2;
    }

    public static double Hypotenuse
    {
        get
        {
            return Math.Sqrt(Math.Pow(Cateto1, 2) + Math.Pow(Cateto2, 2));
        }
    }

    public override double Area()
    {
        return (Cateto1 * Cateto2) / 2;
    }

    public override double Perimeter()
    {
        return Cateto1 + Cateto2 + Hypotenuse;
    }
}
