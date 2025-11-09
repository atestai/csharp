using System.Net.Http.Headers;

namespace cSharpCourse.lib.Geometrics;

public class Rectangle(double width, double height) : GeometricShape
{
    private double _width = width;
    private double _height = height;

    public double Width
    {
        get => _width;
        set => _width = SetIfGood(value);
    }
    
    public double Height
    {
        get => _height;
        set => _height = SetIfGood(value);
    }

    
    

    public override double Area()
    {
        return Width * Height;
    }

    public override double Perimeter()
    {
        return 2 * (Width + Height);
    }
}
