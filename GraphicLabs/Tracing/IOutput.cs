using GraphicLabs.SceneStuff.Light;
using GraphicLabs.SceneStuff;

namespace GraphicLabs.Tracing;

public interface IOutput
{
    void Write(double[,] picture, ILight light, Scene scene);
}