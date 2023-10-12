using System;

public static class GeometryCalculator
{
    public static double CalculateCircleArea(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("раадиус должен быть положительным числом.");
        return Math.PI * Math.Pow(radius, 2);
    }

    public static double CalculateTriangleArea(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("длины сторон треугольника должны быть положительными числами.");
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("треугольник с такими сторонами не существует.");
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public static bool IsRightTriangle(double a, double b, double c)
    {
        var sides = new double[] { a, b, c };
        Array.Sort(sides);
        return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
    }
}

