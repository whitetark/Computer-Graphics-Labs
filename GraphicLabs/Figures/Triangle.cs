using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;

namespace GraphicLabs.Figures
{
    public class Triangle : Figure
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

        public override Vector GetNormal(Point point)
        {
            Vector Vector1 = B - A;
            Vector Vector2 = C - A;
            return Vector.Cross(Vector1,Vector2).Normalize();
        }

        public override bool IsIntersects(Ray ray)
        {
            //Find vectors for two edges
            Vector Edge1 = B - A;
            Vector Edge2 = C - A;

            //Calculating determinant
            Vector p = Vector.Cross(ray.Direction, Edge2);
            double Det = Vector.Dot(Edge1,p);

            //If determinant is near zero, ray lies in plane of triangle otherwise not
            if (Det > -(double.Epsilon)&& Det < double.Epsilon)
            {
                return false;
            }
            double invDet = 1.0f / Det;

            //Calculate distance from A to ray origin
            Vector k = ray.Origin - A;

            double u = Vector.Dot(k,p) * invDet;
            //Check for ray hit
            if (u < 0 || u > 1)
            { 
                return false; 
            }

            Vector q = Vector.Cross(k, Edge1);

            double v = Vector.Dot(ray.Direction,q) * invDet;
            //Check for ray hit
            if (v < 0 || u + v > 1) { return false; }

            if ((Vector.Dot(Edge2,q) * invDet) > double.Epsilon)
            {
                return true;
            }

            return false;
        }

        public override Point IntersectionPoint(Ray ray)
        {
            Vector Edge1 = B - A;
            Vector Edge2 = C - A;

            Vector p = Vector.Cross(ray.Direction, Edge2);
            double Det = Vector.Dot(Edge1,p);
            double invDet = 1.0f / Det;

            Vector k = ray.Origin - A;

            Vector q = Vector.Cross(k, Edge1);

            var scale = Vector.Dot(Edge2,q) * invDet;

            if (scale > double.Epsilon)
            {
                double X = ray.Origin.X + scale * ray.Direction.X;
                double Y = ray.Origin.Y + scale * ray.Direction.Y;
                double Z = ray.Origin.Z + scale * ray.Direction.Z;
                return new Point(X, Y, Z);
            }

            return null;
        }
        public override string ToString()
        {
            return $"Triangle(({A.X},{A.Y},{A.Z}),({B.X},{B.Y},{B.Z}),({C.X},{C.Y},{C.Z}))";
        }

        public Triangle Transform(Matrix matrix)
        {
            var a = A.Transform(matrix);
            var b = B.Transform(matrix);
            var c = C.Transform(matrix);
            return new Triangle(a,b,c);
        }
    }
}
