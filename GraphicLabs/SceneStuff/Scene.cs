using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphicLabs.Figures;
using System.Threading.Tasks;
using GraphicLabs.Basic;

namespace GraphicLabs.SceneStuff
{
    public class Scene
    {
        public List<Figure> figuresOnScene = new List<Figure>();
        public Camera cameraOnScene { get; set; }


        public Scene(Camera camera, List<Figure> figures)
        {
            cameraOnScene = camera;
            figuresOnScene = figures;
        }

        public void addFigure(Figure figure)
        {
            if(figure!= null)
            {
                figuresOnScene.Add(figure);
            }
        }
    }
}
