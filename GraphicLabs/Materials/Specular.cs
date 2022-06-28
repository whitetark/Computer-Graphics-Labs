using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;


namespace GraphicLabs.Materials
{


    public class Specular : IMaterial
    {
        private Vector _specVector;
        private static Vector blackVector=new Vector(0f, 0f, 0f);

        public Specular(Vector specVector)
        {
            _specVector = specVector;
        }


    }
}
