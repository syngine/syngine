using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Syngine.Components;

namespace Syngine.Controllers
{
    public interface IController : IGameComponent, IUpdateable, IDrawable, IEnumerable<ILayer>
    {
        Game Game { get; }
        
        GraphicsDevice GraphicsDevice { get; }

        GraphicsDeviceManager GraphicsDeviceManager { get; }

        SpriteBatch SpriteBatch { get; }

        IEnumerable<ILayer> Layers { get; }

        TLayer AddLayer<TLayer>(TLayer layer) where TLayer : ILayer;
    }
}