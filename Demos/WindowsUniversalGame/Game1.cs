using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Syngine;
using Syngine.Components;
using Syngine.Controllers;
using Syngine.Graphics;
using Syngine.Input;
using Syngine.Input.Keyboard;
using Syngine.Input.Touch;
using Syngine.Physics;

namespace WindowsUniversalGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : PhysicsGame
    {
        private IInputSubscription _subscription;

        public Game1()
        {
            this.AddController(new FpsController(this));
            this.AddController(new SpriteSheetController(this));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            GameInput.Input.Set(new TouchHandler());
            GameInput.Input.Set(new KeyboardHandler());
            _subscription = GameInput.If(c => c.WasReleased(Keys.Escape)).Call(c => Exit());
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            _subscription?.Unsubscribe();
        }
    }

    internal class FpsController : Controller
    {
        public FpsController(Game game) : base(game)
        {
            var layer = new Layer("FpsLayer");
            layer.AddDrawable(new FpsCounter("Fonts\\Courier New", new Vector2(20, 20)));
            Layers.Add(layer);
        }

        protected override BeginCallOptions GetBeginCallOptions()
        {
            return new BeginCallOptions();
        }
    }

    internal class SpriteSheetController : Controller
    {
        public SpriteSheetController(Game game) : base(game)
        {
            var layer = AddLayer(new Layer("SpriteSheetLayer"));
            var runningSpriteSheet = new SpriteSheet("Sprites\\Player\\Run", PlayState.Paused, 0.10f, new Rectangle(500, 250, 64, 64));
            layer.AddDrawable(runningSpriteSheet);

            var focusedSpriteSheet = new SpriteSheet("Sprites\\Player\\Jump", 0.15f, new Rectangle(-60, 60, 64, 64));
            layer.AddDrawable(focusedSpriteSheet);
            
            //GameContext.SetFocus(focusedSpriteSheet.Position);
        }
    }
}
