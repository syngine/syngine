using Syngine.Graphics;

namespace Syngine.Components
{
    public interface ILayer : IDraw
    {
        string Name { get; set; }
    }
}