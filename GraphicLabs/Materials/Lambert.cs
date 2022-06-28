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

        public ResultColor Calculate(Ray ray, Hit hit, Scene scene, int recursions=0)
        {
            var shade = ShadeProccessing(scene, hit);

            return new ResultColor(shade >= 0 ? Vector.Interpolation(_colorish, whiteVector, 0.8f*shade):Vector.Interpolation(_colorish, blackVector, -shade)); //тут еще думаю над методом
        }

        public static float ShadeProccessing(Scene scene, Hit hit, Vector vec)
        {
            var ligthPercentage = 0f;


            return ligthPercentage;
        }

    }


}
