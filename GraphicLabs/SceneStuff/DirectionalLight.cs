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
        
        public Vector Direction
        {
            get => direction;
            set => direction=value.Normalize();

        }
    }
}
