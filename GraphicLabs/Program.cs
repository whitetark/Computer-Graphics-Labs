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
            int sampleNum = 1;

            Console.WriteLine("Choose an option: 1 - tracing with tree, 2 - tracing w/o tree, 3 - both");
            int var = Convert.ToInt32(Console.ReadLine());
            if (var == 1)
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                Console.WriteLine("Tracing with tree...");
                var screenDrawer = tracingLight.TraceWTree(scene, sampleNum);
                IOutput pictureOutput = new PPMWriter(input[1]);
                pictureOutput.Write(screenDrawer, scene.light);
                Console.Write("Done!");
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            }
            else if (var == 2)
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                Console.WriteLine("Tracing without tree...");
                var screenDrawer = tracingLight.Trace(scene, sampleNum);
                IOutput pictureOutput = new PPMWriter(input[1]);
                pictureOutput.Write(screenDrawer, scene.light);
                Console.Write("Done!");
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            }
            else if (var == 3)
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                Console.WriteLine("Tracing with tree and without tree...");
                var screenDrawer1 = tracingLight.TraceWTree(scene, sampleNum);
                IOutput pictureOutput1 = new PPMWriter("output1.ppm");
                pictureOutput1.Write(screenDrawer1, scene.light);
                Console.Write("Done (with tree)!");
                
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                
                var screenDrawer2 = tracingLight.Trace(scene, sampleNum);
                IOutput pictureOutput2 = new PPMWriter("output2.ppm");
                pictureOutput2.Write(screenDrawer2, scene.light);
                Console.Write("Done (w/o tree)!");
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
            }
            else
            {
                Console.Write("Error, wrong input!");
                return;
            }

        }
    }
}