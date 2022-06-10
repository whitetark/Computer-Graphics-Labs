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
        public DirectionalLight dirLight { get; set; }

        public Scene() { }
        public Scene(Camera camera)
        {
            cameraOnScene = camera;
        }
        public Scene(Camera camera, DirectionalLight directionLight):this(camera)    
        {
            

            dirLight = directionLight;
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
