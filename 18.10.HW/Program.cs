using System;
using System.Linq;

public static class Extensions
{
    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }

    public static bool IsOdd(this int number)
    {
        return number % 2 != 0;
    }

    public static Person FindMinAgePerson(this Person[] people)
    {
        return people.OrderBy(p => p.Age).FirstOrDefault();
    }

    public static Person FindMaxAgePerson(this Person[] people)
    {
        return people.OrderByDescending(p => p.Age).FirstOrDefault();
    }

    public static double AverageAge(this Person[] people)
    {
        return people.Average(p => p.Age);
    }

    public static double DistanceTo(this Point3D point1, Point3D point2)
    {
        double deltaX = point1.X - point2.X;
        double deltaY = point1.Y - point2.Y;
        double deltaZ = point1.Z - point2.Z;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
    }

    public static Point3D FindFurthestPoint(this Point3D[] points)
    {
        Point3D furthestPoint = null;
        double maxDistance = 0;

        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                double distance = points[i].DistanceTo(points[j]);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    furthestPoint = points[i];
                }
            }
        }

        return furthestPoint;
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public class Point3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        // Приклад використання методів розширення

        int number = 10;
        bool isEven = number.IsEven();
        bool isOdd = number.IsOdd();
        Console.WriteLine($"Is {number} even? {isEven}"); // Повинно вивести true
        Console.WriteLine($"Is {number} odd? {isOdd}");   // Повинно вивести false

        Person[] people = new Person[]
        {
            new Person { FirstName = "John", LastName = "Doe", Age = 30 },
            new Person { FirstName = "Alice", LastName = "Smith", Age = 25 },
            new Person { FirstName = "Bob", LastName = "Johnson", Age = 35 }
        };

        var minAgePerson = people.FindMinAgePerson();
        var maxAgePerson = people.FindMaxAgePerson();
        var averageAge = people.AverageAge();

        Console.WriteLine($"Person with min age: {minAgePerson.FirstName} {minAgePerson.LastName}, Age: {minAgePerson.Age}");
        Console.WriteLine($"Person with max age: {maxAgePerson.FirstName} {maxAgePerson.LastName}, Age: {maxAgePerson.Age}");
        Console.WriteLine($"Average age: {averageAge}");

        Point3D[] points = new Point3D[]
        {
            new Point3D { X = 1, Y = 2, Z = 3 },
            new Point3D { X = 4, Y = 5, Z = 6 },
            new Point3D { X = 7, Y = 8, Z = 9 }
        };

        var furthestPoint = points.FindFurthestPoint();
        Console.WriteLine($"Point with max distance: X = {furthestPoint.X}, Y = {furthestPoint.Y}, Z = {furthestPoint.Z}");
    }
}