using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphicLabs.Figures;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff.Light;

namespace GraphicLabs.SceneStuff
{
    public class Scene
    {
        public List<Figure> figuresOnScene = new List<Figure>();
        public Camera cameraOnScene { get; set; }
        public ILight light { get; set; }

        public Scene() { }
        public Scene(Camera camera)
        {
            cameraOnScene = camera;
        }
        public Scene(Camera camera, ILight light):this(camera)    
        {
            this.light = light;
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
