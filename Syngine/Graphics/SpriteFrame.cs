using Microsoft.Xna.Framework;

namespace Syngine.Graphics
{
    public class SpriteFrame
    {
        public SpriteFrame(int index, Rectangle bounds)
        {
            Index = index;
            Bounds = bounds;
        }

        public int Index { get; private set; }

        public Rectangle Bounds { get; private set; }
    }
}
