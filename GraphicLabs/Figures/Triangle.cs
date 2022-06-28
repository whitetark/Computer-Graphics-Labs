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
        private double MaxX;
        private double MaxY;
        private double MaxZ;
        private double MinX;
        private double MinY;
        private double MinZ;
        
        public Point Center { get; set; }
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
            MaxX = Math.Max(C.X, Math.Max(A.X, B.X));
            MaxY = Math.Max(C.Y, Math.Max(A.Y, B.Y));
            MaxZ = Math.Max(C.Z, Math.Max(A.Z, B.Z));
            MinX = Math.Min(C.X, Math.Min(A.X, B.X));
            MinY = Math.Min(C.Y, Math.Min(A.Y, B.Y));
            MinZ = Math.Min(C.Z, Math.Min(A.Z, B.Z));

            Center = new Point((A.X + B.X + C.X) / 3, (A.Y + B.Y + C.Y) / 3, (A.Z + B.Z + C.Z) / 3);
        }

        public override Vector GetNormal(Point point)
        {
            Vector Vector1 = B - A;
            Vector Vector2 = C - A;
            return Vector.Cross(Vector1, Vector2).Normalize();
        }

        public override bool IsIntersects(Ray ray)
        {
            //Find vectors for two edges
            Vector Edge1 = B - A;
            Vector Edge2 = C - A;

            //Calculating determinant
            Vector p = Vector.Cross(ray.Direction, Edge2);
            double Det = Vector.Dot(Edge1, p);

            //If determinant is near zero, ray lies in plane of triangle otherwise not
            if (Det > -(double.Epsilon) && Det < double.Epsilon)
            {
                return false;
            }

            double invDet = 1.0f / Det;

            //Calculate distance from A to ray origin
            Vector k = ray.Origin - A;

            double u = Vector.Dot(k, p) * invDet;
            //Check for ray hit
            if (u < 0 || u > 1)
            {
                return false;
            }

            Vector q = Vector.Cross(k, Edge1);

            double v = Vector.Dot(ray.Direction, q) * invDet;
            //Check for ray hit
            if (v < 0 || u + v > 1)
            {
                return false;
            }

            if ((Vector.Dot(Edge2, q) * invDet) > double.Epsilon)
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
            double Det = Vector.Dot(Edge1, p);
            double invDet = 1.0f / Det;

            Vector k = ray.Origin - A;

            Vector q = Vector.Cross(k, Edge1);

            var scale = Vector.Dot(Edge2, q) * invDet;

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
            return new Triangle(a, b, c);
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
