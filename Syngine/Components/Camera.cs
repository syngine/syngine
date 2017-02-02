using Microsoft.Xna.Framework;

namespace Syngine.Components
{
	public class Camera : Updatable
	{
		private Vector2 _position;
        
		public float Scale { get; set; }

		public float Rotation { get; set; }
		
		public float MoveSpeed { get; set; }
		
		public Vector2 Origin { get; set; }
		
		public Matrix Transform { get; set; }

		public Vector2 Focus { get; set; }

		public Vector2 Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
			}
		}
		
		public Vector2 Center { get; protected set; }

		public override void Initialize()
		{
			var viewport = GameContext.Game.GraphicsDevice.Viewport;
            var center = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
		    Center = center;
		    Position = Center;
		    Focus = Center;
			Scale = 1f;
			MoveSpeed = 1.35f;

			base.Initialize();
		}

	    protected override void UpdateCore(UpdateContext context)
	    {
            Transform = Matrix.Identity *
                        Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateTranslation(Origin.X, Origin.Y, 0) *
                        Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

            Origin = Center / Scale;

            var delta = (float)context.GameTime.ElapsedGameTime.TotalSeconds;

            _position.X += (Focus.X - _position.X) * MoveSpeed * delta;
            _position.Y += (Focus.Y - _position.Y) * MoveSpeed * delta;
        }
	}
}
