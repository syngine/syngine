using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Syngine.Controllers;

namespace Syngine
{
	/// <summary>
	/// 
	/// </summary>
	public struct LoadContext
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="content"></param>
        public LoadContext(IController controller, ContentManager content) : this()
		{
			Controller = controller;
			Content = content;
			Game = controller.Game;
			GraphicsDevice = controller.GraphicsDevice;
		}

		/// <summary>
		/// 
		/// </summary>
		public Game Game { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ContentManager Content { get; }

        /// <summary>
        /// 
        /// </summary>
        public IController Controller { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public GraphicsDevice GraphicsDevice { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="assetName"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T Load<T>(string assetName)
		{
			return Content.Load<T>(assetName);
		}
	}
}