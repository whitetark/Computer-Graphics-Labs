using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.Materials;

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
        
        public IMaterial material { get; set; }
        public Point Center { get; set; }
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        
        public Vector At { get; set; }
        public Vector Bt { get; set; }
        public Vector Ct { get; set; }
        
        public Vector[] normals = new Vector[3];
        public Triangle(Point a, Point b, Point c, Vector t1, Vector t2, Vector t3)
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
            
            At = new Vector(t1.X, t1.Y, 0);
            Bt = new Vector(t2.X, t2.Y, 0);
            Ct = new Vector(t3.X, t3.Y, 0);

            Center = new Point((A.X + B.X + C.X) / 3, (A.Y + B.Y + C.Y) / 3, (A.Z + B.Z + C.Z) / 3);
        }

        public override Vector GetNormal(Point point)
        {
            //Vector Vector1 = B - A;
            //Vector Vector2 = C - A;
            //return Vector.Cross(Vector1, Vector2).Normalize();

            //Vector[] normals = new Vector[3];
            //normals[0] = A.Normal;
            //normals[1] = B.Normal;
            //normals[2] = C.Normal;

            //for (int i = 0; i<3; i++)
            //{
            //    if(normals[i] == null)
            //    {
            //        normals[i] = new Vector(0, 0, 0);
            //    }
            //}
            //return normals;
            
           
            if(normals[0] == null)
            {
                if (A.Normal == null || B.Normal == null || C.Normal == null)
                {
                    Vector Vector1 = B - A;
                    Vector Vector2 = C - A;
                    return Vector.Cross(Vector1, Vector2).Normalize();
                }

                normals[0] = A.Normal;
                normals[1] = B.Normal;
                normals[2] = C.Normal;
            }

            double ownArea = Vector.Cross(B - A, C - A).Length() / 2;
            double vArea = Vector.Cross(A - B, point - B).Length() / 2;
            double uArea = Vector.Cross(C - A, point - A).Length() / 2;

            double u = uArea / ownArea;
            double v = vArea / ownArea;

            var detail1 = normals[1] * u;
            var detail2 = normals[2] * v;
            var detail3 = normals[0] * (1 - v - u);

            return (detail1 + detail2 + detail3).Normalize();
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


            var u = Vector.Dot(k,p) * invDet;
            //Check for ray hit
            if (u < 0 || u > 1)
            {
                return false;
            }

            Vector q = Vector.Cross(k, Edge1);


            var v = Vector.Dot(ray.Direction,q) * invDet;
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
            return new Triangle(a, b, c, At, Bt, Ct);
        }
        
        public override Double[] Bari(Point p){
            if (At.X <= 1) {
                double ownArea = Vector.Cross((B - A), (C - A)).Length() / 2;
                double vArea = Vector.Cross((A - B), (p - B)).Length() / 2;
                double uArea = Vector.Cross((C - A), (p - A)).Length() / 2;
                double u = uArea / ownArea;
                double v = vArea / ownArea;
                Vector res = (Bt *u) + ((Ct * v)+(At *(1 - v - u)));
                return new Double[]{res.X, res.Y};
            }
            else{
                return new Double[]{0, 0};
            }
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
