using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//если добавлять класс ФИГУРА, то и зависимость тоже
using System.Threading.Tasks;
using GraphicLabs.Basic;

namespace GraphicLabs.SceneStuff
{
    public class Scene
    {
        private List<Figure> figuresOnScene=new List<Figure>(); 
        private Camera cameraOnScene;
        
        //я бы добавил еще в папку фигур добавил класс ФИГУРА, который может быть чет общее описывал

        public Scene(Camera camera, List<Figure> figures)
        {
            cameraOnScene=camera;
            figuresOnScene=figures;
        }

        private void addFigure()
        {
            if(!figures)
            {
                figuresOnScene.Add(figures)
            }
        }
    }
}
