using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Figures;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;
using GraphicLabs.Tracing;

namespace CompGraphics
{
    class Program
    {
        static void Main(string[] args)
        {

            Camera camera = new Camera(0, 0, 0, 0, 0, -1, 20, 20);
            
            Sphere testSphere = new Sphere(new Point(0, 0, -10), 2);
            Sphere testSphere2 = new Sphere(new Point(0, 3, -12), 4);
            Triangle testTriangle = new Triangle(new Point(1, 1, -15), new Point(5, 5, -11), new Point(0, 3, -2));
            Plane testPlane = new Plane(new Vector(0, 0, 1), new Point(0, 0, -20));
            
            DirectionalLight lightSource = new DirectionalLight() { Direction = new Vector(0, 0, -1) };
            
            Scene scene = new Scene(camera, lightSource);
            
            scene.addFigure(testTriangle);
            scene.addFigure(testSphere);
            
            scene.addFigure(testTriangle);
            
            TracingLight tracingLight = new TracingLight();
            tracingLight.Trace(scene);
            Console.ReadLine();

        }
    }
}