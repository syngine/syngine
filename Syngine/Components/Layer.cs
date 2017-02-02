using System.Collections.Generic;
using Syngine.Graphics;

namespace Syngine.Components
{
    public class Layer : Drawable, ILayer
    {
        public Layer(string name)
        {
            Name = name;
            Updatables = new List<IUpdate>();
            Drawables = new List<IDraw>();
        }

        protected IList<IUpdate> Updatables { get; }

        protected IList<IDraw> Drawables { get; }

        public override void Initialize()
        {
            foreach (var updatable in Updatables)
            {
                updatable.Initialize();
            }

            base.Initialize();
        }

        protected override void UpdateCore(UpdateContext context)
        {
            foreach (var updatable in Updatables)
            {
                updatable.Update(context);
            }
        }

        protected override void DrawCore(DrawContext context)
        {
            foreach (var drawable in Drawables)
            {
                drawable.Draw(context);
            }
        }

        public override void LoadContent(LoadContext context)
        {
            foreach (var drawable in Drawables)
            {
                drawable.LoadContent(context);
            }
        }

        public override void UnloadContent()
        {
            foreach (var unloadable in Drawables)
            {
                unloadable.UnloadContent();
            }
        }

        public virtual TUpdate AddUpdatable<TUpdate>(TUpdate updatable) where TUpdate : IUpdate
        {
            lock (Updatables)
            {
                Updatables.Add(updatable);
            }

            return updatable;
        }

        public virtual TDraw AddDrawable<TDraw>(TDraw drawable) where TDraw : IDraw
        {
            AddUpdatable(drawable);

            lock (Drawables)
            {
                Drawables.Add(drawable);
            }

            return drawable;
        }
    }
}