using Syngine.Graphics;

namespace Syngine.Components
{
    public interface ILayer : IDraw
    {
        string Name { get; set; }

        TUpdate AddUpdatable<TUpdate>(TUpdate updatable) where TUpdate : IUpdate;

        TDraw AddDrawable<TDraw>(TDraw drawable) where TDraw : IDraw;
    }
}