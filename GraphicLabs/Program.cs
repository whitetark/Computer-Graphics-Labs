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


            Scene scene = new Scene();
            TracingLight tracingLight = new TracingLight();
            tracingLight.Trace();
            Console.ReadLine();

        }
    }
}