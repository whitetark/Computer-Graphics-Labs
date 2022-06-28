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
using System.IO;
using GraphicLabs;
namespace GraphicLabs.Tracing;

public class OBJReader
{
    private string filePath { get; set; }
    private string[] lines;

    public OBJReader(string file)
    {
        filePath = file;
        lines = File.ReadAllLines(@$"..\..\..\IOFiles\{filePath}");
    }
    public List<Point> getPointsAndNormals()
    {
        NumberFormatInfo provider = new NumberFormatInfo();
        provider.NumberDecimalSeparator = ".";
        
        List<Point> points = new List<Point>();
        List<Vector> normals = new List<Vector>();

        foreach (string line in lines)
        {
            if (line.Split(' ')[0] == "v")
            {
                //Console.WriteLine((line.Split(' ')[1]));
                points.Add(new Point(Convert.ToDouble(line.Split(' ')[1], provider), Convert.ToDouble(line.Split(' ')[2], provider), Convert.ToDouble(line.Split(' ')[3], provider)));

            }
            if (line.Split(' ')[0] == "vn")
            {
                //Console.WriteLine((line.Split(' ')[1]));
                normals.Add(new Vector(Convert.ToDouble(line.Split(' ')[1], provider), Convert.ToDouble(line.Split(' ')[2], provider), Convert.ToDouble(line.Split(' ')[3], provider)));
            }
        }

        foreach (string line in lines)
        {
            if (line.Split(' ')[0] == "f")
            {
                int a = Int32.Parse(line.Split(' ')[1].Split('/')[0]);
                int an = Int32.Parse(line.Split(' ')[1].Split('/')[2]);
                int b = Int32.Parse(line.Split(' ')[2].Split('/')[0]);
                var bn = Int32.Parse(line.Split(' ')[2].Split('/')[2]);
                int c = Int32.Parse(line.Split(' ')[3].Split('/')[0]);
                var cn = Int32.Parse(line.Split(' ')[3].Split('/')[2]);

                points[a - 1].Normal = normals[an - 1];
                points[b - 1].Normal = normals[bn - 1];
                points[c - 1].Normal = normals[cn - 1];
            }
        }
        return points;
    }
    public List<Triangle> getTriangles(List<Point> points)
    {
        List<Triangle> triangles = new List<Triangle>();
        
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