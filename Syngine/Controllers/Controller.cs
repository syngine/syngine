using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Syngine.Components;
using Syngine.Graphics;

namespace Syngine.Controllers
{
    public class Controller : DrawableGameComponent, IController
    {
        private bool _isInitialized;

        public Controller() : this(GameContext.Game)
        {
        }

        protected Controller(Game game) : base(game)
        {
            Enabled = true;
        }

        public static GameController RootController { get; protected set; }

        protected List<ILayer> Layers { get; } = new List<ILayer>();

        IEnumerable<ILayer> IController.Layers => Layers;

        /// <summary>
        /// 
        /// </summary>
        public SpriteBatch SpriteBatch { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public GraphicsDeviceManager GraphicsDeviceManager { get; protected set; }

        public IEnumerator<ILayer> GetEnumerator()
        {
            return Layers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Add the specified <typeparamref name="TLayer"/> to the collection.
        /// </summary>
        /// <typeparam name="TLayer"></typeparam>
        /// <param name="layer">The <typeparamref name="TLayer"/> to add to the collection.</param>
        /// <returns>The added <paramref name="layer"/></returns>
        public TLayer AddLayer<TLayer>(TLayer layer) where TLayer : ILayer
        {
            if (!Layers.Contains(layer))
            {
                Layers.Add(layer);
            }

            if (_isInitialized && !layer.IsInitialized)
            {
                layer.Initialize();
                layer.LoadContent(GameContext.CreateLoadContext());
            }

            return layer;
        }
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public override void Initialize()
        {
            if (GraphicsDeviceManager == null && RootController != null)
            {
                GraphicsDeviceManager = RootController.GraphicsDeviceManager;
            }

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            for (int i = 0; i < Layers.Count; i++)
            {
                Layers[i].Initialize();
            }

            base.Initialize();
            _isInitialized = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            var context = GameContext.CreateLoadContext(this);

            for (int i = 0; i < Layers.Count; i++)
            {
                Layers[i].LoadContent(context);
            }

            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                Layers[i].UnloadContent();
            }

            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            var context = GameContext.CreateUpdateContext(this, gameTime);

            for (int i = 0; i < Layers.Count; i++)
            {
                Layers[i].Update(context);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            var parameters = GetBeginCallOptions();
            SpriteBatch.Begin(
                parameters.SpriteSortMode,
                parameters.BlendState,
                parameters.SamplerState,
                parameters.DepthStencilState,
                parameters.RasterizerState,
                parameters.Effect,
                parameters.TransformMatrix
            );

            var context = GameContext.CreateDrawContext(this, gameTime);

            for (int i = 0; i < Layers.Count; i++)
            {
                Layers[i].Draw(context);
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        protected virtual BeginCallOptions GetBeginCallOptions()
        {
            return new BeginCallOptions
            {
                TransformMatrix = GameContext.Camera.Transform
            };
        }
    }
}