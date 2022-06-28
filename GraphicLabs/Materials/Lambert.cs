using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;
using GraphicLabs.SceneStuff.Light;

namespace GraphicLabs.Materials
{
    public class Lambert : IMaterial
    {
        private readonly Vector _colorish;
        private static readonly Vector whiteVector = new Vector(1f, 1f, 1f);
        private static readonly Vector blackVector = new Vector(0f, 0f, 0f);

        public Lambert(Vector colorish)
        {
            _colorish= colorish;
        }

        public Color Calculate(Ray ray, Point intersection, Scene scene, int recursions)
        {
            var shade = ShadeProccessing(scene, intersection);
            return new Color(/*надо будет тут кое-что уточнить*/);
        }

        public static float ShadeProccessing(Scene scene, Point intersection)
        {
            var ligthPercentage = 0f;


            return ligthPercentage;
        }

    }


}
