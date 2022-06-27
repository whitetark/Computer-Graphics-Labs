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
        public List<Vector> directions { get; set; }
        public Color color { get; set; }
        public double intensity { get; set; }

        public DirectionalLight(Vector direction, Color color, double intensity)
        {
            directions[0] = direction.Normalize();
            this.color = color;
            this.intensity = intensity;
        }
        public DirectionalLight(Vector direction)
        {
            directions[0] = direction.Normalize();
            color = new Color(255, 255, 255);
            intensity = 1;
        }

        public Color currColor()
        {
            return color * intensity;
        }
    }
}
