using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphicLabs.Basic;
using System.Threading.Tasks;

namespace GraphicLabs.SceneStuff
{
    public class DirectionalLight
    {

        private Vector direction;
        
        /*public DirectionalLight Direction(Vector direction)
        {
            get=>direction;
            set => direction=value.Normalize().Scale(-1);
        }
        */

        public Vector Direction
        {
            get{return direction;}
            set{direction=value.Normalize()*(-1);}
        }
    }
}
