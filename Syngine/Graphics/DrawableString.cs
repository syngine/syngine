using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Syngine.Graphics
{
    public class DrawableString : Drawable<SpriteFont>
    {
        protected DrawableString()
        {
        }

        protected DrawableString(string assetName, Vector2 position, string text) : this(assetName, position, text, Color.White)
        {
        }

        protected DrawableString(string assetName, Vector2 position, string text, Color color) : base(assetName, color)
        {
            Position = position;
            Text = text;
        }

        public string Text { get; set; }

        public float Scale { get; set; } = 1.0f;

        public Vector2 Position { get; set; }

        public override void UnloadContent()
        {
            Asset?.Texture.Dispose();
        }

        protected override void UpdateCore(UpdateContext context)
        {
        }

        protected override void DrawCore(DrawContext context)
        {
            if (Asset != null && !string.IsNullOrEmpty(Text))
            {
                context.DrawString(Asset, Text, Position, Color, Rotation, Origin, Scale, Effects, Depth);
            }
        }
    }
}
