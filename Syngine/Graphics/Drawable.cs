using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Syngine.Components;

namespace Syngine.Graphics
{
    public abstract class Drawable : Loadable, IDraw
    {
        protected Drawable()
        {
            Visible = true;
        }
        
        public bool Visible { get; set; }

        public virtual void Draw(DrawContext context)
        {
            if (Visible)
            {
                DrawCore(context);
            }
        }

        protected abstract void DrawCore(DrawContext context);
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Drawable<TAsset> : Loadable<TAsset>, IDraw
    {
        protected Drawable()
        {
            Visible = true;
            Effects = SpriteEffects.None;
        }

        protected Drawable(string assetName) : this()
        {
            AssetName = assetName;
        }

        protected Drawable(string assetName, Color color) : this(assetName)
        {
            Color = color;
        }

        public Color Color { get; set; }

        public int DrawOrder { get; set; }

        public bool Visible { get; set; }

        public float Depth { get; set; }

        public virtual float Rotation { get; set; }

        public Vector2 Origin { get; set; }

        public SpriteEffects Effects { get; set; }

        public virtual void Draw(DrawContext context)
        {
            if (Visible)
            {
                DrawCore(context);
            }
        }

        protected abstract void DrawCore(DrawContext context);
    }
}