using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;

namespace GraphicLabs.Figures
{
    public class Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Vector GetNormal()
        {
            Vector Vector1 = B - A;
            Vector Vector2 = C - A;
            return Vector.Cross(Vector1,Vector2).Normalize();
        }

        public bool IsIntersects(Point origin, Vector ray)
        {
            //Find vectors for two edges
            Vector Edge1 = B - A;
            Vector Edge2 = C - A;

            //Calculating determinant
            Vector p = Vector.Cross(ray, Edge2);
            double Det = Edge1 * p;

            //If determinant is near zero, ray lies in plane of triangle otherwise not
            if (Det > -(double.Epsilon)&& Det < double.Epsilon)
            {
                return false;
            }
            double invDet = 1.0f / Det;

            //Calculate distance from A to ray origin
            Vector k = origin - A;

            double u = k * p * invDet;
            //Check for ray hit
            if (u < 0 || u > 1)
            { 
                return false; 
            }

            Vector q = Vector.Cross(k, Edge1);

            double v = ray * q * invDet;
            //Check for ray hit
            if (v < 0 || u + v > 1) { return false; }

            if ((Edge2 * q * invDet) > double.Epsilon)
            {
                return true;
            }

            return false;
        }

        public Point IntersectionPoint(Point origin, Vector ray)
        {
            Vector Edge1 = B - A;
            Vector Edge2 = C - A;

            Vector p = Vector.Cross(ray, Edge2);
            double Det = Edge1 * p;
            double invDet = 1.0f / Det;

            //Calculate distance from A to ray origin
            Vector k = origin - A;

            Vector q = Vector.Cross(k, Edge1);

            var scale = Edge2 * q * invDet;

            if (scale > double.Epsilon)
            {
                double X = origin.X + scale * ray.X;
                double Y = origin.Y + scale * ray.Y;
                double Z = origin.Z + scale * ray.Z;
            }

            return null;
        }
    }
}
