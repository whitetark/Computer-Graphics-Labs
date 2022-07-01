using GraphicLabs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.SceneStuff.Light
{
    public interface ILight
    {
        public Color color { get; set; }
        public double intensity { get; set; }
        public Vector getDirection(Vector normal, Point intersectionPoint);
        public Color getColor();
    }
}
