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
    List<Vector> textures;

    public OBJReader(string file)
    {
        filePath = file;
        lines = File.ReadAllLines(@$"..\..\..\IOFiles\{filePath}");
    }
    public List<Point> getInfo()
    {
        NumberFormatInfo provider = new NumberFormatInfo();
        provider.NumberDecimalSeparator = ".";
        
        List<Point> points = new List<Point>();
        List<Vector> normals = new List<Vector>();
        textures = new List<Vector>();

        
        foreach (string line in lines)
        {
            if (line.Split(' ')[0] == "v")
            {
                //Console.WriteLine((line.Split(' ')[1]));
                points.Add(new Point(Convert.ToDouble(line.Split(' ')[1], provider), Convert.ToDouble(line.Split(' ')[2], provider), Convert.ToDouble(line.Split(' ')[3], provider)));

            }
            if (line.Split(' ')[0] == "vn")
            {
                normals.Add(new Vector(Convert.ToDouble(line.Split(' ')[1], provider), Convert.ToDouble(line.Split(' ')[2], provider), Convert.ToDouble(line.Split(' ')[3], provider)));
            }
            if (line.Split(' ')[0] == "vt")
            {
                textures.Add(new Vector(Convert.ToDouble(line.Split(' ')[1], provider), Convert.ToDouble(line.Split(' ')[2], provider), Convert.ToDouble(line.Split(' ')[3], provider)));
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
                Vector at;
                Vector bt;
                Vector ct;
                string s1 = line.Split(' ')[1].Split('/')[1];
                string s2 = line.Split(' ')[2].Split('/')[1];
                string s3 = line.Split(' ')[3].Split('/')[1];
                if (s1 != "") at = textures[Int32.Parse(s1) - 1];
                else at = new Vector(0, 0, 0);
                if (s2 != "") bt = textures[Int32.Parse(s2) - 1];
                else bt = new Vector(0, 0, 0);
                if (s3 != "") ct = textures[Int32.Parse(s3) - 1];
                else ct = new Vector(0, 0, 0);

                triangles.Add(new Triangle(points[a-1], points[b-1], points[c-1], at, bt, ct));
            }
        }
        return triangles;
    }
}