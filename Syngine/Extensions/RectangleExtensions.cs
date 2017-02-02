using System;
using Microsoft.Xna.Framework;

namespace Syngine
{
	public static class RectangleExtensions
    {
        private static readonly Func<float, float, float> AddAndDivideBy2Func = (f1, f2) => f1 + (f2 > 0 ? f2 : 1) / 2f;

        public static bool Contains(this Rectangle rectangle, Vector2 position)
		{
			return rectangle.Contains((int)position.X, (int)position.Y);
        }

        public static bool Contains(this Rectangle rectangle, Point point)
        {
            return rectangle.Contains(point.X, point.Y);
        }

        public static Vector2 ToVector2(this Rectangle rectangle, bool center = true)
        {
            float x = rectangle.X;
            float y = rectangle.Y;

            if (center)
            {
                x = AddAndDivideBy2Func(x, rectangle.Width);
                y = AddAndDivideBy2Func(y, rectangle.Height);
            }

            return new Vector2(x, y);
        }
    }
}
