using GraphicLabs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.SceneStuff.Light
{
    public class PointLight : ILight
    {
        public Color color { get; set; }
        public double intensity { get; set; }
        public Point origin { get; set; }

        public PointLight(Point point, Color color, double intensity)
        {
            if (intensity > 1)
            {
                intensity = 1;
            }
            origin = point;
            this.color = color;
            this.intensity = intensity;
        }
        public PointLight()
        {
            origin = new Point(0, 0, 0);
            color = new Color(255, 255, 255);
            intensity = 1;
        }

        public Vector generateDirection(Vector normal, Point intersectionPoint)
        {
            return origin - intersectionPoint;
        }
        public Color currColor()
        {
            return color * intensity;
        }
    }
}
