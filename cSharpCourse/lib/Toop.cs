using cSharpCourse.lib.Geometrics;

namespace cSharpCourse.lib;

public static class Toop
{
    public static void Test()
    {
        // var rectangle = new Rectangle(5, 10);
        // rectangle.Display();

        // var circle = new Circle(7);
        // circle.Display();

        // var triangle = new Triangle(3, 4, 5);
        // triangle.Display();

        // var defaultTriangle = new Triangle();
        // Console.WriteLine($"Default Triangle sides: {defaultTriangle.SideA}, {defaultTriangle.SideB}, {defaultTriangle.SideC}");
        // defaultTriangle.Display();

        // var defaultTriangle2 = new Triangle(3);
        // Console.WriteLine($"Default Triangle sides: {defaultTriangle2.SideA}, {defaultTriangle2.SideB}, {defaultTriangle2.SideC}");
        // defaultTriangle2.Display();

        var listTriangle = new List<Triangle>(
        [
            new Triangle(3, 4, 5),
            new Triangle(6, 8, 10),
            new Triangle(),
            new Triangle(1, 1, 1),
            new Triangle()
        ]);

        // listTriangle.ForEach(t =>
        // {
        //     Console.WriteLine($"Triangle sides: {t.SideA}, {t.SideB}, {t.SideC}");
        //     t.Display();
        // });

        // listTriangle.Sort((t1, t2) => t1.Area().CompareTo(t2.Area()));

        var l = listTriangle.Select(t => t.SideA).Where( t => t > 4) .ToList();
        l.ForEach(sideA => Console.WriteLine($"Triangle SideA: {sideA}"));


        var l2 = listTriangle
            .Where(t => t.Area() > 6)
            .Select(t => new { t.SideA, t.SideB, t.SideC, Area = t.Area() })
            .ToList();        
            
        l2.ForEach(t => Console.WriteLine($"Triangle sides: {t.SideA}, {t.SideB}, {t.SideC}, Area: {t.Area}"));

        var square = new Square(6);
        square.Display();

        var rhombus = new Rhombus(5, 6);
        rhombus.Display();

        var square2 = new Square(6);
        square2.Display();

        Console.WriteLine(GeometricShape.CompareByArea(square, rhombus));
        Console.WriteLine(GeometricShape.CompareByArea(rhombus, square));
        Console.WriteLine(GeometricShape.CompareByArea(square, square2));


        //Console.WriteLine(GeometricShape.CompareByPerimeter(square, rhombus));

    }
}
