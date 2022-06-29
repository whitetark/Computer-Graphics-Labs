using GraphicLabs.SceneStuff.Light;
using GraphicLabs.SceneStuff;

namespace GraphicLabs.Tracing;

public class ConsoleWriter:IOutput
{
    public void Write(double[,] picture, ILight light, Scene scene)
    {
        for(int i = 0; i < picture.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < picture.GetUpperBound(1) + 1; j++)
            {
                if (picture[i, j] < 0)  Console.Write(' ');
                else if ((picture[i, j] >= 0) &&
                         (picture[i, j] < 0.2)) Console.Write('.');
                else if ((picture[i, j] >= 0.2) &&
                         (picture[i, j] < 0.5)) Console.Write('*');
                else if ((picture[i, j] >= 0.5) &&
                         (picture[i, j] < 0.8)) Console.Write('0');
                else if (picture[i, j] >= 0.8) Console.Write('#');
            }
            Console.WriteLine();
        }
        
    }
}