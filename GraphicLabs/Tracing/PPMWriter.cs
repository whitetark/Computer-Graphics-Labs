using GraphicLabs.Basic;
using System.IO;
namespace GraphicLabs.Tracing;

public class PPMWriter:IOutput
{
    public void Write(double[,] picture)
    {
        Vector toColor = new Vector(255.0, 255.0, 255.0);
        StreamWriter file = new(@"C:\Users\Polya\Computer-Graphics-Labs\GraphicLabs\IOfiles\output.ppm");
        file.WriteLine("P3");
        file.WriteLine(picture.GetUpperBound(0) + 1 + " " + (picture.GetUpperBound(1) + 1));
        file.WriteLine("255");
        file.WriteLine();
        for(int i = picture.GetUpperBound(1); i >= 0; i--)
        {
            for (int j = picture.GetUpperBound(0); j >=0 ; j--)
            {
                if (picture[j, i] != -10)
                    file.Write((int) (toColor.X * Math.Abs(picture[j, i])) + " " +
                               (int) (toColor.Y * Math.Abs(picture[j, i])) + " " +
                               (int) (toColor.Z * Math.Abs(picture[j, i])));
                else file.Write("0 0 255");
                file.WriteLine();
            }
            
        }
        file.Flush();
        file.Close();
    }
}