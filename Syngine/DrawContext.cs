using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Syngine.Controllers;

namespace Syngine
{
	/// <summary>
	/// 
	/// </summary>
	public struct DrawContext
	{
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public DrawContext(IController controller, SpriteBatch spriteBatch, GameTime gameTime) : this()
		{
			Controller = controller;
			SpriteBatch = spriteBatch;
			GameTime = gameTime;
			Game = controller.Game;
			GraphicsDevice = spriteBatch.GraphicsDevice;
		}

		#endregion

		#region Properties

		/// <summary>
		/// 
		/// </summary>
		public Game Game { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public GameTime GameTime { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public SpriteBatch SpriteBatch { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public GraphicsDevice GraphicsDevice { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public IController Controller { get; private set; }

		#endregion

		#region Methods

		/// <summary>
		/// 
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="rectangle"></param>
		/// <param name="color"></param>
		public void Draw(Texture2D texture, Rectangle rectangle, Color color)
		{
			SpriteBatch.Draw(texture, rectangle, color);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="position"></param>
		/// <param name="color"></param>
		public void Draw(Texture2D texture, Vector2 position, Color color)
		{
			SpriteBatch.Draw(texture, position, color);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="destinationRectangle"></param>
		/// <param name="sourceRectangle"></param>
		/// <param name="color"></param>
		public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
		{
			SpriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="position"></param>
		/// <param name="sourceRectangle"></param>
		/// <param name="color"></param>
		public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
		{
			SpriteBatch.Draw(texture, position, sourceRectangle, color);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="destinationRectangle"></param>
		/// <param name="sourceRectangle"></param>
		/// <param name="color"></param>
		/// <param name="rotation"></param>
		/// <param name="origin"></param>
		/// <param name="effect"></param>
		/// <param name="depth"></param>
		public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effect, float depth)
		{
			SpriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, rotation, origin, effect, depth);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="position"></param>
		/// <param name="sourceRectangle"></param>
		/// <param name="color"></param>
		/// <param name="rotation"></param>
		/// <param name="origin"></param>
		/// <param name="scale"></param>
		/// <param name="effect"></param>
		/// <param name="depth"></param>
		public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effect, float depth)
		{
			SpriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effect, depth);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="texture"></param>
		/// <param name="position"></param>
		/// <param name="sourceRectangle"></param>
		/// <param name="color"></param>
		/// <param name="rotation"></param>
		/// <param name="origin"></param>
		/// <param name="scale"></param>
		/// <param name="effect"></param>
		/// <param name="depth"></param>
		public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effect, float depth)
		{
			SpriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effect, depth);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="spriteFont"></param>
		/// <param name="text"></param>
		/// <param name="position"></param>
		/// <param name="color"></param>
		public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
		{
			SpriteBatch.DrawString(spriteFont, text, position, color);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="spriteFont"></param>
		/// <param name="text"></param>
		/// <param name="position"></param>
		/// <param name="color"></param>
		/// <param name="rotation"></param>
		/// <param name="origin"></param>
		/// <param name="scale"></param>
		/// <param name="effects"></param>
		/// <param name="depth"></param>
		public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float depth)
		{
			SpriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, depth);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="spriteFont"></param>
		/// <param name="text"></param>
		/// <param name="position"></param>
		/// <param name="color"></param>
		/// <param name="rotation"></param>
		/// <param name="origin"></param>
		/// <param name="scale"></param>
		/// <param name="effect"></param>
		/// <param name="depth"></param>
		public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effect, float depth)
		{
			SpriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effect, depth);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="spriteFont"></param>
		/// <param name="text"></param>
		/// <param name="position"></param>
		/// <param name="color"></param>
		public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
		{
			SpriteBatch.DrawString(spriteFont, text, position, color);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="spriteFont"></param>
		/// <param name="text"></param>
		/// <param name="position"></param>
		/// <param name="color"></param>
		/// <param name="rotation"></param>
		/// <param name="origin"></param>
		/// <param name="scale"></param>
		/// <param name="effects"></param>
		/// <param name="depth"></param>
		public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float depth)
		{
			SpriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, depth);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="spriteFont"></param>
		/// <param name="text"></param>
		/// <param name="position"></param>
		/// <param name="color"></param>
		/// <param name="rotation"></param>
		/// <param name="origin"></param>
		/// <param name="scale"></param>
		/// <param name="effect"></param>
		/// <param name="depth"></param>
		public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effect, float depth)
		{
			SpriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effect, depth);
		}

		#endregion
	}
}