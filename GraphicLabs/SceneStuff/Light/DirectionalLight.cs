using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphicLabs.Basic;
using System.Threading.Tasks;

namespace GraphicLabs.SceneStuff.Light
{
    public class DirectionalLight : ILight
    {
        public Vector direction { get; set; }
        public Color color { get; set; }
        public double intensity { get; set; }

        public DirectionalLight(Vector direction, Color color, double intensity)
        {
            if (intensity > 1)
            {
                intensity = 1;
            }
            this.direction = direction.Normalize();
            this.color = color;
            this.intensity = intensity;
        }
        public DirectionalLight(Vector direction)
        {
            this.direction = direction.Normalize();
            color = new Color(255, 255, 255);
            intensity = 1;
        }

        public Vector generateDirection(Vector normal, Point intersectionPoint)
        {
            return direction * -1;
        }
        public Color currColor()
        {
            return color * intensity;
        }
    }
}
