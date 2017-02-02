using System.Linq;
using System.Windows.Forms;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Syngine;
using Syngine.Components;
using Syngine.Controllers;
using Syngine.Graphics;
using Syngine.Input;
using Syngine.Input.Keyboard;
using Syngine.Input.Mouse;
using Syngine.Input.Touch;
using Syngine.Physics;
using Syngine.Physics.Graphics;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using MouseButtons = Syngine.Input.Mouse.MouseButtons;

namespace WindowsGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : PhysicsGame
    {
        private IInputSubscription _subscription;

        public Game1()
        {
            IsMouseVisible = true;
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

            //Controller.GraphicsDeviceManager.IsFullScreen = true;
            //Controller.GraphicsDeviceManager.PreferredBackBufferWidth = Controller.GraphicsDevice.DisplayMode.Width;
            //Controller.GraphicsDeviceManager.PreferredBackBufferHeight = Controller.GraphicsDevice.DisplayMode.Height;
            //Controller.GraphicsDeviceManager.ToggleFullScreen();

            GameInput.Input.Set(new TouchHandler());
            GameInput.Input.Set(new MouseHandler());
            GameInput.Input.Set(new KeyboardHandler());
            _subscription = GameInput.If(c => c.WasReleased(Keys.Escape) || c.WasReleased(MouseButtons.X1)).Call(c => Exit());
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
            var layer = AddLayer(new Layer("FpsLayer"));
            layer.AddDrawable(new FpsCounter("Fonts\\Courier New", new Vector2(20, 20)));
            var system = layer.AddDrawable(new ParticleSystem(5));//new[] { "Particles\\circle", "Particles\\star", "Particles\\diamond" }));
            GameInput.If(c => c.IsPressed(MouseButtons.Left)).Call(c =>
            {
                if (system.State == PlayState.Paused)
                {
                    system.Play();
                }
                else
                {
                    system.Pause();
                }
            });
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
            var layer = AddLayer(new Layer("SpriteLayer"));
            var player = layer.AddDrawable(new Player(PlayerIndex.One, new Vector2(500, 100)));
            var ground = layer.AddDrawable(new Ground(new Vector2(-1000, 150), new Vector2(3000, 150), 5));
            var line = layer.AddDrawable(new Line(Color.White));
            line.UpdateDirection(new Vector2(0, 0), player.Position);
            player.Sprites.SetCurrentSheet("idle");

            //GameContext.SetFocus(player.Position);
        }

        private class Player : DrawableBody
        {
            public Player(PlayerIndex playerIndex, Vector2 position) : base(position)
            {
                PlayerIndex = playerIndex;
                Sprites.Add("run", new SpriteSheet("Sprites\\Player\\Run", 0.08f, new Rectangle(500, 250, 64, 64)));
                Sprites.Add("jump", new SpriteSheet("Sprites\\Player\\Jump", 0.08f, new Rectangle(500, 250, 64, 64)));
                Sprites.Add("idle", new SpriteSheet("Sprites\\Player\\Idle", 0.08f, new Rectangle(500, 250, 64, 64)));
            }

            private PlayerIndex PlayerIndex { get; set; }
            
            protected override Body CreateBody(object data)
            {
                var body = BodyFactory.CreateRectangle(WorldContext.World, 64, 64, 1f, InitialPosition.ToSimUnits(), data);
                body.Mass = .001f;
                body.BodyType = BodyType.Dynamic;
                body.CollidesWith = Category.All;
                body.Friction = 1f;
                //body.IgnoreGravity = true;
                body.FixedRotation = true;
                return body;
            }

            protected override void UpdateCore(UpdateContext context)
            {
                base.UpdateCore(context);
                Sprites.SetPosition(Position);
                //GameContext.SetFocus(Position);
            }
        }

        private class Ground : DrawableBody
        {
            public Ground(Vector2 startPosition, Vector2 endPosition, int height = 50) : base(startPosition)
            {
                EndPosition = endPosition;
                Height = height;
            }

            private Texture2D Texture { get; set; }

            protected override Body CreateBody(object data)
            {
                
                var body = BodyFactory.CreateEdge(WorldContext.World, InitialPosition.ToSimUnits(), EndPosition.ToSimUnits());
                body.CollidesWith = Category.All;
                body.BodyType = BodyType.Static;
                body.IgnoreGravity = true;
                return body;
            }

            private int Height { get; }

            private Vector2 EndPosition { get; }

            protected override void DrawCore(DrawContext context)
            {
                context.Draw(Texture, new Rectangle((int)InitialPosition.X, (int)InitialPosition.Y, (int)EndPosition.X, Height), Color.White);
            }

            public override void LoadContent(LoadContext context)
            {
                var texture = new Texture2D(context.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                texture.SetData(new[] { Color.White });
                Texture = texture;
            }

            protected override void UpdateCore(UpdateContext context)
            {
            }
        }
    }
}
