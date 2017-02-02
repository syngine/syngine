using System.Threading;
using FarseerPhysics.Dynamics;

namespace Syngine.Physics
{
    public static class WorldContext
    {
        private static World _world;

        public static World World => _world;

        public static void Set(World world)
        {
            Interlocked.Exchange(ref _world, world);
        }
    }
}