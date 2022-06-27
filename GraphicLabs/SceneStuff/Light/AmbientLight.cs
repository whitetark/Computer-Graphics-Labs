using GraphicLabs.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLabs.SceneStuff.Light
{
    public class AmbientLight : ILight
    {
        public List<Vector> directions { get; set; }
        public Color color { get; set; }
        public double intensity { get; set; }

        public AmbientLight(Color color, double intensity)
        {
            this.color = color;
            this.intensity = intensity;
        }
        public AmbientLight()
        {
            color = new Color(255, 255, 255);
            intensity = 1;
        }

        //private List<Vector> generateDirections()
        //{

        //}
        public Color currColor()
        {
            return color * intensity;
        }
    }
}
