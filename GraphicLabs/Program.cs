using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Figures;
using GraphicLabs.Basic;
using GraphicLabs.SceneStuff;
using GraphicLabs.Tracing;
using System.Diagnostics;


namespace GraphicLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(args[0]);
            //Console.WriteLine(args[1]);
            /*var input = Starter.StarterProg(args);
            if (input == null)
            {
                return;
            }*/
            string[] input = { "cow.obj", "output.ppm" };
            TracingLight tracingLight = new TracingLight();
            
            var scene = tracingLight.createTestingSceneFromFile(input[0]);
            
            var screenDrawer = tracingLight.Trace(scene);
            IOutput pictureOutput = new PPMWriter(input[1]);
            pictureOutput.Write(screenDrawer,scene.light);
            Console.Write("Done!");
        }
    }
}