using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;

namespace Syngine.Physics
{
    public class PhysicsGame : GameBase
    {
        public PhysicsGame() : this(new Vector2(0f, 9.8f))
        {
        }

        public PhysicsGame(Vector2 gravity)
        {
            WorldContext.Set(new World(gravity));
        }

        protected override void Update(GameTime gameTime)
        {
            WorldContext.World?.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }
    }
}
