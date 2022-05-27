using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Basic
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(Point point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }
        public Vector(Point start, Point end)
        {
            X = end.X-start.X;
            Y = end.Y-start.Y;
            Z = end.Z-start.Z;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static Vector Cross(Vector n1, Vector n2)
        {
            double X = n1.Y * n2.Z - n1.Z * n2.Y;
            double Y = n1.Z * n2.X - n1.X * n2.Z;
            double Z = n1.X * n2.Y - n1.Y * n2.X;
            return new Vector(new Point(X, Y, Z));
        }

        public Vector Normalize()
        {
            double Length = this.Length();
            if (Length > 0)
            {
                double X = this.X / Length;
                double Y = this.Y / Length;
                double Z = this.Z / Length;
                return new Vector(new Point(X, Y, Z));
            }
            return this;
        }

        public static Vector operator +(Vector n1, Vector n2)
        {
            return new Vector(new Point(n1.X+n2.X, n1.Y+n2.Y, n1.Z+n2.Z));
        }
        public static Vector operator -(Vector n1, Vector n2)
        {
            return new Vector(new Point(n1.X - n2.X, n1.Y - n2.Y, n1.Z - n2.Z));
        }
        public static Vector operator *(Vector n1, double number)
        {
            return new Vector(new Point(n1.X * number, n1.Y * number, n1.Z * number));
        }
        public static double operator *(Vector n1, Vector n2)
        {
            return n1.X * n2.X + n1.Y * n2.Y + n1.Z * n2.Z;
        }
    }
}
