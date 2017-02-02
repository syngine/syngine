using Microsoft.Xna.Framework;
using Syngine.Controllers;

namespace Syngine
{
	/// <summary>
	/// 
	/// </summary>
	public struct UpdateContext
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="gameTime"></param>
        public UpdateContext(IController controller, GameTime gameTime) : this()
		{
			Controller = controller;
			GameTime = gameTime;
			Game = controller.Game;
		}

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
		public IController Controller { get; private set; }
	}
}