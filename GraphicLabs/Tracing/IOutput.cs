using GraphicLabs.SceneStuff.Light;

namespace GraphicLabs.Tracing;

public interface IOutput
{
    void Write(double[,] picture, ILight light);
}