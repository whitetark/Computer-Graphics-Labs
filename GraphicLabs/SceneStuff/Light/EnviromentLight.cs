using GraphicLabs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.SceneStuff.Light
{
    public class EnviromentLight : ILight
    {
        public Color color { get; set; }
        public double intensity { get; set; }

        public EnviromentLight(Color color, double intensity)
        {
            if(intensity > 1)
            {
                intensity = 1;
            }
            this.color = color;
            this.intensity = intensity;
        }
        public EnviromentLight()
        {
            color = new Color(255, 255, 255);
            intensity = 1;
        }

        public Vector generateDirection(Vector normal, Point intersectionPoint)
        {
            Random rnd = new Random();
            var direction = new Vector(rnd.NextDouble() * 5, rnd.NextDouble() * 5, rnd.NextDouble() * 5);
            if(Vector.Dot(direction, normal) < 0) { direction *= -1; }
            return direction;
        }
        public Color currColor()
        {
            return color * intensity;
        }
    }
}
