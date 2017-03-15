using System;
using Microsoft.Xna.Framework;

namespace Syngine
{
    public static class Rand
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        
        public static int NextInt()
        {
            return Random.Next();
        }

        public static int Next(int max)
        {
            return Random.Next(max);
        }

        public static int Next(int min, int max)
        {
            if (min > max)
            {
                var temp = max;
                max = min;
                min = temp;
            }

            return Random.Next(min, max);
        }

        public static float Next(float max)
        {
            return Next(1, (int)max) + (float)Random.NextDouble();
        }

        public static float Next()
        {
            return (float)Random.NextDouble();
        }

        public static float Next(float min, float max)
        {
            if (min > max)
            {
                var temp = max;
                max = min;
                min = temp;
            }
            return Next((int)min, (int)max) + (float)Random.NextDouble();
        }

        public static Vector2 Vector2(float minX, float maxX, float minY, float maxY)
        {
            return new Vector2(Next(minX, maxX), Next(minY, maxY));
        }

        public static Vector2 Vector2(Vector2 min, Vector2 max)
        {
            return new Vector2(Next(min.X, max.X), Next(min.Y, max.Y));
        }

        public static Vector2 Vector2()
        {
            return new Vector2(Next(), Next());
        }
    }
}