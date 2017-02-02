using Microsoft.Xna.Framework;
using Syngine.Controllers;

namespace Syngine
{
	/// <summary>
	/// The base <see cref="Game"/> object that is the starting point of the game.
	/// </summary>
	public abstract class GameBase : Game
	{
	    protected static Color DefaultColor = Color.Black;

	    private Color? _backBufferColor;

	    protected GameBase()
		{
		    Init(new GameController(this, new GraphicsDeviceManager(this)));
		}

	    protected GameBase(IController controller)
	    {
	        Init(controller);
	    }

		protected IController Controller { get; private set; }

	    public Color BackBufferColor
	    {
	        get
	        {
	            return _backBufferColor ?? DefaultColor;
            }
	        protected set
	        {
	            _backBufferColor = value;
	        }
	    }

        protected void Init(IController controller)
        {
            Controller = controller;
            GameContext.Set(this);
            GameContext.Set(controller);
            this.AddController(controller);
        }

	    protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackBufferColor);

            base.Draw(gameTime);
	    }
	}
}
