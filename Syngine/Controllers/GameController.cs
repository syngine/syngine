using Microsoft.Xna.Framework;

namespace Syngine.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GameController : Controller
	{
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        public GameController(Game game) : this(game, new GraphicsDeviceManager(game))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="graphics"></param>
        public GameController(Game game, GraphicsDeviceManager graphics) : base(game)
        {
            if (RootController == null)
            {
                RootController = this;
            }

            game.Content.RootDirectory = "Content";
            GraphicsDeviceManager = graphics;
        }

		#endregion

		#region Methods

	    /// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		public override void Initialize()
        {
            InitializeGraphics(GraphicsDeviceManager);

            GameContext.Camera.Initialize();
            GameContext.Input.Initialize();

            base.Initialize();
		}

        private void InitializeGraphics(GraphicsDeviceManager graphics)
        {
            graphics.PreferredBackBufferWidth = GraphicsDevice.Viewport.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.Viewport.Height;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			var context = GameContext.CreateUpdateContext(gameTime);
			GameContext.Camera.Update(context);
			GameContext.Input.Update(context);
			base.Update(gameTime);
		}

		#endregion
	}
}
