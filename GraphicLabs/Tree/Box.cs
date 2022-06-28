using GraphicLabs.Basic;
using GraphicLabs.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.Tree
{
    public class Box
    {
        public double MaxX { get; set; }
        public double MaxY { get; set; }
        public double MaxZ { get; set; }
        public double MinX { get; set; }
        public double MinY { get; set; }
        public double MinZ { get; set; }
        
        public Point Center { get; }
        
        public List<Figure> figures { get; set; }

        public Box(double maxx, double maxy, double maxz, double minx, double miny, double minz)
        {
            MaxX = maxx;
            MaxY = maxy;
            MaxZ = maxz;
            MinX = minx;
            MinY = miny;
            MinZ = minz;

            Center = new Point(MinX + ((MaxX - MinX) / 2), MinY + ((MaxY - MinY) / 2), MinZ + ((MaxZ - MinZ) / 2));

        }

        public bool IsIntersects(Ray ray)
        {
            double txmin = (MinX - ray.Origin.X) / ray.Direction.X; 
            double txmax = (MaxX - ray.Origin.X) / ray.Direction.X; 
 
            if (txmin > txmax)
            {
                double swap = txmin;
                txmin = txmax;
                txmax = swap;
            }
 
            double tymin = (MinY - ray.Origin.Y) / ray.Direction.Y; 
            double tymax = (MaxY - ray.Origin.Y) / ray.Direction.Y; 
 
            if (tymin > tymax)
            {
                double swap = tymin;
                tymin = tymax;
                tymax = swap;
            }
 
            if ((txmin > tymax) || (tymin > txmax)) 
                return false; 
 
            if (tymin > txmin) 
                txmin = tymin; 
 
            if (tymax < txmax) 
                txmax = tymax; 
 
            double tzmin = (MinZ - ray.Origin.Z) / ray.Direction.Z; 
            double tzmax = (MaxZ - ray.Origin.Z) / ray.Direction.Z;

            if (tzmin > tzmax)
            {
                double swap = tzmin;
                tzmin = tzmax;
                tzmax = swap;
            }

            if ((txmin > tzmax) || (tzmin > txmax)) 
                return false; 
 
            if (tzmin > txmin) 
                txmin = tzmin; 
 
            if (tzmax < txmax) 
                txmax = tzmax; 
 
            return true; 
        }
    }
}