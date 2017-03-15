using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Syngine.Graphics
{
	/// <summary>
	/// 
	/// </summary>
	public class Line : Drawable
	{
		private static Texture2D _texture;
		private readonly Color _color;

	    /// <summary>
		/// 
		/// </summary>
		/// <param name="color"></param>
		public Line(Color color)
		{
			_color = color;
            Distance = 0;
			Direction = 0;
		}

	    /// <summary>
		/// 
		/// </summary>
		public Vector2 EndPosition { get; private set; }

	    /// <summary>
		/// 
		/// </summary>
		public Vector2 StartPosition { get; private set; }

	    /// <summary>
		/// 
		/// </summary>
		public float Distance { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public float Direction { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		public void UpdateDirection(Vector2 start, Vector2 end)
		{
			StartPosition = start;
			EndPosition = end;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		protected override void UpdateCore(UpdateContext context)
		{
			Direction = (float)Math.Atan2(StartPosition.Y - EndPosition.Y, StartPosition.X - EndPosition.X);
			Distance = Vector2.Distance(StartPosition, EndPosition);
		}

	    /// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		public override void LoadContent(LoadContext context)
		{
			if (_texture == null)
			{
				_texture = new Texture2D(GameContext.Game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
				_texture.SetData(new[] { Color.White }, 0, _texture.Width * _texture.Height);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override void UnloadContent()
		{
            _texture?.Dispose();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		protected override void DrawCore(DrawContext context)
        {
            var rectangle = new Rectangle((int)StartPosition.X, (int)StartPosition.Y, (int)Distance, 1);
            context.Draw(_texture, rectangle, null, _color, Direction, Vector2.Zero, SpriteEffects.None, 0f);
        }
	}
}