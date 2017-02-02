using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Syngine.Graphics
{
	/// <summary>
	/// 
	/// </summary>
	public class Particle
	{
        #region Fields

        private static Texture2D _defaultTexture;

        private Texture2D _texture;
		private Rectangle _rectangle;

		#endregion

		#region Constructors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="position"></param>
		/// <param name="velocity"></param>
		public Particle(Vector2 position, Vector2 velocity) : this(null, position, velocity)
		{
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        public Particle(Texture2D texture) : this(texture, Vector2.Zero, Vector2.One)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        public Particle(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            _texture = texture;
			StartPosition = position;
			Position = position;
			Velocity = velocity;
            UseDefaults = true;
            IsDead = false;
            IsInitialized = false;
            Mass = 0.1f;
            StartAlpha = 255f;
            EndAlpha = 1f;
            CurrentAlpha = StartAlpha;
            DefaultHeight = 500f;
            DefaultWidth = 500f;
            LifeTime = 5f;
            Rotation = 0f;
            RotationSpeed = 0.05f;
        }

        #endregion

        #region Properties

        public Color Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float CurrentAlpha { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float StartAlpha { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float EndAlpha { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 StartPosition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public float DefaultWidth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public float DefaultHeight { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool UseDefaults { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public float LifeTime { get; set; }

		/// <summary>
		/// The current rotation of the particle.
		/// </summary>
		public float Rotation { get; set; }

		/// <summary>
		/// The current deceleration of the particle.
		/// </summary>
		public Vector2 Direction { get; set; }

		/// <summary>
		/// The current mass of the particle.
		/// </summary>
		public float Mass { get; set; }

		/// <summary>
		/// The current acceleration of the particle.
		/// </summary>
		public Vector2 Acceleration { get; set; }

		/// <summary>
		/// The current velocity of the particle.
		/// </summary>
		public Vector2 Velocity { get; set; }

		/// <summary>
		/// The current rotation speed of the particle.
		/// </summary>
		public float RotationSpeed { get; set; }

		/// <summary>
		/// The current position of the particle.
		/// </summary>
		public Vector2 Position { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsDead { get; private set; }

		public bool IsInitialized { get; set; }

        public Rectangle Rectangle => _rectangle;

	    public Vector2 Origin { get; set; }

		#endregion

		#region Methods

		public void Initialize()
		{
		    DefaultHeight = 1;
		    DefaultWidth = 1;

            _rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)DefaultWidth, (int)DefaultHeight);

            if (Position == Vector2.Zero && StartPosition != Vector2.Zero)
            {
                Position = StartPosition;
            }

            if (_texture == null && _defaultTexture == null)
            {
                _defaultTexture = new Texture2D(GameContext.Controller.GraphicsDevice, (int)DefaultWidth, (int)DefaultHeight, true, SurfaceFormat.Color);
                _defaultTexture.SetData(new[] { Color.White }, 0, _defaultTexture.Width * _defaultTexture.Height);
            }

            if (_texture == null)
            {
                _texture = _defaultTexture;
            }

            _rectangle.X = (int)Position.X;
            _rectangle.Y = (int)Position.Y;
            _rectangle.Width = _texture.Width;
            _rectangle.Height = _texture.Height;

            Origin = new Vector2(_texture.Width / 2f, _texture.Height / 2f);
        }

		public void Update(UpdateContext context)
		{
		    if (!IsDead)
            {
                var elapsedTime = (float)context.GameTime.ElapsedGameTime.TotalSeconds;
                LifeTime -= elapsedTime;

                if (LifeTime > 0.0f)
                {
                    Acceleration = Vector2.Subtract(Velocity, new Vector2(Mass * elapsedTime));
                    Velocity += GetVelocity(elapsedTime);
                    Position += Velocity * Direction / elapsedTime;
                    Rotation += RotationSpeed;

                    _rectangle.X = (int)Position.X;
                    _rectangle.Y = (int)Position.Y;
                }
                else
                {
                    IsDead = true;
                }
            }
		}

		public void UnloadContent()
		{

		}

		public void Draw(DrawContext context)
        {
		    if (!IsDead)
            {
                var min = StartAlpha > EndAlpha ? EndAlpha : StartAlpha;
                var max = StartAlpha < EndAlpha ? EndAlpha : StartAlpha;
                CurrentAlpha = (StartAlpha - EndAlpha) * LifeTime;
                CurrentAlpha = MathHelper.Clamp(CurrentAlpha, min, max);
                context.Draw(_texture, _rectangle, null, new Color(Color, CurrentAlpha), Rotation, Origin, SpriteEffects.None, 1f);
            }
		}

		private Vector2 GetVelocity(float elapsedTime)
		{
			return Acceleration * elapsedTime;
		}

		#endregion
	}
}