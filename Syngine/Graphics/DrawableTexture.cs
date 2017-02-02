using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Syngine.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class DrawableTexture : Drawable<Texture2D>
    {
        protected DrawableTexture()
        {
            Visible = true;
        }

        protected DrawableTexture(Rectangle bounds) : this()
        {
            Bounds = bounds;
        }

        public DrawableTexture(string assetName, Rectangle bounds) : base(assetName)
        {
            Bounds = bounds;
        }

        protected DrawableTexture(string assetName, Rectangle bounds, Color color) : base(assetName, color)
        {
            Bounds = bounds;
        }

        public Rectangle Bounds { get; set; }

        public Rectangle? SourceRectangle { get; set; }

        public override void LoadContent(LoadContext context)
        {
            base.LoadContent(context);

            var origin = Origin;
            origin.X = Bounds.Width/2f;
            origin.Y = Bounds.Height/2f;
            Origin = origin;
        }

        protected override void DrawCore(DrawContext context)
        {
            if (Asset != null)
            {
                context.Draw(Asset, Bounds, SourceRectangle, Color, Rotation, Origin, Effects, Depth);
            }
        }

        protected override void UpdateCore(UpdateContext context)
        {
        }

        public void SetPosition(Vector2 position)
        {
            var bounds = Bounds;
            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;
            Bounds = bounds;
        }

        public void Offset(Vector2 position)
        {
            var bounds = Bounds;
            bounds.Offset(position);
            Bounds = bounds;
        }
    }
}