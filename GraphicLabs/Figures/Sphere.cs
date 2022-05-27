using GraphicLabs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Figures
{
    public class Sphere
    {
        public Point center { get; set; }
        public double radius { get; set; }

        public Sphere(Point center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public Vector GetNormal(Point point)
        {
            Vector normal = new Vector(center, point).Normalize();
            return normal;
        }

        public bool IsIntersects(Point origin, Vector ray)
        {
            var k = origin - center;

            var ray2 = ray * ray;
            var radius2 = radius * radius;
            var k2 = k * k;

            var a = ray2;
            var b = 2 * (ray * k);
            var c = k2 * radius2;

            var D = b * b - 4 * a * c;

            return D >= 0;
        }

        //(origin + scale*ray - center)^2 = radius^2
        //(scale*ray + (origin - center))^2 = radius^2
        //(scale*ray + k)^2 = radius^2
        //scale^2*ray^2 + 2*k*scale*ray + k^2 - radius^2 = 0

        public Point IntersectionPoint(Point origin, Vector ray)
        {
            var k = origin - center;

            var ray2 = ray * ray;
            var radius2 = radius * radius;
            var k2 = k * k;

            var a = ray2;
            var b = 2 * (ray * k);
            var c = k2 * radius2;

            var D = b * b - 4 * a * c;

            var scale = (-b - Math.Sqrt(D)) / (2 * a);

            double X = origin.X + scale * ray.X;
            double Y = origin.Y + scale * ray.Y;
            double Z = origin.Z + scale * ray.Z;

            return new Point(X, Y, Z);
        }
    }
}   
