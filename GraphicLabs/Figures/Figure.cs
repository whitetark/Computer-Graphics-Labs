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
        public string Type;
        public abstract bool IsIntersects(Ray ray);
        public abstract Vector GetNormal(Point point);
        public abstract Point IntersectionPoint(Ray ray);
    }
}
