using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicLabs.Basic;
using GraphicLabs.Figures;
using GraphicLabs.SceneStuff;
using GraphicLabs.Tracing;
using GraphicLabs;
namespace GraphicLabs.Tracing;

public class OBJReader
{
    public List<Triangle> getTriangles()
    {
        NumberFormatInfo provider = new NumberFormatInfo();
        provider.NumberDecimalSeparator = ".";
        List<Triangle> triangles = new List<Triangle>();;
        List<Point> points = new List<Point>();;
        string[] lines = System.IO.File.ReadAllLines(@"..\..\..\IOFiles\cow.obj");
        
        foreach (string line in lines)
        {
            if (line.Split(' ')[0] == "v")
            {
                //Console.WriteLine((line.Split(' ')[1]));
                points.Add(new Point(Convert.ToDouble(line.Split(' ')[1], provider), Convert.ToDouble(line.Split(' ')[2], provider), Convert.ToDouble(line.Split(' ')[3], provider)));
            }
        }
        
        foreach (string line in lines)
        {
            if (line.Split(' ')[0] == "f")
            {
                int a = Int32.Parse(line.Split(' ')[1].Split('/')[0]);
                int b = Int32.Parse(line.Split(' ')[2].Split('/')[0]);
                int c = Int32.Parse(line.Split(' ')[3].Split('/')[0]);
                triangles.Add(new Triangle(points[a-1], points[b-1], points[c-1]));
            }
        }
        return triangles;
    }
    
}