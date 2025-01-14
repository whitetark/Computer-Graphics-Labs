﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Basic
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vector Normal { get; set; }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point operator +(Vector vector, Point point)
        {
            return new Point(vector.X + point.X, vector.Y + point.Y, vector.Z + point.Z);
        }
        public static Point operator -(Vector vector, Point point)
        {
            return new Point(point.X - vector.X, point.Y - vector.Y, point.Z - vector.Z);
        }
        public static Vector operator -(Point n1, Point n2)
        {
            return new Vector(n1.X - n2.X, n1.Y - n2.Y, n1.Z - n2.Z);
        }
        public override string ToString()
        {
            return $"Point({X}, {Y}, {Z})";
        }

        public Point Transform(Matrix matrix)
        {
            Vector vector = new Vector(this.X, this.Y, this.Z);
            Vector res = matrix * vector;

            Point transPoint = new Point(res.X, res.Y, res.Z);
            if (Normal != null)
            {
                vector = Normal.Transform(matrix).Normalize();
            }
            transPoint.Normal = vector;

            return transPoint;
        }
    }
}
