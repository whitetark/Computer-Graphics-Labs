using GraphicLabs.Basic;
using GraphicLabs.SceneStuff.Light;
using System.IO;
using GraphicLabs.SceneStuff;

namespace GraphicLabs.Tracing;

public class PPMWriter:IOutput
{
    public string PPMFile { get; set; }
    public PPMWriter(string PPM)
    {
        PPMFile = PPM;
    }
    public void Write(double[,] picture, ILight light, Scene scene)
    {
        
        Color black = new Color(0, 0, 0);
        Color color = light.getColor();

        Color matColor = new Color((int) scene.helpingColor.X * 255, (int) scene.helpingColor.Y * 255,
            (int) scene.helpingColor.Z * 255);
        var resColor = matColor + color + black;

        StreamWriter file = new(@$"..\..\..\IOFiles\{PPMFile}");
        file.WriteLine("P3");
        file.WriteLine(picture.GetUpperBound(0) + 1 + " " + (picture.GetUpperBound(1) + 1));
        file.WriteLine("255");
        file.WriteLine();
        for(int i = picture.GetUpperBound(1); i >= 0; i--)
        {
            for (int j = picture.GetUpperBound(0); j >=0 ; j--)
            {
                if (picture[j, i] != -10)
                    file.Write((int) (resColor.r * Math.Abs(picture[j, i])) + " " +
                               (int) (resColor.g * Math.Abs(picture[j, i])) + " " +
                               (int) (resColor.b * Math.Abs(picture[j, i])));
                else file.Write("0 0 255");
                file.WriteLine();
            }
        }
        file.Flush();
        file.Close();
    }
}