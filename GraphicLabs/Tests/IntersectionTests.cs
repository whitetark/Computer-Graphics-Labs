using GraphicLabs.Basic;
using GraphicLabs.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Tests
{
    public class IntersectionTests
    {
        /*
        When True - IntersectionTests.PlaneTest(new Vector(new Point(2, 3, 3), new Point(2, 2, 3)), new Point(2, 3, 3), new Ray(new Point(1, 0, 1), new Point(1, 2, 2)));
        When False - IntersectionTests.PlaneTest(new Vector(new Point(2, 3, 3), new Point(2, 2, 3)), new Point(2, 3, 3), new Ray(new Point(1, 0, 1), new Point(1, 0, 2)));
         */
        public static void PlaneTest(Vector normal, Point planeCenter, Ray ray)
        {
            Plane plane = new Plane(normal, planeCenter);
            var truth = plane.IsIntersects(ray);
            Console.WriteLine(truth);
            if (truth)
            {
                var point = plane.IntersectionPoint(ray);
                Console.WriteLine(point.ToString());
            }
        }
        /*
        When True - IntersectionTests.SphereTest(new Point(3, 2, 2), 1, new Ray(new Point(1, 0, 1), new Point(1.5, 0.5, 1.5)));
        When False - IntersectionTests.SphereTest(new Point(3, 2, 2), 1, new Ray(new Point(1, 0, 1), new Point(1.5, 0.3, 1.5)));
         */
        public static void SphereTest(Point sphereCenter, double sphereRadius, Ray ray)
        {
            Sphere sphere = new Sphere(sphereCenter, sphereRadius);
            var truth = sphere.IsIntersects(ray);
            Console.WriteLine(truth);
            if (truth)
            {
                var point = sphere.IntersectionPoint(ray);
                Console.WriteLine(point.ToString());
            }
        }
        /*
        When True - IntersectionTests.TriangleTest(new Point(1, 0, 0), new Point(0, 1, 0), new Point(0, 0, 1), new Ray(new Point(5, 0.5, 3), new Point(4, 0.5, 2.4)));
        When False - IntersectionTests.TriangleTest(new Point(1, 0, 0), new Point(0, 1, 0), new Point(0, 0, 1), new Ray(new Point(5, 0.5, 3), new Point(4, 0.5, 2.3)));
         */
        public static void TriangleTest(Point A, Point B, Point C, Ray ray)
        {
            Triangle triangle = new Triangle(A,B,C);
            var truth = triangle.IsIntersects(ray);
            Console.WriteLine(truth);
            if (truth)
            {
                var point = triangle.IntersectionPoint(ray);
                Console.WriteLine(point.ToString());
            }
        }
    }
}
