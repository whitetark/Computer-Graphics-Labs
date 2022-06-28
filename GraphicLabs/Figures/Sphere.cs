using GraphicLabs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Figures
{
    public class Sphere : Figure
    {
        private double MaxX;
        private double MaxY;
        private double MaxZ;
        private double MinX;
        private double MinY;
        private double MinZ;
        public Point Center { get; set; }
        public double Radius { get; set; }
        public Sphere(Point center, double radius)
        {
            Center = center;
            Radius = radius;
            MaxX = Center.X + Radius;
            MaxY = Center.Y + Radius;
            MaxZ = Center.Z + Radius;
            MinX = Center.X - Radius;
            MinY = Center.Y - Radius;
            MinZ = Center.Z - Radius;
        }

        public override Vector GetNormal(Point point)
        {
            Vector normal = new Vector(Center, point).Normalize();
            return normal;
        }

        public override bool IsIntersects(Ray ray)
        {
            var k = ray.Origin - Center;

            var a = Vector.Dot(ray.Direction, ray.Direction); ;
            var b = 2 * Vector.Dot(ray.Direction, k);
            var c = Vector.Dot(k, k) - (Radius * Radius);

            var D = b * b - 4 * a * c;

            if(D >= 0)
            {
                var scale = (-b - Math.Sqrt(D)) / (2 * a);
                return scale >= 0;
            };
            return false;
        }

        //(origin + scale*ray - center)^2 = radius^2
        //(scale*ray + (origin - center))^2 = radius^2
        //(scale*ray + k)^2 = radius^2
        //scale^2*ray^2 + 2*k*scale*ray + k^2 - radius^2 = 0

        public override Point IntersectionPoint(Ray ray)
        {
            var k = ray.Origin - Center;

            var a = Vector.Dot(ray.Direction, ray.Direction); ;
            var b = 2 * Vector.Dot(ray.Direction,k);
            var c = Vector.Dot(k, k) - (Radius * Radius);

            var D = b * b - 4 * a * c;

            var scale = (-b - Math.Sqrt(D)) / (2 * a);

            if(scale >= 0)
            {
                double X = ray.Origin.X + scale * ray.Direction.X;
                double Y = ray.Origin.Y + scale * ray.Direction.Y;
                double Z = ray.Origin.Z + scale * ray.Direction.Z;
                return new Point(X, Y, Z);
            }
            return null;
        }
        public override double GetMaxX()
        {
            return MaxX;
        }

        public override double GetMaxY()
        {
            return MaxY;
        }

        public override double GetMaxZ()
        {
            return MaxZ;
        }

        public override double GetMinX()
        {
            return MinX;
        }

        public override double GetMinY()
        {
            return MinY;
        }

        public override double GetMinZ()
        {
            return MinZ;
        }
        
        public override Point GetCenter()
        {
            return Center;
        }
    }
}   
