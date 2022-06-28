using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;

namespace GraphicLabs.Figures
{
    public abstract class Figure
    {
        public abstract bool IsIntersects(Ray ray);
        public abstract Vector[] GetNormal(Point point);
        public abstract Point IntersectionPoint(Ray ray);

        public abstract double GetMaxX();
        public abstract double GetMaxY();
        public abstract double GetMaxZ();
        public abstract double GetMinX();
        public abstract double GetMinY();
        public abstract double GetMinZ();
        
        public abstract Point GetCenter();
    }
}
