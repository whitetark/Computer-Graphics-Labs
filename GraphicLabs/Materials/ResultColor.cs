using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.SceneStuff;
using GraphicLabs.Basic;
namespace GraphicLabs.Materials
{
    public class ResultColor
    {
        public Vector color { get; set; }
        public float dotLight { get; set; }
        public ResultColor(Vector color)
        {
            this.color = color;

        }

        public ResultColor(Vector color, float dotLight) : this(color)
        {
            this.dotLight = dotLight;
        }
    }
}
