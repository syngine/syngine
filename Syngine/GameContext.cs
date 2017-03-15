using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Syngine.Components;
using Syngine.Controllers;
using Syngine.Input;

namespace Syngine
{
	/// <summary>
	/// 
	/// </summary>
	public static class GameContext
	{
		private static Game _game;
		private static IController _controller;
		private static Camera _camera;

	    /// <summary>
		/// 
		/// </summary>
		public static Game Game
		{
			get
			{
				return _game;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public static IController Controller => _controller;

	    /// <summary>
		/// 
		/// </summary>
		public static IInputManager Input => GameInput.Input;

	    /// <summary>
		/// 
		/// </summary>
		public static Camera Camera
		{
			get
			{
				if (_camera == null)
				{
					Set(new Camera());
				}

				return _camera;
			}
		}

        /// <summary>
        /// The <see cref="IServiceProvider"/> for the current game.
        /// </summary>
	    public static GameServiceContainer Services => Game?.Services;

	    /// <summary>
		/// 
		/// </summary>
		/// <param name="game"></param>
		public static void Set(Game game)
		{
			Interlocked.Exchange(ref _game, game);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        public static void Set(IController controller)
		{
			Interlocked.Exchange(ref _controller, controller);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="camera"></param>
		public static void Set(Camera camera)
		{
			Interlocked.Exchange(ref _camera, camera);
		}

        /// <summary>
        /// Sets the focus of the camera.
        /// </summary>
        /// <param name="focus">The focus the camera will be set to.</param>
	    public static void SetFocus(Vector2 focus)
	    {
	        Camera.Focus = focus;
	    }

	    /// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static LoadContext CreateLoadContext()
		{
			return CreateLoadContext(Controller);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static LoadContext CreateLoadContext(IController controller)
        {
            return new LoadContext(controller, controller.Game.Content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UpdateContext CreateUpdateContext(GameTime gameTime)
		{
			return CreateUpdateContext(Controller, gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UpdateContext CreateUpdateContext(IController controller, GameTime gameTime)
        {
            return new UpdateContext(Controller, gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DrawContext CreateDrawContext(GameTime gameTime)
		{
			return CreateDrawContext(Controller, Controller.SpriteBatch, gameTime);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static DrawContext CreateDrawContext(SpriteBatch spriteBatch, GameTime gameTime)
		{
			return CreateDrawContext(Controller, spriteBatch, gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DrawContext CreateDrawContext(IController controller, GameTime gameTime)
        {
            return CreateDrawContext(controller, controller.SpriteBatch, gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DrawContext CreateDrawContext(IController controller, SpriteBatch spriteBatch, GameTime gameTime)
        {
            return new DrawContext(controller, spriteBatch, gameTime);
        }
    }
}